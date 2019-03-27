<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="GCOReport.aspx.cs" Inherits="GCOReport" %>


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
                    <h4 class="text-primary">Gift Certificates Outstanding Reporting</h4>
                </div>
                
            </div>
        </div>
        <br /><br />
        <div class="panel-Report" id="Report">
            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">

                        <div class="row">

                            <div class="col-lg-6">
                                <label class="control-label " for="txtReportDate">Outstanding as of Date:</label>

                                <input type="text" class="datepicker" id="txtReportDate" name="txtReportDate" value="" />

                            </div>
                        </div>
                        <br />
                        <div class="row">
                        <div class="col-lg-6">
                            <div class="dvReport ">
                                    <button type="button" class="btn btn-primary" onclick="FilterReport();">Filter Report</button>
                            </div>
                        </div>
                        
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
   

                    <table id="tblGCOReport" style="width:150%;">

                        <thead>


                            <tr >
                                <th>GC Number</th>
                                <th  class="col-lg-2">Customer Last Name</th>
                                <th  class="col-lg-2">Customer First Name</th>
                                <th class="col-sm-2">Date of Issue</th>
                                <th class="col-sm-2">Date of Expiry</th>
                                <th class="col-sm-2">Dollar Value Issued</th>
                                <th class="col-sm-2">Dollar value OutStanding</th>
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

                var ReportDate = $("#txtReportDate").val() == "" || $("#txtReportDate").val() == null ? "0" : $("#txtReportDate").val().toString();
                var GCOParams = {
                    'ReportDate': ReportDate
                }
                BindTable(GCOParams);

            }

            function BindTable(GCOParams) {

                $("#tblGCOReport").dataTable().fnDestroy();
                $.ajax({
                    type: "POST",
                    url: "GCOReport.aspx/GetGCOReportData",
                    dataType: "json",
                    data: JSON.stringify({ 'GCOParams': GCOParams }),
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $('#tblGCOReport').dataTable({
                            "responsive": false, "scrollY": true, "scrollX": true, "overflow": "scroll",

                            "lengthMenu": [[50, 100, 150, -1], [50, 100, 150, "All"]],
                            data: JSON.parse(msg.d),
                            columns: [
                            { data: "GCNumber" },
                            { data: "CustomerFirstName" },
                            { data: "CustomerLastName" },
                            { data: "DateOfIssue" },
                            { data: "DateOfExpiry" },
                            { data: "DollarValueIssue", "class": "RJustify" },
                            { data: "DollarValueOutstanding", "class": "RJustify" },


                            ]


                        });
                    }
                });
            }

            $(document).ready(function () {




                // This must be a hyperlink
                $(".export").on('click', function (event) {
                    // CSV
                    var args = [$('#tblGCOReport'), 'export.csv'];

                    exportTableToCSV.apply(this, args);

                    // If CSV, don't do event.preventDefault() or return false
                    // We actually need this to be a typical hyperlink
                });

                var GCOParams = {
                    'ReportDate': '0',
                }
                BindTable(GCOParams);
            });
</script>
</asp:Content>


