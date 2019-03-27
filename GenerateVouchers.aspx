<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="GenerateVouchers.aspx.cs" Inherits="GenerateVouchers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
   <script src="js/jquery.csv-0.71.min.js"></script> 
    <style>
        .modal.in .modal-dialog {
    width: 68%;
}
        input[type=radio]{
  width   : 28px;
  margin  : 0;
  padding-left : 5px;
  padding-right : 5px;

}
    </style>
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
                    <h4 class="text-primary">Generate Voucher</h4>
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
                <table id="tblVoucherList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Date</th>
                            <th>Campaign</th>
                            <th>Distribution</th>
                            <th>Coupon</th>
                            <th>Status</th>
                             <th>Action</th>

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


    <div id="mdlDetailListing" class="modal fade" data-id="-1" data-toggle="modal"
        role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Voucher Listing</h4>
                </div>
                <div class="modal-body">
                    <div class="col-md-12">
                        <table id="detailsTable" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Email</th>
                                    <th>FirstName</th>
                                    <th>LastName</th>
                                    <th>Status</th>
                                    <th>Distributed</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="row">
                        &nbsp;
                    </div>

                </div>

            </div>
        </div>
    </div>


    <div id="mdlEditViewCoupon" class="modal fade" data-id="-1" data-edit="Add" data-toggle="modal"
        role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Coupon Listing in
                        <label id="lblCouponentrymode"></label>
                        Mode</h4>
                </div>
                <div class="modal-body">
                    <div id="dvCouponerror"></div>
                   <input type="hidden" id="CouponEntryMode" name="EntryMode" />

                    <form class="form-horizontal" role="form" id="frmCouponMaster">

                        <div class="row">
                            <div class="col-sm-12">

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtEmail">Email:</label>
                                    <div class="col-sm-8">
                                        <input id="txtEmail" class="select2 form-control" type="text" style="width: 100%"/>
                                       
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtFirstName">FirstName:</label>
                                    <div class="col-sm-8">
                                        <input id="txtFirstName" class="select2 form-control" type="text" style="width: 100%"/>
                                        
                                    </div>
                                </div>
       
                                
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtEmail">LastName:</label>
                                    <div class="col-sm-8">
                                        <input id="txtLastName" class="select2 form-control" type="text" style="width: 100%"/>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label id="lblCouponError" style="padding: 7px;" class="     alert-danger" title=""></label>
                                        </div>
                                        <div class="col-lg-6">
                                            <button id="btnSubmitCoupon" type="button" class="btn btn-default" data-editid="0" data-id="-1" onclick="SaveCouponEntry();">Save</button>
                                            <button id="btnCancelCoupon" type="button" class="btn btn-default" onclick="hideCouponModel()">Cancel</button>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </form>

                </div>
            </div>
        </div>
    </div>




    <div id="mdlCreate" class="modal fade" data-id="-1" data-edit="Add" data-toggle="modal"
        role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Generate Voucher Form in
                        <label id="lblentrymode"></label>
                        Mode</h4>
                </div>
                <div class="modal-body">
                    <div id="dverror"></div>
                    <form class="form-horizontal" role="form" id="frmMaster">

                        <input type="hidden" id="CatId" name="CatId" />
                        <input type="hidden" id="EntryMode" name="EntryMode" />
                        <div class="row">
                            <div class="col-sm-12">

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="ddlVoucCamp">Campaign:</label>
                                    <div class="col-sm-8">
                                        <select id="ddlVoucCamp" class="select2 form-control" style="width: 100%">
                                            <option value="">--Select Campaign--</option>
                                        </select>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="ddlDistribution">Distribution:</label>
                                    <div class="col-sm-8">
                                        <select id="ddlDistribution" class="select2 form-control" style="width: 100%">
                                            <option value="">--Select Distribution--</option>
                                            <option value="1">Email</option>
                                            <option value="2">CSV</option>
                                            <option value="3">PDF</option>
                                        </select>
                                    </div>
                                </div>
                                
                                  <div  id="dvImportSegments"  class="fileupload  form-group">
                                    <label class="control-label col-sm-4" for="txtFileUpload">Upload CSV:</label>
                                    <div class="col-sm-8">
                                         <input type="file" name="filename" id="Upload">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtFileUpload">Contain Header Row:</label>
                                    <div class="col-sm-8">
                                         <input type="checkbox" id="chkHeaderRow">
                                    </div>
                                </div>
                              
                                <div id ="csv-display">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                                </div>

                                <div class="form-group" id="StatusShow">
                                    <label class="control-label col-sm-4" for="chkStatus">
                                        <label id="lblStatusText"></label>
                                        :</label>
                                    <div class="col-sm-8">

                                        <div id="lblSwitch" class="make-switch switch-small">
                                            <input type="checkbox" name="chkStatus" data-on-text="Yes" data-off-text="No" checked />
                                        </div>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label id="lblError" style="padding: 7px;" class="     alert-danger" title=""></label>
                                        </div>
                                        <div class="col-lg-6">
                                            <button id="btnSubmit" type="button" class="btn btn-default" data-editid="0" data-id="-1" onclick="SaveEntry();">Save</button>
                                            <button id="btnCancel" type="button" class="btn btn-default" onclick="hideModel()">Cancel</button>
                                        </div>
                                    </div>

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
    <script src="Pages/VGenerate.js"></script>
            <script type="text/javascript">


                function SendEntry(editid, Dist) {
                    if (Dist == null) {
                        $("#lblError").hide();
                        <% if (!canEdit)
        {%>alert("You don't have rights to perform this action."); return false;<%}%>
                        swal({
                            title: "Are you sure?",
                            text: "Do you really want these records to be ready to Send?",
                            type: "warning",
                            showCancelButton: true,
                            confirmButtonClass: "btn-danger",
                            confirmButtonText: "Yes, Send it!",
                            closeOnConfirm: false
                        },
                        function () {
                            var json;
                            $.ajax({
                                type: "POST",
                                url: "GenerateVouchers.aspx/SendVoucherWithCampaignbyId",
                                dataType: "json",
                                data: JSON.stringify({ 'GenId': editid }),
                                contentType: "application/json; charset=utf-8",
                                async: true,
                                cache: false,
                                success: function (res) {
                                    BindTable();
                                    swal("Maked as Sent!", "Your record has been updated.", "success");

                                }
                            });

                        });

                        $('#mdlCreate .close').click();
                    }
                }

                              // Bind Voucher Type Listing
                              function BindTable() {

                                  $("#tblVoucherList").dataTable().fnDestroy();
                                  $.ajax({
                                      type: "POST",
                                      url: "GenerateVouchers.aspx/GetVouchersWithCampaign",
                                      dataType: "json",
                                      data: "{}",
                                      contentType: "application/json; charset=utf-8",
                                      async: true,
                                      cache: false,
                                      success: function (msg) {
                                          $('#tblVoucherList').dataTable({
                                              "responsive": true, "autoWidth": false,
                                              "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                                              data: JSON.parse(msg.d),
                                              columns: [

                                                    { data: "Id", "visible": false },
                                                    { data: "Date" },
                                                      { data: "CampaignName" },
                                                    { data: "Distribution" },
                                                    { data: "Coupons" },

                                                     { data: "Status" },
                                                            {
                                                                data: 'Id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                                                    return '<%if (canEdit||canView){%><a href="#" title="View" onclick="EditEntry(' + data.Id + ',1,' + data.Distributed + ')"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<a href="#" title="List" onclick="ListView(' + data.Id + ')"><img src="/imgs/icon_portal_Listing.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canEdit)
                                      {%><a href="#" title="Send" onclick="SendEntry(' + data.Id + ',0,' + data.Distributed + ')"><img src="/imgs/portal_icon_Send.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canDelete)
                                          {%><a href="#" title="Delete" onclick="DeleteEntry(' + data.Id + ',' + data.Distributed + ')"><img src="/imgs/icon_portal_delete.png" class="actionIcon"/></a><%}%>  ';
                                                                }
                                                            }

                                              ],
                                              "rowCallback": function (row, data, index) {
                                                  if (data.Distributed != null) {
                                                      $('td:eq(5) > a:nth-child(3)', row).hide();
                                                      $('td:eq(5) > a:nth-child(4)', row).hide();
                                                  }
                                              }



                                          });
                                      }
                                  });
                              }



                function ListView(editid) {
                    $('#mdlDetailListing').modal('show');
                    $('#mdlDetailListing').attr("data-id", editid)
                    $("#detailsTable").dataTable().fnDestroy();
                    $.ajax({
                        type: "POST",
                        url: "GenerateVouchers.aspx/GetVCouponsListing",
                        dataType: "json",
                        data: JSON.stringify({ 'Id': editid }),
                        contentType: "application/json; charset=utf-8",
                        async: true,
                        cache: false,
                        success: function (msg) {
                            $('#detailsTable').dataTable({
                                "responsive": true, "autoWidth": false,
                                "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                                data: JSON.parse(msg.d),
                                columns: [

                                      { data: "Id", "visible": false },
                                      { data: "Email" },
                                        { data: "FirstName" },
                                         { data: "LastName" },
                                      { data: "Status" },
                                      { data: "Distribution" },

                                              {
                                                  data: 'Id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                                      return '<%if (canEdit||canView){%><a href="#" title="View" onclick="EditCouponEntry(' + data.Id + ',1,' + data.Distribution + ')"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canEdit) 
                                      {%><a id="Edit' + data.Id + '"  href="#" title="Edit" onclick="EditCouponEntry(' + data.Id + ',0,' + data.Distribution + ')"><img src="/imgs/icon_portal_edit.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canDelete)
                                          {%><a id="Delete' + data.Id + '" href="#" title="Delete" onclick="DeleteCouponEntry(' + data.Id + ',' + data.Distribution + ')"><img src="/imgs/icon_portal_delete.png" class="actionIcon"/></a>  <%}%>';
                                                  }


                                              }

                                ],
                                "rowCallback": function (row, data, index) {
                                    if (data.Distribution == 1) {
                                        $('td:eq(5) > a:nth-child(2)', row).hide();
                                        $('td:eq(5) > a:nth-child(3)', row).hide();
                                    }
                                }


                            });
                        }
                    });


                }


                function DeleteCouponEntry(editid, Dist) {
                    $("#lblError").hide();
                    if (Dist == 0) {
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
                                url: "GenerateVouchers.aspx/DeleteCouponById",
                                dataType: "json",
                                data: JSON.stringify({ 'Id': editid }),
                                contentType: "application/json; charset=utf-8",
                                async: true,
                                cache: false,
                                success: function (res) {
                                    ListView(editid);
                                    swal("Deleted!", "Your record has been deleted.", "success");

                                }
                            });

                        });
                    }
                }


                // To delete data entry for Voucher type
                function DeleteEntry(editid, Dist) {
                    $("#lblError").hide();
                    if (Dist == null) {
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
                                url: "GenerateVouchers.aspx/DeleteVoucherWithCampaignbyId",
                                dataType: "json",
                                data: JSON.stringify({ 'GenId': editid }),
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
                }

</script>

</asp:Content>

