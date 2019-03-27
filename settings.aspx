<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
   <div class="row">
	<ol class="breadcrumb">
		<li><a href="/"><svg class="glyph stroked home"><use xlink:href="#stroked-home"/></svg></a></li>
      <%=navPath %>>
	</ol>
    </div>
    <br />
        
      
    <div class="panel panel-info">
        <div class="panel-heading">
            <div class="row">
                <div class="col-sm-8"> <h4 class="text-primary">Settings</h4></div>
                <div class="col-sm-4 text-right">
                   <!--  <button type="button" class="btn btn-primary" onclick="CreateNew();">Create New</button>    -->
                </div>
            </div>                          
                  
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <table id="tblUserList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>Setting ID</th>
                            <th>Name</th>
                            <th>Value</th><%if (canEdit){%> <th>Edit</th> <%} %>
                             
                            
                        </tr>
                    </thead>
                    <tbody></tbody>                    
                </table>
            </div>
        </div>
        </div>
    
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"> Settings Master Form in <label id="lblentrymode"></label> Mode</h4>
                </div>
                <div class="modal-body">
                    <div id="dverror"></div>
                    <form class="form-horizontal" role="form" id="frmMaster">

                        <input type="hidden" id="id" name="id" />
                        <input type="hidden" id="EntryMode" name="EntryMode" />
                       
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="setting_name">Name:</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="setting_name" name="setting_name" placeholder="Short Name" disabled required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="setting_value">Value:</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="setting_value" name="setting_value" placeholder="Long Name" required>
                                    </div>
                                </div>
                            </div>
                            
                            </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" onclick="SaveEntry();">Submit</button>
                            <button id="btnCancel" type="button" class="btn btn-default" onclick="hideModel()">Cancel</button>
                        </div>
                    </form>
                </div>

            </div>

        </div>
    </div>

        <script>
           var currPage = "module<%=moduleId%>";
        </script>  

    </asp:Content>
  
    <asp:Content ID="Content2" ContentPlaceHolderID="ctlscript" Runat="Server">
      
    <script type="text/javascript">
       
        function BindTable() {
            $("#tblUserList").dataTable().fnDestroy();
            $.ajax({
                type: "POST",
                url: "settings.aspx/GetSettingData",
                dataType: "json",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (msg) {
                    $('#tblUserList').dataTable({
                        "responsive": true,
                        "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                        data: JSON.parse(msg.d),
                        columns: [
                              { data: "id" },
                              { data: "setting_name" },
                              { data: "setting_value" }<%if (canEdit){%> ,
                              {
                                  data: 'id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                      
                                      return '<a href="#" onclick="EditEntry(' + data.id + ',1)"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<%if (canEdit)
 {%><a href="#" onclick="EditEntry(' + data.id + ',0)"><img src="/imgs/icon_portal_edit.png" class="actionIcon"/></a>&nbsp;<%}%>';
                                  }
                              }<%} %>,
                        ]
                    });
                }
            });
        }


        $(document).ready(function () {                
            BindTable();
        });
 
        function CreateNew() {
            $("#lblentrymode").html("Create");
            $("#EntryMode").val('Add');         
            $("#dverror").empty();
            $("#setting_name").val('');
            $("#setting_value").val('');
            $('#myModal').modal('show');
        }

        function hideModel() {
            $('#myModal').modal('hide');
        }
        function EditEntry(editid, view) {
            if (view == 1) {
                $("#lblentrymode").html("View");
                $("#frmMaster :input").prop("disabled", true);
                $("#btnSubmit").hide();
                $("#btnCancel").prop("disabled", false)
            }
            else {
                $("#lblentrymode").html("Modify");
                $("#frmMaster :input").prop("disabled", false);
                $("#btnSubmit").show();
            }
            //$("#lblentrymode").html("Modify");            
            $("#dverror").empty();
            $("#EntryMode").val('Edit');
            var json;
            $.ajax({
                type: "POST",
                url: "settings.aspx/GetSettingDataByID",
                dataType: "json",
                data: JSON.stringify({ 'id': editid }),
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (res) {
                    json = JSON.parse(res.d);
                    $("#setting_name").val(json[0].setting_name);
                    $("#setting_value").val(json[0].setting_value);
                    $("#id").val(json[0].id);
                }
            });
            
            $('#myModal').modal('show');
        }

        function SaveEntry() {
            var setting_name = $("#setting_name").val();
            var setting_value = $("#setting_value").val();
            var id = $("#id").val();

            
            if (Validate()) {
                var url = '';
                if ($("#EntryMode").val() == 'Add') {
                    url = 'settings.aspx/AddSettingData';
                } else {
                    url = 'settings.aspx/EditSettingData';
                }

                $.ajax({
                    type: "POST",
                    url: url,
                    dataType: "json",
                    data: JSON.stringify({ 'setting_value': setting_value, 'id': id }),
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $('#myModal').modal('hide');
                        BindTable();
                        $.notify({
                            title: '',
                            message: 'Record Save Succesfully.'
                        }, { type: 'success' });
                    }
                });
            } 

            

           
        }

        function Validate() {
           
            var errortext = "";
            if(errortext != "")
            {
                var err = "<div class='alert alert-danger'><a href ='#' class='close' data-dismiss='alert' aria-label='close'></a><ul>" + errortext + "</ul></div>";
                $("#dverror").empty().append(err);
                return false;
            }
            else{
                return true;
            }
            

        }

        function DeleteEntry(editid) {
            swal({
                title: "Are you sure?",
                text: "Your will not be able to recover this record!",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            },
            function () {
                var json;
                $.ajax({
                    type: "POST",
                    url: "brands.aspx/DeleteDataByID",
                    dataType: "json",
                    data: JSON.stringify({ 'id': editid }),
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (res) {
                        BindTable();
                        swal("Deleted!", "Your record has been deleted.", "success");                        
                    }
                });

            });
                     
        }

        </script>
</asp:Content>

