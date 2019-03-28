//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#lblError").hide();
    $('#StatusShow').show();
    $('#lblStatusText').show();

    var $select = $('#lblStatusText');
    $select.text("WAITING");
    $("[name='chkStatus']").bootstrapSwitch('state', true);
    $("[name='chkStatus']").bootstrapSwitch('disabled', true);
    $('#frmMaster')[0].reset();

    $('#StatusShow').show();
    $("#btnSubmit").show();
    $("#frmMaster :input").prop("disabled", false);
    $("#lblentrymode").html("Create");
    $("#EntryMode").val('Add');
    $("#mdlCreate").attr("data-edit", "Add");
    $("#mdlCreate").attr("data-id", 0);

    $("#VoucherBlock").hide();
    //$("#drpStatus").val(0);
    $("#dverror").empty();


    $("#ddlVoucCamp").val(0).trigger('change');

    $('#mdlCreate').modal('show');
}

function ValidateVoucher(editid, view) {
    $("#lblError").hide();
    var $select = $('#lblStatusText');

    $select.show();


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
        url: "Vouchers.aspx/GetVoucherById",
        dataType: "json",
        data: JSON.stringify({ 'VoucherId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);



            //$("#ddlCampType").val(json[0].CouponTypeId).trigger('change');
            //$("#ddlCampFunding").val(json[0].CouponFundingId).trigger('change');
            //$("#ddlCampCat").val(json[0].CouponCatId).trigger('change');
            //$("#ddlCampBrand").val(json[0].CouponBrandId).trigger('change');
            $select.text("VALID");
            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == "VALID" ? true : false);
            $("[name='chkStatus']").bootstrapSwitch('disabled', false);


            $("#ddlVoucCamp").val(json[0].CampaignId).trigger('change');
            $("#txtFirstName").val(json[0].FirstName);
            $("#txtLastName").val(json[0].LastName);
            $("#txtAmount").val(json[0].VoucherAmount);
            $("#txtExpiryDate").val(json[0].ExpiryDate);

            if (json[0].IssueDate != null) {
                $("#IssueDate").show();
                $("#lblIssueDate").text(json[0].IssueDate);
            }
            else {
                $("#IssueDate").hide();
            }
            if (json[0].UseDate != null && json[0].UseDate != '') {
                $("#UseDate").show();
                $("#lblUseDate").text(json[0].UseDate);
            }
            else {
                $("#UseDate").hide();
            }

            if (json[0].UseProduct != null && json[0].UseProduct != '') {
                $("#UseProduct").show();
                $("#lblUseProduct").text(json[0].UseProduct);
            }
            else {
                $("#UseProduct").hide();
            }

            if (json[0].UseRezId != null && json[0].UseRezId != '') {
                $("#UseRezId").show();
                $("#lblRezId").text(json[0].UseRezId);
            }
            else {
                $("#UseRezId").hide();
            }
            if (json[0].UseSaleAmount != null && json[0].UseSaleAmount != '') {
                $("#UseSaleAmt").show();
                $("#lblSaleAmt").text(json[0].UseSaleAmount);
            }
            else {
                $("#UseSaleAmt").hide();
            }
            if (json[0].UseTaxesIncluded != null && json[0].UseSaleAmount != '') {
                $("#UseTaxes").show();
                $("#lblIssueDate").text(json[0].UseTaxesIncluded);
            }
            else {
                $("#UseTaxes").hide();
            }
        }

    });
    $('#mdlCreate').modal('show');
}

