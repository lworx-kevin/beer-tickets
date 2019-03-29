<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="Vouchers.aspx.cs" Inherits="Vouchers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" runat="Server">

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
                    <h4 class="text-primary">Voucher Master</h4>
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
                            <th class="col-md-2">Voucher Id</th>
                            <th class="col-md-2">First Name</th>
                            <th class="col-md-2">Last Name</th>
                            <th class="col-md-2">Product</th>
                            <th class="col-md-1">Status</th>
                            <th class="col-md-1">Actions</th>
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


    <div id="mdlCreate" class="modal fade" data-id="-1" data-edit="Add" data-toggle="modal"
        role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Voucher Master Form in
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
                                    <label class="control-label col-sm-4" for="txtFirstName">First Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text" maxlength="100" class="form-control" id="txtFirstName" name="txtFirstName" placeholder="First Name" required>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtLastName">Last Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text" maxlength="100" class="form-control" id="txtLastName" name="txtLastName" placeholder="Last Name" required>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtAmount">Product:</label>
                                    <div class="col-sm-8">
                                        <input type="text" maxlength="100" class="form-control NumericOnly" id="txtAmount" name="txtAmount" placeholder="Product" required>
                                    </div>
                                </div>                             
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtExpiryDate">Expiry Date:</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control datepicker" id="txtExpiryDate" name="txtExpiryDate" value="" required />
                                    </div>
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
                                <div id="VoucherBlock">
                                    <div id="IssueDate">
                                        <label class="control-label col-sm-4">Issue Date:</label>
                                        <div class="col-sm-8">
                                            <label class="form-control" id="lblIssueDate"></label>
                                        </div>
                                    </div>
                                    <div id="UseDate">
                                        <label class="control-label col-sm-4">Use Date:</label>
                                        <div class="col-sm-8">
                                            <label class="form-control" id="lblUseDate"></label>
                                        </div>
                                    </div>
                                    <div id="UseProduct">
                                        <label class="control-label col-sm-4">Use Product:</label>
                                        <div class="col-sm-8">
                                            <label class="form-control" id="lblUseProduct"></label>
                                        </div>
                                    </div>
                                    <div id="UseRezId">
                                        <label class="control-label col-sm-4">Use Reservation Id:</label>

                                        <div class="col-sm-8">
                                            <label class="form-control" id="lblRezId"></label>
                                        </div>
                                    </div>
                                    <div id="UseSaleAmt">
                                        <label class="control-label col-sm-4">Use Sale Amount:</label>
                                        <div class="col-sm-8">
                                            <label class="form-control" id="lblSaleAmt"></label>
                                        </div>
                                    </div>
                                    <div id="UseTaxes">
                                        <label class="control-label col-sm-4">Use Taxes Included:</label>

                                        <div class="col-sm-8">
                                            <label class="form-control" id="lblUseTaxes"></label>
                                        </div>
                                    </div>
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
                    </form>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctlscript" runat="Server">
    <script src="Pages/VO.js"></script>

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
                        url: "Vouchers.aspx/DeleteVoucherbyId",
                        dataType: "json",
                        data: JSON.stringify({ 'VoucherId': editid }),
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



        // Bind Voucher Type Listing
        function BindTable() {

            $("#tblVoucherList").dataTable().fnDestroy();
            $.ajax({
                type: "POST",
                url: "Vouchers.aspx/GetVouchers",
                dataType: "json",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (msg) {
                    $('#tblVoucherList').dataTable({
                        "responsive": true, "autoWidth": false, enableSorting: true, "bSortable": true,
                        "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                        data: JSON.parse(msg.d),
                        columns: [



                            { data: "Id", "visible": false },
                            { data: "VoucherId" },
                            { data: "FirstName" },
                            { data: "LastName" },
                            { data: "VoucherAmount" },
                            { data: "Status" },
                            {
                                data: 'Id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                    return '<%if (canEdit || canView)
        {%><a href="#" title="View" onclick="EditEntry(' + data.Id + ',1)"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canEdit)
        {%><a href="#" title="Edit" onclick="EditEntry(' + data.Id + ',0)"><img src="/imgs/icon_portal_edit.png" class="actionIcon"/></a>&nbsp;<%}%> <%if (canAppr)
        {%><a href="#" title="Approve" onclick="ValidateVoucher(' + data.Id + ',2)"><img src="/imgs/Validate.png" class="actionIcon"/></a>&nbsp;<%}%> <%if (canDelete)
        {%><a href="#" title="Delete" onclick="DeleteEntry(' + data.Id + ')"><img src="/imgs/icon_portal_delete.png" class="actionIcon"/></a><%}%> ';
                                }
                            },


                        ]


                    });
                }
            });
        }



    </script>
</asp:Content>

