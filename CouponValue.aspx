<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="CouponValue.aspx.cs" Inherits="CouponValue" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">

    <div class="row">
        <ol class="breadcrumb">
            <li><a href="/">
                <svg class="glyph stroked home">
                    <use xlink:href="#stroked-home" />
                </svg></a></li>
            <%=navPath %>
        </ol>
    </div>
    <br />
    <div class="panel panel-info">
        <div class="panel-heading">
            <div class="row">
                <div class="col-sm-8">
                    <h4 class="text-primary">Coupon Value</h4>
                </div>
                <div class="col-sm-4 text-right">
                    <%if (canAdd)
                      { %>
                    <button type="button" class="btn btn-primary CreateBtn" onclick="CreateNew();">Create New</button>

                    <%} %>
                </div>
            </div>
        </div>

        <div class="panel-body">
            <div class="col-md-12">
                <table id="tblCouponValueList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                         <th></th>
                            <th class="col-md-3">Label</th>
                            <th class="col-md-3">Value</th>
                            <th class="col-md-3">Status</th>
                            <th class="col-md-3">Actions</th>
                            
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>

        </div>


        <script>
            var currPage = "module<%=moduleId%>";
        </script>
    </div>


    <div id="mdlCreate" class="modal fade" data-id="-1" data-edit ="Add" data-toggle="modal" 
         role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Coupon Value Master Form in
                        <label id="lblentrymode"></label>
                        Mode</h4>
                </div>
                <div class="modal-body">
                    <div id="dverror"></div>
                    <form class="form-horizontal" role="form" id="frmMaster">

                        <input type="hidden" id="agency_id" name="CouponValueId" />
                        <input type="hidden" id="EntryMode" name="EntryMode" />

                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label class="control-label col-sm-4"  for="txtLabel">Label:</label>
                                    <div class="col-sm-8">
                                        <input type="text" maxlength="10" class="form-control" id="txtLabel"   name="Label" placeholder="Label" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtValue">Value:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtValue" maxlength="3" name="txtValue" placeholder="Value" required>
<%--                                    <textarea id="txtDescription" name="Description" class="ckeditor"></textarea>--%>
                                    </div>
                                </div>
                               
                                 <div class="form-group" id="StatusShow">
                                    <label class="control-label col-sm-4"  for="chkStatus"><label id="lblStatusText" ></label>:</label>
                                    <div class="col-sm-8">
                                       <div id="lblSwitch" class="make-switch switch-small"  >
                                        <input type="checkbox" name="chkStatus"  data-on-text="Valid" data-off-text="Pending" checked />
                                        </div>

                                    </div>
                                </div>
                                
                                </div>
                            </div>




                        <div class="modal-footer">
                            <div class="row">
                                <div  class="col-lg-6">
                                <label id="lblError" style="padding: 7px;" class="alert alert-danger" title=""></label>
                                </div>
                                 <div class="col-lg-6">
                                   <button id="btnSubmit" type="button" class="btn btn-default" data-EditId="0" data-id="-1" onclick="SaveEntry();">Save</button>
                                    <button id="btnCancel" type="button" class="btn btn-default" onclick="hideModel()">Cancel</button>
                                </div>
                            </div>

                        </div>
                    </form>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctlscript" Runat="Server">

       <script src="Pages/Value.js"></script>


        <script type="text/javascript">

            // To delete data entry for coupon type
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
                url: "CouponValue.aspx/DeleteCouponValueById",
                dataType: "json",
                data: JSON.stringify({ 'ValueId': editid }),
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


    // Bind Coupon Type Listing
    function BindTable() {

        $("#tblCouponValueList").dataTable().fnDestroy();
        $.ajax({
            type: "POST",
            url: "CouponValue.aspx/GetCouponValue",
            dataType: "json",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            async: true,
            cache: false,
            success: function (msg) {
                $('#tblCouponValueList').dataTable({
                    "responsive": true, "autoWidth": false,
                    "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                    data: JSON.parse(msg.d),
                    columns: [
                          { data: "Id", "visible": false },
                          { data: "Label" },
                          { data: "Value" },
                            { data: "Status" },
                                  {
                                      data: 'Id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                          return '<%if (canEdit||canView){%><a href="#" title="View" onclick="EditEntry(' + data.Id + ',1)"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canEdit)
                                      {%><a href="#" title="Edit" onclick="EditEntry(' + data.Id + ',0)"><img src="/imgs/icon_portal_edit.png" class="actionIcon"/></a>&nbsp;<%}%> <%if (canAppr)
                                          {%><a href="#" title="Approve" onclick="ValidateCoupon(' + data.Id + ',2)"><img src="/imgs/Validate.png" class="actionIcon"/></a>&nbsp;<%}%> <%if (canDelete)
                                          {%><a href="#" title="Delete" onclick="DeleteEntry(' + data.Id + ')"><img src="/imgs/icon_portal_delete.png" class="actionIcon"/></a><%}%> ';
                                  }
                              }

                ]


            });
        }
    });
                  }

</script>
</asp:Content>