//When edit/view is Clicked
function EditEntry(editid, view) {

    $("#lblError").hide();
    var $select = $('#lblStatusText');

    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $select.text('Approved');
    $("#VoucherBlock").show();
    var json;
    $.ajax({
        type: "POST",
        url: "Vouchers.aspx/GetVoucherById",
        dataType: "json",
        data: JSON.stringify({ 'VoucherId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);

            //$("#ddlCampType").val(json[0].CouponTypeId).trigger('change');
            //$("#ddlCampFunding").val(json[0].CouponFundingId).trigger('change');
            //$("#ddlCampCat").val(json[0].CouponCatId).trigger('change');
            //$("#ddlCampBrand").val(json[0].CouponBrandId).trigger('change');



            $("#ddlVoucCamp").val(json[0].CampaignId).trigger('change');
            $("#txtFirstName").val(json[0].FirstName);
            $("#txtLastName").val(json[0].LastName);
            $("#txtAmount").val(json[0].VoucherAmount);
            $("#txtExpiryDate").val(json[0].ExpiryDate);
            $("#txtIssueDate").val(json[0].IssueDate);
            $select.text(json[0].Status);
            if (json[0].IssueDate != null) {
                $("#IssueDate").show();
                $("#lblIssueDate").text(json[0].IssueDate);
            }
            else {
                $("#IssueDate").hide();
            }
            if (json[0].UseDate != null && json[0].UseDate != '') {
                $("#UseDate").show();
                $("#lblUseDate").text(json[0].UseDate);
            }
            else {
                $("#UseDate").hide();
            }

            if (json[0].UseProduct != null && json[0].UseProduct != '') {
                $("#UseProduct").show();
                $("#lblUseProduct").text(json[0].UseProduct);
            }
            else {
                $("#UseProduct").hide();
            }

            if (json[0].UseRezId != null && json[0].UseRezId != '') {
                $("#UseRezId").show();
                $("#lblRezId").text(json[0].UseRezId);
            }
            else {
                $("#UseRezId").hide();
            }
            if (json[0].UseSaleAmount != null && json[0].UseSaleAmount != '') {
                $("#UseSaleAmt").show();
                $("#lblSaleAmt").text(json[0].UseSaleAmount);
            }
            else {
                $("#UseSaleAmt").hide();
            }
            if (json[0].UseTaxesIncluded != null && json[0].UseSaleAmount != '') {
                $("#UseTaxes").show();
                $("#lblIssueDate").text(json[0].UseTaxesIncluded);
            }
            else {
                $("#UseTaxes").hide();
            }






            if (view == 1) {

                $("#lblentrymode").html("View");
                $("#frmMaster :input").prop("disabled", true);
                $("#btnSubmit").hide();
                $select.show();
                $('#StatusShow').show();
                $("#btnCancel").prop("disabled", false)
                $("#mdlCreate").attr("data-edit", "view");
                $("#btnCancel").html("Close");
                $("[name='chkStatus']").bootstrapSwitch('disabled', true);
            }
            else {

                $("[name='chkStatus']").bootstrapSwitch('disabled', false);
                $("#lblentrymode").html("Modify");
                $("#frmMaster :input").prop("disabled", false);
                $select.hide();
                $('#StatusShow').hide();
                $("#btnSubmit").show();
                $("#EntryMode").val('Edit');
                $("#mdlCreate").attr("data-edit", "edit");


            }
        }

    });

    $('#mdlCreate').modal('show');

}


function BindMultiSelect() {

    // Bind Voucher Brand
    var $b = $('#ddlExclProduct');
    $.ajax({
        type: "POST",
        url: "VoucherCampaign.aspx/GetCouponProductData",
        dataType: "json",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (msg) {

            json = JSON.parse(msg.d);
            $b.empty();



            for (var i = 0; i < json.length; i++) {
                $b.append("<option value=" + json[i].Id + ">" + json[i].ProductName + "</option>").trigger('change');
            }
            $b.multiselect('rebuild');

            //$b.append("<option value=0>--Select Product--</option>");
            //for (var i = 0; i < json.length ; i++) {
            //    $b.append("<li value=" + json[i].Id + ">" + json[i].ProductName + "</li>").trigger('change');
            // }
        }
    });


}

//When cancel is Clicked
function hideModel() {
    $("#lblError").hide();
    $('#mdlCreate .close').click();
}
// To save data entry for Voucher type
function SaveEntry() {

    $("#lblError").hide();
    waitingDialog.show("Saving  Data Please Wait..");
    $.ajaxSetup({
        async: false
    });

    var ExpiryDate = $("#txtExpiryDate").val();
    var VoucherCamp = $("#ddlVoucCamp").val();
    var FirstName = $("#txtFirstName").val();
    var LastName = $("#txtLastName").val();
    var Amount = $("#txtAmount").val();
    var Status = 'WAITING';


    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {
            url = 'Vouchers.aspx/InsertVoucher';
            var Voucher = {
                'ExpiryDate': ExpiryDate,
                'CampaignId': VoucherCamp,
                'FirstName': FirstName,
                'LastName': LastName,
                //'CouponTypeId': CouponType,
                //'CouponFundingId': CouponFunding,
                //'CouponCatId': CouponCat,
                //'CouponBrandId': CouponBrand,
                'VoucherAmount': Amount,
                'Status': 'VALID',
                //'IncProduct': InclProduct.toString(),
                //'ExclProduct': ExclProduct.toString(),
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            }

        }
        else if (Action == 'edit') {

            url = 'Vouchers.aspx/InsertVoucher';
            var Voucher = {
                'ExpiryDate': ExpiryDate,
                'CampaignId': VoucherCamp,
                'FirstName': FirstName,
                'LastName': LastName,
                //'CouponTypeId': CouponType,
                //'CouponFundingId': CouponFunding,
               // 'CouponCatId': CouponCat,
                //'CouponBrandId': CouponBrand,

                'VoucherAmount': Amount,
                'Status': 'WAITING',
                'IncProduct': InclProduct.toString(),
                'ExclProduct': ExclProduct.toString(),
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            }

        }

        else {

            url = 'Vouchers.aspx/InsertVoucher';

            var Voucher = {

                'ExpiryDate': ExpiryDate,
                'CampaignId': VoucherCamp,
                'FirstName': FirstName,
                'LastName': LastName,
                //'CouponTypeId': CouponType,
                //'CouponFundingId': CouponFunding,
                //'CouponCatId': CouponCat,
                //'CouponBrandId': CouponBrand,

                'VoucherAmount': Amount,
                'Status': 'WAITING',
                //'IncProduct': InclProduct.toString(),
                //'ExclProduct': ExclProduct.toString(),
                'Id': 0,
                'Action': 'Add'
            }
        }



        var dataToSend = JSON.stringify({ 'Voucher': Voucher });

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
                else {
                    $('#mdlCreate .close').click();

                    BindTable();
                    $.notify({
                        title: '',
                        message: 'An error has occured.'
                    }, { type: 'error' });
                }
            }
        });
        $('#mdlCreate .close').click();
    }
    else {
        $("#lblError").show()
        $("#lblError").html("Please enter value for Brand,Type,Category,Funding," + "<br/>" +
            "FirstName,LastName and Amount");

    }
    waitingDialog.hide();

}












