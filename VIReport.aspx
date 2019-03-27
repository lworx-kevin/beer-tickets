<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="VIReport.aspx.cs" Inherits="VIReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
        <link href="css/Report.css" rel="stylesheet">

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
                    <h4 class="text-primary">Vouchers Issued Reporting</h4>
                </div>
                
            </div>
        </div>
        <br /><br />
        <div class="panel-Report" id="Report">
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <div class="row">
                             <div class="col-lg-3">
                                <label class="control-label " for="txtStartDate">Category:</label>
                             </div>
                            <div class="col-lg-4">
                                

                                <select id="ddlCategory" multiple="multiple">
                                </select>

                            </div>
                        </div>
                       <br />
                        <div class="row">
                             <div class="col-lg-3">
                               <label class="control-label " for="txtStartDate">Issued From Date:</label>
                             </div>
                        <div class="col-lg-4">
                            
                           
                                <input type="text" class="datepicker" id="txtStartDate" name="txtStartDate" value=""   />
                            
                        </div>
                       
                            </div>
                        <br />
                         <div class="row">
                               <div class="col-lg-3">
                              <label class="control-label " for="txtEndDate">Issued Until Date:</label>
                             </div>
                         <div class="col-lg-4">
                           
                          
                                <input type="text" class="datepicker" id="txtEndDate" name="txtEndDate" value=""   />
                           
                        </div>
                              </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-12">
                              
                                <div class="col-lg-6">
                                    <div class="dvReport ">
                                        <button type="button" class="btn btn-primary" onclick="FilterReport();">Filter Report</button>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            </div>
                    </div>


                </div>
            </div>
        </div>



         <div class="panel-body">
            <div style="width:100%;" >
<%--                <div  class="col-md-8">

                </div>
                <div id="dvExport" class="col-sm-3">
                    <a href="#" class="export">Export To CSV</a>
                </div>--%>
                <div class="row">
                    <div class='col-lg-12 pull-right'>
            <div class='dvReport SetPos'><a href='#' class='export'>Download CSV</a></div>
        </div>
                </div>
                <br /><br />
                <div id="dvData">
   

    <table id="tblVIReport" style="width:180%;" >

         <thead>


        <tr>
        <th>Voucher Number</th>
        <th>Customer Last Name</th>
        <th>Customer First Name</th>
        <th >Date of Issue</th>
        <th>Date of Expiry</th>
        <th>Date of Use</th>
        <th>Booking Number</th>
        <th  class="col-lg-1">Dollar Value Issued</th>
        <th>Booking Value</th>
        </tr>
              </thead>
                    <tbody></tbody>
    </table>
</div>     
            </div>

        </div>


        <script>
            var currPage = "module<%=moduleId%>";
        </script>
    </div>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctlscript" Runat="Server">
        <script src="js/JSDownloadCSVjs.js" type="text/javascript"></script>




        <script type="text/javascript">

            // Bind Coupon Type Listing\

            function FilterReport() {
                
                var SelectedCCategory = $("#ddlCategory").val() == "" || $("#ddlCategory").val() == null ? "0" : $("#ddlCategory").val().toString();
                var StartDate = $("#txtStartDate").val() == "" || $("#txtStartDate").val() == null ? "0" : $("#txtStartDate").val().toString();
                var EndDate = $("#txtEndDate").val() == "" || $("#txtEndDate").val() == null ? "0" : $("#txtEndDate").val().toString();
                var VIParams = {
                    'StartDate': StartDate,
                    'EndDate': EndDate,
                    'VoucherCategory': SelectedCCategory,
                }
                BindTable(VIParams);

            }

            function BindTable(VIParams) {
                
                $("#tblVIReport").dataTable().fnDestroy();
                $.ajax({
                    type: "POST",
                    url: "VIReport.aspx/GetVIReportData",
                    dataType: "json",
                    data: JSON.stringify({ 'VIParams': VIParams }),
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $('#tblVIReport').dataTable({
                            "responsive": false, "scrollY": true, "scrollX": true, "overflow": "scroll",

                            "lengthMenu": [[50, 100, 150, -1], [50, 100, 150, "All"]],
                            data: JSON.parse(msg.d),
                            columns: [
                            { data: "VoucherNumber" },
                            { data: "CustomerFirstName" },
                            { data: "CustomerLastName" },
                            { data: "DateOfIssue" },
                            { data: "DateOfExpiry" },
                             { data: "DateofUse" },
                            { data: "BookingNumber" },
                            { data: "DollarValueIssue", "class": "RJustify" },
                            { data: "BookingValue", "class": "RJustify" }


                            ]


                        });
                    }
                });
            }

            $(document).ready(function () {


                function BindDropdown() {
                    // Bind Voucher Brand
                    var $cb = $('#ddlCategory');
                    $.ajax({
                        type: "POST",
                        url: "VoucherCampaign.aspx/GetCouponCategoryData",
                        dataType: "json",
                        data: "{}",
                        contentType: "application/json; charset=utf-8",
                        async: true,
                        cache: false,
                        success: function (msg) {


                            json = JSON.parse(msg.d);
                            $cb.empty();



                            for (var i = 0; i < json.length ; i++) {
                                $cb.append("<option value=" + json[i].Id + ">" + json[i].Category + "</option>").trigger('change');
                            }
                            $cb.multiselect('rebuild');

                        }
                    });
                }

                // This must be a hyperlink
                $(".export").on('click', function (event) {
                    // CSV
                    var args = [$('#tblVIReport'), 'export.csv'];

                    exportTableToCSV.apply(this, args);

                    // If CSV, don't do event.preventDefault() or return false
                    // We actually need this to be a typical hyperlink
                });

                var VIParams = {
                    'StartDate': '0',
                    'EndDate': '0',
                    'VoucherCategory': '0',
                }
                BindTable(VIParams);
                BindDropdown();
            });
</script>
</asp:Content>
