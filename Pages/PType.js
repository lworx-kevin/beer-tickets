//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#lblError").hide();
    $('#lblStatusText').show();
    $('#HiddenView').show();

    var $select = $('#lblStatusText');
    // New added for NStatus
    $select.text("Status");
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);

    $("[name='chkStatus']").bootstrapSwitch('state', false);
    $("[name='chkStatus']").bootstrapSwitch('disabled', true);


    $('#StatusShow').show();
    $("#btnSubmit").show();
    $("#frmMaster :input").prop("disabled", false);
    $("#lblentrymode").html("Create");
    $("#EntryMode").val('Add');
    $("#mdlCreate").attr("data-edit", "Add");
    $("#mdlCreate").attr("data-id", 0);
    $("#txtProductCode").val('');
    $("#txtProductType").val('');
    $("#txtDBUsername").val('');
    $("#txtDBPwd").val('');
    $("#txtDBName").val('');
    $("#txtDBTableName").val('');
    $("#txtDBProductCode").val('');
    $("#txtDBProductName").val('');
    $("#txtDBHotelName").val('');
    $("#txtDBHotelChain").val('');
    $("#txtDBFlightNumber").val('');
    $("#txtDBAirlineName").val('');
    $("#txtDBCountryCode").val('');
    $("#txtDBAirportCode").val('');
    $("#txtDBStatusCode").val('');
    $("#txtDBStatusValue").val('');
    $("#txtStatus").val('');
    //$("#drpStatus").val(0);
    $("#dverror").empty();

    $('#mdlCreate').modal('show');
}

function ValidateCoupon(editid, view) {
    $("#frmMaster :input").prop("disabled", false);
    $('#HiddenView').show();
    $("#lblError").hide();
    var $select = $('#lblStatusText');
    // New added for NStatus

    $select.text("Status");
    $select.show();

    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $('#StatusShow').show();
    $("#lblentrymode").html("Promote");
    $("#frmMaster :input").prop("disabled", false);

    $("#btnSubmit").show();

    //$("#lblentrymode").html("Modify");
    $("#dverror").empty();
    $("#EntryMode").val('Promote');
    $("#mdlCreate").attr("data-edit", "validate");
    $("#mdlCreate").attr("data-id", editid);

    var json;
    $.ajax({
        type: "POST",
        url: "CouponProductType.aspx/GetCouponProductTypeDataById",
        dataType: "json",
        data: JSON.stringify({ 'ProductId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);


            $("#txtProductCode").val(json[0].ProductCode);
            $("#txtProductType").val(json[0].ProductType);

            $("#txtDBPwd").val(json[0].dbPwd);
            $("#txtDBName").val(json[0].dbName);

            $("#txtDBUsername").val(json[0].dbUser);
            $("#txtDBTableName").val(json[0].dbTable);
            $("#txtDBProductCode").val(json[0].dbProductCode);
            $("#txtDBProductName").val(json[0].dbProductName);
            $("#txtDBHotelName").val(json[0].dbHotelName);
            $("#txtDBHotelChain").val(json[0].dbHotelChain);
            $("#txtDBFlightNumber").val(json[0].dbFlightNumber);
            $("#txtDBAirlineName").val(json[0].dbAirlineName);
            $("#txtDBCountryCode").val(json[0].dbCountryCode);
            $("#txtDBAirportCode").val(json[0].dbAirportCode);
            $("#txtDBStatusCode").val(json[0].dbStatusCode);
            $("#txtDBStatusValue").val(json[0].dbStatusValue);









            // $('select[name="drpStatus"]').find('option[value="' + json[0].Status + '"]').attr("selected", true);

            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);

        }

    });
    $('#mdlCreate').modal('show');
}

