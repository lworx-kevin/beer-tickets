<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="CouponProductType.aspx.cs" Inherits="CouponProductType" %>

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
                    <h4 class="text-primary">Coupon Product Type</h4>
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
                <table id="tblCouponProTypeList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                         <th></th>
                            <th class="col-md-2">Product Code</th>
                            <th class="col-md-2">Product Type</th>
                            <th class="col-md-3">DB Product Code</th>

                            <th class="col-md-2">DB Product Name </th>

                            <th class="col-md-2">DB Hotel Name </th>
                            <th class="col-md-2">DB Hotel Chain </th>
                            <th class="col-md-2">DB Flight Number </th>
                            <th class="col-md-2">DB Airline Name </th>

                            <th class="col-md-2">DB Country Code </th>
                            <th class="col-md-2">DB Airport Code </th>
                            <th class="col-md-2">Status </th>

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
                    <h4 class="modal-title">Coupon Product Type Master Form in
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
                                    <label class="control-label col-sm-4"  for="txtProductCode">Product Code:</label>
                                    <div class="col-sm-8">
                                        <input type="text" maxlength="2" class="form-control" id="txtProductCode" onkeypress="return onlyAlphabets(event,this);"  name="txtProductCode" placeholder="Product Code" required>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="ddlProductType">Product Type:</label>
                                      <div class="col-sm-8">
                                        <input type="text" maxlength="50" class="form-control" id="txtProductType" onkeypress="return onlyAlphabets(event,this);"  name="txtProductType" placeholder="Product Type" required>
                                          
                                      </div>
                                </div>

                                <div id="HiddenView">

                                 <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBUsername">DB Username:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBUsername"  name="txtDBUsername" placeholder="DB Username" required>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBPwd">DB Password:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBPwd"  name="txtDBPwd" placeholder="DB Password" required>
                                    </div>
                                </div>


                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBName">DB Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBName"  name="txtDBName" placeholder="DB Name" required>
                                    </div>
                                </div>

                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBTableName">DB Table Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBTableName"  name="txtDBTableName" placeholder="DB Table Name" required>
                                    </div>
                                </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBProductCode">DB Product Code:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBProductCode"  name="txtDBProductCode" placeholder="DB Product Code" required>
                                    </div>
                                </div>

                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBProductName">DB Product Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBProductName"  name="txtDBProductName" placeholder="DB Product Name" required>
                                    </div>
                                </div>

                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBHotelName">DB Hotel Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBHotelName"  name="txtDBHotelName" placeholder="DB Hotel Name" required>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBHotelChain">DB Hotel Chain:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBHotelChain"  name="txtDBHotelChain" placeholder="DB Hotel Chain" required>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBFlightNumber">DB Flight Number:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBFlightNumber"  name="txtDBFlightNumber" placeholder="DB Flight Number" required>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBAirlineName">DB Airline Name:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBAirlineName"  name="txtDBAirlineName" placeholder="DB Airline Name" required>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBCountryCode">DB Country Code:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBCountryCode"  name="txtDBCountryCode" placeholder="DB Country Code" required>
                                    </div>
                                </div>

                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBAirportCode">DB Airport Code:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBAirportCode"  name="txtDBAirportCode" placeholder="DB Airport Code" required>
                                    </div>
                                </div>                                 
                                 <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBStatusCode">DB Status Code:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBStatusCode"  name="txtDBStatusCode" placeholder="DB Status Code" required>
                                    </div>
                                </div>                                
                                  <div class="form-group">
                                    <label class="control-label col-sm-4" for="txtDBStatusValue">DB Status Value:</label>
                                    <div class="col-sm-8">
                                        <input type="text"  class="form-control" id="txtDBStatusValue"  name="txtDBStatusValue" placeholder="DB Status Value" required>
                                    </div>
                                </div>
                               
                                 






                                 <div class="form-group" id="StatusShow">
                                    <label class="control-label col-sm-4"  for="chkStatus"><label id="lblStatusText" ></label>:</label>
                                    <div class="col-sm-8">
<%--                                        <div class="checkbox-container">
                                            <input type="checkbox" id="on-off-switch" name="chkStatus" checked>
                                        </div>--%>
                                     
                                    <div id="lblSwitch" class="make-switch switch-small"  >
                                        <input type="checkbox" name="chkStatus"  data-on-text="Approved" data-off-text="Pending" checked />
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

    <script src="Pages/PType.js"></script>


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
                        url: "CouponProductType.aspx/DeleteCouponProductTypeDataById",
                        dataType: "json",
                        data: JSON.stringify({ 'ProductId': editid }),
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

                $("#tblCouponProTypeList").dataTable().fnDestroy();
                $.ajax({
                    type: "POST",
                    url: "CouponProductType.aspx/GetCouponProductTypeData",
                    dataType: "json",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $('#tblCouponProTypeList').dataTable({
                            "responsive": true, "autoWidth": false,
                            "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                            data: JSON.parse(msg.d),
                            columns: [
                                    { data: "Id", "visible": false },
                                  { data: "ProductCode" },
                                  { data: "ProductType" },
                                   { data: "dbProductCode" },
                                   { data: "dbProductName" },


                                  { data: "dbHotelName" },
                                  { data: "dbHotelChain" },
                                   { data: "dbFlightNumber" },
                                   { data: "dbAirlineName" },

                                                                  
                                  { data: "dbCountryCode" },
                                   { data: "dbAirportCode" },
                                     { data: "Status" },

                              
                                          {
                                              data: 'Id', "bSearchable": true, "bSortable": true, "mRender": function (data, type, data) {
                                                  return '<%if (canEdit||canView){%><a href="#" title="View" onclick="EditEntry(' + data.Id + ',1)"><img src="/imgs/icon_portal_view.png" class="actionIcon"/></a>&nbsp;<%}%><%if (canEdit)
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
