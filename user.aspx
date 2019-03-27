<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user" %>

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
                <div class="col-sm-8"> <h4 class="text-primary">User</h4></div>
                <div class="col-sm-4 text-right"><%if (canAdd){ %>
                     <button type="button" class="btn btn-primary CreateBtnss" onclick="CreateNew();">Create New</button>    
                 <%} %></div>
            </div>                          
                  
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <table id="tblUserList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>User Name</th>
                           <th>Given Name</th> 
                           <th>Family Name</th> 
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
                    <h4 class="modal-title"> User Master Form in <label id="lblentrymode"></label> Mode</h4>
                </div>
                <div class="modal-body">
                    <div id="dverror"></div>
                    <form class="form-horizontal" role="form" id="frmMaster">

                        <input type="hidden" id="id" name="id" />
                        <input type="hidden" id="EntryMode" name="EntryMode" />
                       
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="username">User Name:</label>
                                    <div class="col-sm-6">
                                        <input type="email"   class="form-control" id="uname" name="uname" placeholder="username" required>
                                        <label id="lblEError" style="padding: 7px;" class="alert alert-danger" title=""></label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="long_name">Password:</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="password" name="password" placeholder="password" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="givenname">Given Name:</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="givenname" name="givenname" placeholder="givenname " required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="familyname">Familyname:</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="familyname" name="familyname" placeholder="familyname" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="auth">Auth:</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="auth" name="auth" placeholder="auth" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="role_id">Role:</label>
                                    <div class="col-sm-6">
                                        <select id="Role_id" name="Role_id" class="select2 form-control " style="width:100% ">                                           
                                           <option value="">--Select Role--</option>                                       
                                        </select>
                                    </div>
                                </div>
                                
                            </div>
                            
                            </div>
                        <div class="modal-footer">
                                 <div class="row">
                             <div  class="col-lg-6">
                                <label id="lblError" style="padding: 7px;" class="alert alert-danger" title=""></label>
                                </div>
                                       <div  class="col-lg-6">
                            <button type="button" class="btn btn-default" onclick="SaveEntry();">Submit</button>
                            <button id="btnCancel" type="button" class="btn btn-default" onclick="hideModel()">Cancel</button>
                                           </div>
                                     </div>
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
    <script src="Pages/User.js"></script>
    <script type="text/javascript">

        // To delete data entry for Voucher type
        function DeleteEntry(editid) {
            $("#lblError").hide();
            <% if (!canDelete)
    {%>alert("You don't have rights to perform this action."); return false;<%}%>
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
                    url: "user.aspx/DeleteuserbyId",
                    dataType: "json",
                    data: JSON.stringify({ 'UserId': editid }),
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (res) {

                        BindTable();
                        swal("Deleted!", "Your record has been deleted.", "success");

                    }
                });

            });


            $('#mdlCreate .close').click();
        }

        function BindTable() {
            $("#tblUserList").dataTable().fnDestroy();
            $.ajax({
                type: "POST",
                url: "user.aspx/GetUserAdminData",
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
                              { data: "username" },
                              { data: "givenname" },
                              { data: "familyname" },
                              { data: "name" }<%if (canEdit){%>,                             
                              {
                                  data: 'id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                      
                                      return '<a href="#" onclick="EditEntry(' + data.id + ',1)"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<%if (canEdit)
 {%><a href="#" onclick="EditEntry(' + data.id + ',0)"><img src="/imgs/icon_portal_edit.png" class="actionIcon"/></a>&nbsp;<%}%> <%if (canDelete)
                                          {%><a href="#" title="Delete" onclick="DeleteEntry(' + data.id + ')"><img src="/imgs/icon_portal_delete.png" class="actionIcon"/></a><%}%> ';
                                  }
                              } <%} %>,
                        ]
                    });
                }
            });
        }


        </script>
</asp:Content>