//When edit/view is Clicked
function EditEntry(editid, view) {


    $("#lblError").hide();
    var $select = $('#lblStatusText');


    if (view == 1) {
        $('#HiddenView').hide();
        $("#lblentrymode").html("View");
        $("#frmMaster :input").prop("disabled", true);
        $("#btnSubmit").hide();
        $select.show();
        $('#StatusShow').show();
        $("#btnCancel").prop("disabled", false)
        $("#mdlCreate").attr("data-edit", "view");
        $("#btnCancel").html("Close");
    }
    else {
        $('#HiddenView').show();
        $("#lblentrymode").html("Modify");
        $("#frmMaster :input").prop("disabled", false);
        $select.hide();
        $('#StatusShow').hide();
        $("#btnSubmit").show();
        $("#EntryMode").val('Edit');
        $("#mdlCreate").attr("data-edit", "edit");


    }

    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    // New added for NStatus

    $select.text('Status');

    var json;
    $.ajax({
        type: "POST",
        url: "CouponProductType.aspx/GetCouponProductTypeDataById",
        dataType: "json",
        data: JSON.stringify({ 'ProductId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {
            debugger;
            json = JSON.parse(res.d);


            $("#txtProductCode").val(json[0].ProductCode.trim());
            $("#txtProductType").val(json[0].ProductType.trim());
            $("#txtDBUsername").val(json[0].dbUser.trim());
            $("#txtDBPwd").val(json[0].dbPwd.trim());
            $("#txtDBName").val(json[0].dbName.trim());
            $("#txtDBTableName").val(json[0].dbTable.trim());
            $("#txtDBProductCode").val(json[0].dbProductCode.trim());
            $("#txtDBProductName").val(json[0].dbProductName.trim());
            $("#txtDBHotelName").val(json[0].dbHotelName.trim());
            $("#txtDBHotelChain").val(json[0].dbHotelChain.trim());
            $("#txtDBFlightNumber").val(json[0].dbFlightNumber.trim());
            $("#txtDBAirlineName").val(json[0].dbAirlineName.trim());
            $("#txtDBCountryCode").val(json[0].dbCountryCode.trim());
            $("#txtDBAirportCode").val(json[0].dbAirportCode.trim());
            $("#txtDBStatusCode").val(json[0].dbStatusCode.trim());
            $("#txtDBStatusValue").val(json[0].dbStatusValue.trim());




            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);
            $("[name='chkStatus']").bootstrapSwitch('disabled', true);
        }

    });

    $('#mdlCreate').modal('show');

}



