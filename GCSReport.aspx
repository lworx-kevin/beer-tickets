<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="GCSReport.aspx.cs" Inherits="GCSReport" %>


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
                    <h4 class="text-primary">Gift Certificates Sold Reporting</h4>
                </div>
                
            </div>
        </div>
        <br /><br />
        <div class="panel-Report" id="Report">
            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">
                        <div class="row">

                            <div class="col-lg-5">
                                <label class="control-label " for="txtStartDate">
                                    Sales From Date:</label>

                                <input type="text" class="datepicker" id="txtStartDate" name="txtStartDate" value="" />

                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-5">
                            <label class="control-label " for="txtEndDate">Sales Until Date:</label>
                          
                                <input type="text" class="datepicker" id="txtEndDate" name="txtEndDate" value=""   />
                           
                        </div>
                        </div>
                        <br />
                        <div class="row">
                        <div class="col-lg-5">
                            <div class="dvReport">
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
   

    <table id="tblGCSReport" style="width:150%;" >

         <thead>


        <tr>
        <th>GC Number</th>
        <th  class="col-lg-2">Customer Last Name</th>
        <th  class="col-lg-2">Customer First Name</th>
        <th>Date of Issue</th>
        <th>Date of Expiry</th>
        <th class="col-sm-2">Dollar Value Issued</th>
        <th class="col-sm-2">Dollar Value Remaining</th>
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

                var StartDate = $("#txtStartDate").val() == "" || $("#txtStartDate").val() == null ? "0" : $("#txtStartDate").val().toString();
                var EndDate = $("#txtEndDate").val() == "" || $("#txtEndDate").val() == null ? "0" : $("#txtEndDate").val().toString();
                var GCSParams = {
                    'StartDate': StartDate,
                    'EndDate': EndDate
                }
                BindTable(GCSParams);

            }

            function BindTable(GCSParams) {

                $("#tblGCSReport").dataTable().fnDestroy();
                $.ajax({
                    type: "POST",
                    url: "GCSReport.aspx/GetGCSReportData",
                    dataType: "json",
                    data: JSON.stringify({ 'GCSParams': GCSParams }),
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $('#tblGCSReport').dataTable({
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
                            { data: "DollarValueRemaining", "class": "RJustify" },


                            ]


                        });
                    }
                });
            }

            $(document).ready(function () {



                // This must be a hyperlink
                $(".export").on('click', function (event) {
                    // CSV
                    var args = [$('#tblGCSReport'), 'export.csv'];

                    exportTableToCSV.apply(this, args);

                    // If CSV, don't do event.preventDefault() or return false
                    // We actually need this to be a typical hyperlink
                });

                var GCSParams = {
                    'StartDate': '0',
                    'EndDate': '0',
                }
                BindTable(GCSParams);
                BindDropdown();
            });
</script>
</asp:Content>

