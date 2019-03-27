<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="VCReport.aspx.cs" Inherits="VCReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
        <link href="css/Report.css" rel="stylesheet">
    <script src="js/JSDownloadCSVjs.js" type="text/javascript"></script>

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
                    <h4 class="text-primary">Voucher Campaign Reporting</h4>
                </div>
                
            </div>
        </div>
        <br /><br />
        <div class="panel-Report">
            <div class="row">
                 <div class="col-sm-12">
                <div class="form-group">
                    <div class="col-lg-4">
                        <label class="control-label " for="txtReportDate">
                            Campaign

:</label>
                        <select id="ddlCampaign" multiple="multiple">
                        </select>

                    </div>




                </div>
</div>
            </div>
            <br />

            <div class="row">

                    <div class="col-lg-4">
                        <div class="dvReport FRight">
                            <button type="button" class="btn btn-primary" onclick="FilterReport();">Filter Report</button>
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
   

    <table id="tblVCReport" style="width:250%;" >
         <thead>


        <tr>
        <th>Campaign Name</th>
        <th>Type</th>
        <th>Funding</th>
        <th>Category</th>
        <th>Brand</th>
        <th>Date of Issue</th>
        <th>Date of Expiry</th>
        <th>Dollar Value</th>
        <th class="col-lg-1">Total Voucher Issued</th>
        <th class="col-lg-1">Total Voucher Used</th>
        <th class="col-lg-1">Total Booking Value</th>
        <th class="col-lg-1">Average Booking Value</th>
        <th>Date Of Use</th>
        <th>Booking Number</th>
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

    <div class="col-sm-4">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctlscript" Runat="Server">




        <script type="text/javascript">

            // Bind Coupon Type Listing\

            function FilterReport()
            {
                var SelectedCampaign = $("#ddlCampaign").val() == null ? 0 : $("#ddlCampaign").val();
                BindTable(SelectedCampaign.toString());

            }

            function BindTable(SelectedCampaign) {
                
                $("#tblVCReport").dataTable().fnDestroy();
                $.ajax({
                    type: "POST",
                    url: "VCReport.aspx/GetVCReportData",
                    dataType: "json",
                    data:JSON.stringify({ 'SelectedCampaign': SelectedCampaign }),
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $('#tblVCReport').dataTable({
                            "responsive": false,   "scrollY": true, "scrollX": true,"overflow":"scroll","width":"1900px",
 
                            "lengthMenu": [[50, 100, 150, -1], [50, 100, 150, "All"]],
                            data: JSON.parse(msg.d),
                            columns: [
                    { data: "CampaignName"},
                    { data: "Type" },
                    { data: "Funding", "class": "RJustify" },
                    { data: "Category" },
                    { data: "Brand" },
                    { data: "DateofIssue" },
                     { data: "DateofExpiry" },
                    { data: "DollarValue", "class": "RJustify" },
                    { data: "TotalVoucherIssued", "class": "RJustify" },
                    { data: "TotalVoucherUsed", "class": "RJustify" },
                            { data: "TotalBookingValue", "class": "RJustify" },
                    { data: "AverageBookingValue", "class": "RJustify" },
                    { data: "DateOfUse" },
                            { data: "BookingNumber"},
                    { data: "BookingValue", "class": "RJustify" }
                              

                ]


            });
        }
    });
                  }

            $(document).ready(function () {


                function exportTableToCSV($table, filename) {
                    var $headers = $table.find('tr:has(th)')
                        , $rows = $table.find('tr:has(td)')
                        // Temporary delimiter characters unlikely to be typed by keyboard
                        // This is to avoid accidentally splitting the actual contents
                        , tmpColDelim = String.fromCharCode(11) // vertical tab character
                        , tmpRowDelim = String.fromCharCode(0) // null character
                        // actual delimiter characters for CSV format
                        , colDelim = '","'
                        , rowDelim = '"\r\n"';
                    // Grab text from table into CSV formatted string
                    var csv = '"';
                    csv += formatRows($headers.map(grabRow));
                    csv += rowDelim;
                    csv += formatRows($rows.map(grabRow)) + '"';
                    // Data URI
                    var csvData = 'data:application/csv;charset=utf-8,' + encodeURIComponent(csv);
                    $(this)
                        .attr({
                            'download': filename
                            , 'href': csvData
                            //,'target' : '_blank' //if you want it to open in a new window
                        });
                    //------------------------------------------------------------
                    // Helper Functions 
                    //------------------------------------------------------------
                    // Format the output so it has the appropriate delimiters
                    function formatRows(rows) {
                        return rows.get().join(tmpRowDelim)
                            .split(tmpRowDelim).join(rowDelim)
                            .split(tmpColDelim).join(colDelim);
                    }
                    // Grab and format a row from the table
                    function grabRow(i, row) {

                        var $row = $(row);
                        //for some reason $cols = $row.find('td') || $row.find('th') won't work...
                        var $cols = $row.find('td');
                        if (!$cols.length) $cols = $row.find('th');
                        return $cols.map(grabCol)
                                    .get().join(tmpColDelim);
                    }
                    // Grab and format a column from the table 
                    function grabCol(j, col) {
                        var $col = $(col),
                            $text = $col.text();
                        return $text.replace('"', '""'); // escape double quotes
                    }
                }

                function BindDropdown()
                {
                    // Bind Voucher Brand
                    var $b = $('#ddlCampaign');
                    $.ajax({
                        type: "POST",
                        url: "Vouchers.aspx/GetVoucherCampaign",
                        dataType: "json",
                        data: "{}",
                        contentType: "application/json; charset=utf-8",
                        async: true,
                        cache: false,
                        success: function (msg) {

                            json = JSON.parse(msg.d);
                            $b.empty();



                            for (var i = 0; i < json.length ; i++) {
                                $b.append("<option value=" + json[i].Id + ">" + json[i].CampaignName + "</option>").trigger('change');
                            }
                            $b.multiselect('rebuild');

                            //$b.append("<option value=0>--Select Product--</option>");
                            //for (var i = 0; i < json.length ; i++) {
                            //    $b.append("<li value=" + json[i].Id + ">" + json[i].ProductName + "</li>").trigger('change');
                            // }
                        }
                    });
                }

                      // This must be a hyperlink
                      $(".export").on('click', function (event) {
                          // CSV
                          var args = [$('#tblVCReport'), 'export.csv'];

                          exportTableToCSV.apply(this, args);

                          // If CSV, don't do event.preventDefault() or return false
                          // We actually need this to be a typical hyperlink
                      });
                    
                      BindTable(0);
                      BindDropdown();
                  });
</script>
</asp:Content>



























