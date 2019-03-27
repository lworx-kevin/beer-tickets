//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#lblError").hide();
    $('#StatusShow').show();
    $('#lblStatusText').show();

    var $select = $('#lblStatusText');
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
    $("#txtProductName").val('');
    $("#txtProductCode").val('');
    $("#ddlProductType").val(0).trigger('change');
    //$("#drpStatus").val(0);
    $("#dverror").empty();

    $('#mdlCreate').modal('show');
}

function ValidateCoupon(editid, view) {

    $("#lblError").hide();
    var $select = $('#lblStatusText');
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
        url: "CouponProducts.aspx/GetCouponProductDataById",
        dataType: "json",
        data: JSON.stringify({ 'ProductId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);

            $("#txtProductName").val(json[0].ProductName);
            $("#txtProductCode").val(json[0].ProductCode);
            $("#ddlProductType").val(json[0].ProductType).trigger('change');

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
        $("#lblentrymode").html("Modify");
        $("#frmMaster :input").prop("disabled", false);
        $select.hide();
        $('#StatusShow').hide();
        $("#btnSubmit").show();
        $("#EntryMode").val('Edit');
        $("#mdlCreate").attr("data-edit", "edit");


    }
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $select.text('Status');

    var json;
    $.ajax({
        type: "POST",
        url: "CouponProducts.aspx/GetCouponProductDataById",
        dataType: "json",
        data: JSON.stringify({ 'ProductId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);

            $("#txtProductName").val(json[0].ProductName);
            $("#txtProductCode").val(json[0].ProductCode);
            $("#ddlProductType").val(json[0].ProductType).trigger('change');

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
    var ProductName = $("#txtProductName").val().trim();
    var ProductCode = $("#txtProductCode").val().trim();
    var ProductType = $("#ddlProductType").val();
    var Status = $("[name='chkStatus']").prop('checked') == true ? 1 : 0;



    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {

            url = 'CouponProducts.aspx/InsertCouponProductData';
            var CouponProduct = {
                'ProductName': ProductName,
                'ProductCode': ProductCode,
                'ProductType': ProductType,
                'Status': Status,
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }
        else if (Action == 'edit') {

            url = 'CouponProducts.aspx/InsertCouponProductData';
            var CouponProduct = {
                'ProductName': ProductName,
                'ProductCode': ProductCode,
                'ProductType': ProductType,
                'Status': '0',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }
        else {

            url = 'CouponProducts.aspx/InsertCouponProductData';
            var CouponProduct = {
                'ProductName': ProductName,
                'ProductCode': ProductCode,
                'ProductType': ProductType,
                'Status': Status,
                'Id': 0,
                'Action': 'Add'
            };
        }



        var dataToSend = JSON.stringify({ 'CouponProduct': CouponProduct });

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
                        message: 'Product Identifier must be unique.'
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
        $("#lblError").html("Please enter value for Product Name and Product Code.");
    }
    waitingDialog.hide();

}
// To validate data entry for coupon type
function Validate() {
    if ($("#txtProductName").val().toString().trim() == '' || $("#txtProductCode").val().toString().trim() == '') {
        $("#lblError").show();
        return false;
    }
    return true;


}
function BindDropdown() {

    //Bind Coupon Category
    $cb = $("#ddlProductType");
    $.ajax({
        type: "POST",
        url: "CouponProductType.aspx/GetCouponProductTypeData",
        dataType: "json",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (msg) {
            json = JSON.parse(msg.d);
            $cb.empty();
            $cb.append("<option value=0>--Select Product Type--</option>");
            for (var i = 0; i < json.length ; i++) {
                $cb.append("<option value=" + json[i].Id + ">" + json[i].ProductCode + "</option>").trigger('change');
            }
        }
    });

}
$(document).ready(function () {
    $("#lblError").hide();
    BindTable();
    BindDropdown();
});