//When cancel is Clicked
function hideModel() {
    $("#lblError").hide();
    $('#mdlCreate .close').click();
}
// To save data entry for coupon type
function SaveEntry() {

    $("#lblError").hide();
    waitingDialog.show("Saving  Data Please Wait..");
    $.ajaxSetup({
        async: false
    });
    var ProductCode = $("#txtProductCode").val();
    var ProductType = $("#txtProductType").val();
    var dbUser = $("#txtDBUsername").val();
    var dbPwd = $("#txtDBPwd").val();
    var dbName = $("#txtDBName").val();
    var dbTable = $("#txtDBTableName").val();
    var dbProductCode = $("#txtDBProductCode").val();
    var dbProductName = $("#txtDBProductName").val();
    var dbHotelName = $("#txtDBHotelName").val();
    var dbHotelChain = $("#txtDBHotelChain").val();
    var dbFlightNumber = $("#txtDBFlightNumber").val();
    var dbAirlineName = $("#txtDBAirlineName").val();
    var dbCountryCode = $("#txtDBCountryCode").val();
    var dbAirportCode = $("#txtDBAirportCode").val();
    var dbStatusCode = $("#txtDBStatusCode").val();
    var DBStatusValue = $("#txtDBStatusValue").val();

    // var Status = $("#lblStatus").text()== 'Approved' ? $("#chkStatus").'  1 : 0;
    // New added for NStatus

    var Status = $("[name='chkStatus']").prop('checked') == true ? 1 : 0;


    var CatId = $("#CatId").val();
    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {

            url = 'CouponProductType.aspx/InsertCouponProductTypeData';
            var CouponProductType = {
                'ProductCode': ProductCode,
                'ProductType': ProductType,
                'dbUser': dbUser,
                'dbPwd': dbPwd,
                'dbName': dbName,
                'dbTable': dbTable,
                'dbProductCode': dbProductCode,
                'dbProductName': dbProductName,
                'dbHotelName': dbHotelName,
                'dbHotelChain': dbHotelChain,
                'dbFlightNumber': dbFlightNumber,
                'dbAirlineName': dbAirlineName,
                'dbCountryCode': dbCountryCode,
                'dbAirportCode': dbAirportCode,
                'dbStatusCode': dbStatusCode,
                'DBStatusValue': DBStatusValue,
                'Status': Status,
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }

        else if (Action == 'edit') {

            url = 'CouponProductType.aspx/InsertCouponProductTypeData';
            var CouponProductType = {
                'ProductCode': ProductCode,
                'ProductType': ProductType,
                'dbUser': dbUser,
                'dbPwd': dbPwd,
                'dbName': dbName,
                'dbTable': dbTable,
                'dbProductCode': dbProductCode,
                'dbProductName': dbProductName,
                'dbHotelName': dbHotelName,
                'dbHotelChain': dbHotelChain,
                'dbFlightNumber': dbFlightNumber,
                'dbAirlineName': dbAirlineName,
                'dbCountryCode': dbCountryCode,
                'dbAirportCode': dbAirportCode,
                'dbStatusCode': dbStatusCode,
                'DBStatusValue': DBStatusValue,
                'Status': '0',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }





        else {

            url = 'CouponProductType.aspx/InsertCouponProductTypeData';
            var CouponProductType = {
                'ProductCode': ProductCode,
                'ProductType': ProductType,
                'dbUser': dbUser,
                'dbPwd': dbPwd,
                'dbName': dbName,
                'dbTable': dbTable,
                'dbProductCode': dbProductCode,
                'dbProductName': dbProductName,
                'dbHotelName': dbHotelName,
                'dbHotelChain': dbHotelChain,
                'dbFlightNumber': dbFlightNumber,
                'dbAirlineName': dbAirlineName,
                'dbCountryCode': dbCountryCode,
                'dbAirportCode': dbAirportCode,
                'dbStatusCode': dbStatusCode,
                'DBStatusValue': DBStatusValue,
                'Status': Status,
                'Id': 0,
                'Action': 'Add'
            };
        }



        var dataToSend = JSON.stringify({ 'CouponProductType': CouponProductType });

        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            data: dataToSend,
            contentType: "application/json; charset=utf-8",
            async: true,
            cache: false,
            success: function (msg) {

                var data = eval(msg.d)
                if (data == 'Success') {
                    $('#mdlCreate .close').click();
                    BindTable();
                    $.notify({
                        title: '',
                        message: 'Record Saved Succesfully.'
                    }, { type: 'success' });
                }
                else if (data == 'Exist') {
                    $('#mdlCreate .close').click();
                    BindTable();
                    $.notify({
                        title: '',
                        message: 'Category Code must be unique.'
                    }, { type: 'warning' });
                }
                else {
                    $('#mdlCreate .close').click();

                    BindTable();
                    $.notify({
                        title: '',
                        message: 'An error has occured.'
                    }, { type: 'danger' });
                }
            }
        });
        $('#mdlCreate .close').click();
    }
    else {

    }
    waitingDialog.hide();

}



// To validate data entry for coupon type
function Validate() {






    if ($("#txtProductType").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for  Product Type.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtDBUsername").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for DB User.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtDBPwd").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for DB Password.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtDBName").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for DB Name.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtDBTableName").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for DB Table Name.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtDBProductCode").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for DB Product Code.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtDBStatusCode").val().toString().trim().length > 0) {

        if ($("#txtDBStatusValue").val().toString().trim() == '') {
            $("#lblError").html("Status value must be entered for Status Code");
            $("#lblError").show();
            return false;

        }

    }

    return true;
}
function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8 || charCode == 46)
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}


$(document).ready(function () {
    $("#lblError").hide();
    BindTable();
    $(function () {
        $('.NumericOnly').keydown(function (e) {
            if (e.shiftKey || e.ctrlKey || e.altKey) {
                e.preventDefault();
            } else {
                var key = e.keyCode;
                if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
                    e.preventDefault();
                }

            }
        });
    });

});
