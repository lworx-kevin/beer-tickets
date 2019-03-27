<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="MenuCategories.aspx.cs" Inherits="MenuCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
           <div class="row">
	<ol class="breadcrumb">
		<li><a href="/"><svg class="glyph stroked home"><use xlink:href="#stroked-home"/></svg></a></li>       
		<li class="active">Menu Categories</li>
	</ol>
    </div>
    <br />

      
       <div class="panel panel-info">
        <div class="panel-heading">
            <div class="row">
                <div class="col-sm-8"> <h4 class="text-primary">Menu Categories</h4></div>
                <div class="col-sm-4 text-right">
                     <button type="button" class="btn btn-primary CreateBtn" onclick="CreateNew();">Create New</button>    
                </div>
            </div>                          
                  
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <table id="tblUserList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>id</th>
                            <th>name</th>
                            <th>Edit</th>                                                                     
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
                    <h4 class="modal-title">Menu Categories Master Form in <label id="lblentrymode"></label> Mode</h4>
                </div>
                <div class="modal-body">
                    <div id="dverror"></div>
                    <form class="form-horizontal" role="form" id="frmMaster">

                        <input type="hidden" id="id" name="id" />
                        <input type="hidden" id="EntryMode" name="EntryMode" />
                       
                        <div class="row">
                            <div class="col-sm-12">


                               <div class="form-group">
                                    <label for="priority" class="col-sm-4 control-label">
                                      Priority
                                    </label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control " id="priority" name="priority" value=""  />
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <label for="name" class="col-sm-4 control-label">
                                       Name
                                    </label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control " id="name" name="name" value=""  />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="image" class="col-sm-4 control-label">
                                       Image
                                    </label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control " id="image" name="image" value=""  />
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <label for="last_modified" class="col-sm-4 control-label">
                                       Last Modified
                                    </label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control datepicker" id="last_modified" name="last_modified" value=""  />
                                    </div>
                                </div>         
                               
                            </div>
                            
                            </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" onclick="SaveEntry();">Submit</button>
                        </div>
                    </form>
                </div>

            </div>

        </div>
    </div>

        <script>
            var currPage = "agents";
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctlscript" Runat="Server">
    <script type="text/javascript">
        function BindTable() {
            $("#tblUserList").dataTable().fnDestroy();
            $.ajax({
                type: "POST",
                url: "MenuCategories.aspx/GetMenuCategoriesData",
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
                              { data: "name" },
                              {
                                  data: 'id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                      return '<a href="#" onclick="EditEntry(' + data.id + ')">Edit</a>';
                                  }
                              },
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

            $("#priority").val('');
            $("#name").val('');
            $("#image").val('');
            $("#last_modified").val('');
            
            $('#myModal').modal('show');
        }

        function EditEntry(editid) {
            $("#lblentrymode").html("Modify");
            $("#dverror").empty();
            $("#EntryMode").val('Edit');
            var json;
            $.ajax({
                type: "POST",
                url: "MenuCategories.aspx/GetByID",
                dataType: "json",
                data: JSON.stringify({ 'id': editid }),
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (res) {
                    json = JSON.parse(res.d);

                    $("#id").val(json[0].id);
                    $("#priority").val(json[0].priority);
                    $("#name").val(json[0].name);
                    $("#image").val(json[0].image);
                    $("#last_modified").val(json[0].last_modified);

                }
            });

            $('#myModal').modal('show');
        }

        function SaveEntry() {
           
            var priority = $("#priority").val();
            var name = $("#name").val();
            var image = $("#image").val();
            var last_modified = $("#last_modified").val();
            
            var id = $("#id").val();

            if (Validate()) {
                var url = '';
                if ($("#EntryMode").val() == 'Add') {
                    url = 'MenuCategories.aspx/AddData';
                } else {
                    url = 'MenuCategories.aspx/EditData';
                }

                $.ajax({
                    type: "POST",
                    url: url,
                    dataType: "json",
                    data:
                        JSON.stringify({                            
                            'priority': priority,
                            'name': name,
                            'image': image,
                            'lastmodified': last_modified,
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

