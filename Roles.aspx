<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
   <div class="row">
	<ol class="breadcrumb">
		<li><a href="/"><svg class="glyph stroked home"><use xlink:href="#stroked-home"/></svg></a></li>
       <%=navPath %>
	</ol>
    </div>
    <br />

      
       <div class="panel panel-info">
        <div class="panel-heading">
            <div class="row">
                <div class="col-sm-8"> <h4 class="text-primary">Roles</h4></div>
                <div class="col-sm-4 text-right"><%if (canAdd){ %>
                     <button type="button" class="btn btn-primary" onclick="CreateNew();">Create New</button>    
                 <%} %></div>
            </div>                          
                  
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <table id="tblUserList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>Rid</th>
                            <th>Name</th>
                           <%if (canEdit){%> <th>Actions</th> <%} %>                                          
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
                    <h4 class="modal-title">Roles Master Form in <label id="lblentrymode"></label> Mode</h4>
                </div>
                <div class="modal-body">
                    <div id="dverror"></div>
                    <form class="form-horizontal" role="form" id="frmMaster">

                        <input type="hidden" id="rid" name="rid" />
                        <input type="hidden" id="EntryMode" name="EntryMode" />
                       
                        <div class="row">
                            <div class="col-sm-12">

                                 <div class="form-group">
                                    <label for="name" class="col-sm-4 control-label">
                                       Name
                                    </label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control " id="name" name="name" value=""  />
                                    </div>
                                </div>

                                 <div class="form-group">
                                  
                                    <div class="col-sm-12">
                                        <b>Permissions</b> <br /><br />
                                        <%=rolesBlock %>
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
                url: "Roles.aspx/GetUserRoleData",
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
                              { data: "name" }
                              <%if (canEdit){%> ,
                              {
                                  data: 'rid', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                      
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
            $('.functions').removeAttr('checked');
            $("#name").val('');
           
            
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
            //empty all checkboxes
            //alert("here");
            $('.functions').removeAttr('checked');

            var json;
            $.ajax({
                type: "POST",
                url: "Roles.aspx/GetByID",
                dataType: "json",
                data: JSON.stringify({ 'id': editid }),
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (res) {
                    json = JSON.parse(res.d);

                    $("#rid").val(json[0].id);
                    $("#name").val(json[0].name);

                    var arrFunc = json[0].functions.split(",");
                    $('.functions').each(function () {

                       if (arrFunc.indexOf(this.value) >= 0) this.checked = true;
                        
                    });
                    //$("#functions").val(json[0].functions);
                    //alert(json[0].functions);
                   
                    $("#last_modified").val(DTformater(json[0].last_modified));
                    

                }
            });

            $('#myModal').modal('show');
        }

        function SaveEntry() {            
            var name = $("#name").val();
            //var functions = $("#functions").val();
            //var lastmodified = $("#last_modified").val();
            
            var id = $("#rid").val();
            var functions = $('.functions:checked').map(function () { return this.value; }).get().join(',')
            //alert(functions)
            if (Validate()) {
                var url = '';
                if ($("#EntryMode").val() == 'Add') {
                    url = 'Roles.aspx/AddData';
                } else {
                    url = 'Roles.aspx/EditData';
                }

                $.ajax({
                    type: "POST",
                    url: url,
                    dataType: "json",
                    data:
                        JSON.stringify({                            
                            'name': name,
                            'functions': functions,
                            'id': id
                        }),
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

            var name = $("#name").val();

            var errortext = "";

            if (name == "") {
                errortext += "<li><label>Please Enter Name </label></li>";

            }

            if (errortext != "") {
                var err = "<div class='alert alert-danger'><a href ='#' class='close' data-dismiss='alert' aria-label='close'></a><ul>" + errortext + "</ul></div>";
                $("#dverror").empty().append(err);
                return false;
            }
            else {
                return true;
            }


        }


     </script>
</asp:Content>