// To validate data entry for Voucher type
function Validate() {
    if (

        //$("#ddlCampBrand").val() == '0' ||


        //$("#ddlCampType").val() == '0' ||
        //$("#ddlCampCat").val() == '0' ||
        //$("#ddlCampFunding").val() == '0' ||

        $("#txtFirstName").val() == '' ||
        $("#txtLastName").val() == '' ||
        $("#txtAmount").val() == '') {
        return false;
    }
    else {
        return true;
    }
    if ($("#ddlVoucCamp").val() <= 0
        //&& $("#ddlCampCat").val() <= 0

    ) {
        $("#lblError").show();
        return false;
    }
    else {
        return true;
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
    BindDropdown();
    BindMultiSelect();

    $(function () {
        $('.NumericOnly').keypress(function (event) {
            return isNumber(event, this);
        });
    });


    function isNumber(evt, element) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
            (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
            (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
            (charCode < 48 || charCode > 57))
            return false;

        return true;
    }


    //Bind Voucher 


});

function BindDropdown() {
    // Bind Voucher Brand
    var $b = $('#ddlVoucCamp');
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
            $b.append("<option value=0>--Select Campaign--</option>");
            for (var i = 0; i < json.length; i++) {
                $b.append("<option value=" + json[i].Id + ">" + json[i].CampaignName + "</option>").trigger('change');
            }
        }
    });








    



}