<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="VoucherCampaign.aspx.cs" Inherits="VoucherCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" runat="Server">
    <%--    <link href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet">--%>
    <link href="http://netdna.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <link href="css/editor.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="DataTable/jquery-1.12.3.min.js"> </script>
    <script src="js/editor.js"></script>

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
                <div class="col-sm-4">
                    <h4 class="text-primary">Voucher Campaign</h4>
                </div>
                <div class="col-sm-8 text-right">
                    <%if (canAdd)
                        { %>
                    <button type="button" class="btn btn-primary CreateBtn" onclick="CreateNew();">Create New</button>

                    <%} %>
                </div>
            </div>

        </div>
        <div class="clearfix"></div>
        <div class="panel-body">
            <div class="col-md-12">
                <table id="tblVoucherCampList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th class="col-md-2">Campaign Name</th>
                            <th class="col-md-1">Venue</th>
                            <th class="col-md-1">Brand</th>
                            <th class="col-md-1">Product</th>
                            <th class="col-md-1">StartDate</th>
                            <th class="col-md-1">EndDate</th>
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
                    <h4 class="modal-title">Voucher Campaign Master Form in
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
                                    <label class="control-label col-sm-4" for="ddlCampBrand">Brand:</label>
                                    <div class="col-sm-8">
                                        <select id="ddlCampBrand" class="select2 form-control" style="width: 100%">
                                            <option value="-1">--Select Brand--</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="ddlCampType">Venue:</label>
                                    <div class="col-sm-8">
                                        <select id="ddlCampType" class="select2 form-control" style="width: 100%">
                                            <option value="-1">--Select Venue--</option>
                                        </select>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="ddlCampCat">Type:</label>
                                    <div class="col-sm-8">
                                        <select id="ddlCampCat" class="select2 form-control" style="width: 100%">
                                            <option value="-1">--Select Type--</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtCampName">Campaign Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text" maxlength="100" class="form-control" id="txtCampName" name="txtCampName" placeholder="Campaign Name" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="ddlCouponVal">Product:</label>
                                    <div class="col-sm-8">

                                        <select id="ddlCouponValue" class="select2 form-control" style="width: 100%">
                                            <option value="-1">--Select Product--</option>
                                        </select>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtStartDate">Start Date:</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control datepicker" id="txtStartDate" name="txtStartDate" value="" required />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtEndDate">End Date:</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control datepicker" id="txtEndDate" name="txtEndDate" value="" required />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txthtmlEng">htmlEnglish:</label>
                                    <div class="col-sm-8">
                                        <div id="txtEngEditor"></div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="txthtmlFr">htmlFrench:</label>
                                    <div class="col-sm-8">
                                        <div id="txtFrEditor"></div>
                                    </div>
                                </div>

                                <div class="form-group" id="URL">
                                    <div class="form-group">
                                        <label class="control-label col-sm-4" for="txtURLENg">URLEnglish:</label>
                                        <div class="col-sm-8">
                                            <label class="control-label col-sm-8" style="text-align: left !important;" id="txtURLENg"></label>

                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-sm-4" for="txtURLFR">URLFrench:</label>
                                        <label class="control-label col-sm-8" style="text-align: left  !important;" id="txtURLFR"></label>

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
    <script src="Pages/VC.js"></script>
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
                        url: "VoucherCampaign.aspx/DeleteVoucherCampaignbyId",
                        dataType: "json",
                        data: JSON.stringify({ 'CampId': editid }),
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
            $("#tblVoucherCampList").dataTable().fnDestroy();
            $.ajax({
                type: "POST",
                url: "VoucherCampaign.aspx/GetVoucherCampaign",
                dataType: "json",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (msg) {
                    $('#tblVoucherCampList').dataTable({
                        "responsive": true, "autoWidth": false,
                        "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                        data: JSON.parse(msg.d),
                        columns: [
                            { data: "Id", "visible": false },
                            { data: "CampName" },
                            { data: "Code" },
                            { data: "BrandName" },
                            { data: "CouponValue" },
                            { data: "StartDate" },
                            { data: "EndDate" },
                            { data: "Status" },
                            {
                                data: 'Id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                    return '<%if (canEdit || canView)
        {%><a href="#" title="View" onclick="EditEntry(' + data.Id + ',1)"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canEdit)
        {%><a href="#" title="Edit" onclick="EditEntry(' + data.Id + ',0)"><img src="/imgs/icon_portal_edit.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canAppr)
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

