
//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#lblError").hide();
    var $select = $('#lblStatusText');
    $('#lblStatusText').show();

    $select.text("Valid");
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);

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
    $("#ddlCampBrand").val(0).trigger('change');
    $("#ddlCampType").val(0).trigger('change');
    $("#ddlCampCat").val(0).trigger('change');
    $("#ddlInclProduct").multiselect('refresh');
    $("#ddlExclProduct").multiselect('refresh');
    $('#mdlCreate').modal('show');
}

function ValidateVoucher(editid, view) {
    $("#lblError").hide();
    var $select = $('#lblStatusText');
    $select.text("VALID");
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
        url: "GiftCards.aspx/GetCertificateById",
        dataType: "json",
        data: JSON.stringify({ 'CertificateId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);



            $("#ddlCampBrand").val(json[0].CampaignBrandId).trigger('change');
            $("#ddlCampType").val(json[0].CouponTypeId).trigger('change');
            $("#ddlCampCat").val(json[0].CouponCatId).trigger('change');
            $("#txtFirstName").val(json[0].FirstName);
            $("#txtLastName").val(json[0].LastName);
            $("#txtAmount").val(json[0].CertificateAmount);
            $("#txtExpiryDate").val(json[0].ExpiryDate);
            $("[name='chkStatus']").bootstrapSwitch('disabled', false);
            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == "VALID" ? true : false);

            //$("#ddlVoucCamp").val(json[0].CampaignId).trigger('change');
            //$("#txtValue").val(json[0].CertificateValue);
            //var InclProduct = json[0].IncProduct;
            //var ExclProduct = json[0].ExclProduct;

            //Make an array


            //var Incdataarray = InclProduct.split(",");
            //var Excdataarray = ExclProduct.split(",");


            // Then refresh
            //$("#ddlInclProduct").val(Incdataarray);
            //$("#ddlExclProduct").val(Excdataarray);
            //$("#ddlInclProduct").multiselect("refresh");
            //$("#ddlExclProduct").multiselect("refresh");



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

    $("#VoucherBlock").show();
    var json;
    $.ajax({
        type: "POST",
        url: "GiftCards.aspx/GetCertificateById",
        dataType: "json",
        data: JSON.stringify({ 'CertificateId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);

            $("#ddlCampType").val(json[0].CouponTypeId).trigger('change');
            $("#ddlCampCat").val(json[0].CouponCatId).trigger('change');
            $("#ddlCampBrand").val(json[0].CampaignBrandId).trigger('change');

            //$("#ddlVoucCamp").val(json[0].CampaignId).trigger('change');
            $("#txtFirstName").val(json[0].FirstName);
            $("#txtLastName").val(json[0].LastName);
            $("#txtAmount").val(json[0].CertificateAmount);
            $("#txtExpiryDate").val(json[0].ExpiryDate);
            $select.text(json[0].Status);
            //$("#txtValue").val(json[0].CertificateValue);

            //var InclProduct = json[0].InclProduct;
            //var ExclProduct = json[0].ExclProduct;



            //var Incdataarray = InclProduct.split(",");
            //var Excdataarray = ExclProduct.split(",");

            // Set the value

            //$("#ddlInclProduct").val(Incdataarray);
            //$("#ddlExclProduct").val(Excdataarray);

            //$("#ddlInclProduct").multiselect("refresh");
            //$("#ddlExclProduct").multiselect("refresh");


            if (json[0].IssueDate != null) {
                $("#IssueDate").show();
                $("#lblIssueDate").text(json[0].IssueDate);
            }
            else {
                $("#IssueDate").hide();
            }





            $("[name='chkStatus']").bootstrapSwitch('state', true);
            $("[name='chkStatus']").bootstrapSwitch('disabled', true);
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
        }

    });

    $('#mdlCreate').modal('show');

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
    //var ExpiryDate = $("#txtExpiryDate").val();

    var CouponType = $("#ddlCampType").val();
    var CouponCat = $("#ddlCampCat").val();
    var CampaignBrandId = $("#ddlCampBrand").val();

    //var VoucherCamp = $("#ddlVoucCamp").val();
    var FirstName = $("#txtFirstName").val();
    var LastName = $("#txtLastName").val();
    var Amount = $("#txtAmount").val();
    //var Value = $("#txtValue").val();
    //var InclProduct = $("#ddlInclProduct").val() == null ? 0 : $("#ddlInclProduct").val();
    //var ExclProduct = $("#ddlExclProduct").val() == null ? 0 : $("#ddlExclProduct").val()
    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {
            var Status = 'VALID';
            url = 'GiftCards.aspx/InsertCertificate';
            var GiftCertificate = {
                'CouponTypeId': CouponType,
                'CouponCatId': CouponCat,
                // 'ExpiryDate': ExpiryDate,
                //'CampaignId': VoucherCamp,
                'CampaignBrandId': CampaignBrandId,
                'FirstName': FirstName,
                'LastName': LastName,
                'CertificateAmount': Amount,

                'Status': Status,
                //'InclProduct': InclProduct.toString(),
                //'ExclProduct': ExclProduct.toString(),
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit"),
                'CampaignBrandId': CampaignBrandId
            }
        }
        else if (Action == 'edit') {
            var Status = 'Valid';
            url = 'GiftCards.aspx/InsertCertificate';
            var GiftCertificate = {
                'CouponTypeId': CouponType,
                'CouponCatId': CouponCat,
                //'ExpiryDate': ExpiryDate,
                //'CampaignId': VoucherCamp,
                'FirstName': FirstName,
                'LastName': LastName,
                'CertificateAmount': Amount,
                'Status': Status,
                //'InclProduct': InclProduct.toString(),
                //'ExclProduct': ExclProduct.toString(),
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit"),
                'CampaignBrandId': CampaignBrandId
            }
        }
        else {
            var Status = 'Valid';
            url = 'GiftCards.aspx/InsertCertificate';

            var GiftCertificate = {
                'CouponTypeId': CouponType,
                'CouponCatId': CouponCat,
                //'ExpiryDate': ExpiryDate,
                //'CampaignId': VoucherCamp,
                'FirstName': FirstName,
                'LastName': LastName,
                'CertificateAmount': Amount,

                'Status': Status,
                //'InclProduct': InclProduct.toString(),
                //'ExclProduct': ExclProduct.toString(),
                'Id': 0,
                'Action': 'Add',
                'CampaignBrandId': CampaignBrandId


            }
        }



        var dataToSend = JSON.stringify({ 'GiftCertificate': GiftCertificate });

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
        $("#lblError").show();
        $("#lblError").html('Please enter value for Brand, Type, Category, FirstName, LastName and Amount')
    }
    waitingDialog.hide();

}









// To validate data entry for Voucher type
function Validate() {

    if ($("#ddlCampType").val() == '0' ||
        $("#ddlCampCat").val() == '0' ||
        $("#ddlCampBrand").val() == '0' ||
        $("#txtFirstName").val() == '' ||
        $("#txtLastName").val() == '' ||
        $("#txtAmount").val() == '') {
        return false;
    }
    else {
        return true;
    }
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
    //BindMultiSelect();



    //$('#ddlInclProduct').multiselect();
    //$('#ddlExclProduct').multiselect();


    $('#ddlInclProduct').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        enableFiltering: true,
        onChange: function (element, checked) {
            var brands = $('#ddlInclProduct option:selected');
            var selection = [];

            $(brands).each(function (index, pro) {
                selection.push(pro);
            });



        }
    });

    $('#ddlExclProduct').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        enableFiltering: true,
        onChange: function (element, checked) {
            var brands = $('#ddlExclProduct option:selected');
            var selection = [];
            $(brands).each(function (index, pro) {
                selection.push(pro);
            });



        }
    });

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
    var $ab = '';
    $ab = $("#ddlCampType");
    $.ajax({
        type: "POST",
        url: "VoucherCampaign.aspx/GetCouponTypeData",
        dataType: "json",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (msg) {
            json = JSON.parse(msg.d);
            $ab.empty();
            $ab.append("<option value=0>--Select Type--</option>");
            for (var i = 0; i < json.length; i++) {
                $ab.append("<option value=" + json[i].Id + ">" + json[i].Code + "</option>").trigger('change');
            }
        }
    });


    //var $b = $('#ddlVoucCamp');
    //$.ajax({
    //    type: "POST",
    //    url: "Vouchers.aspx/GetVoucherCampaign",
    //    dataType: "json",
    //    data: "{}",
    //    contentType: "application/json; charset=utf-8",
    //    async: true,
    //    cache: false,
    //    success: function (msg) {
    //        json = JSON.parse(msg.d);
    //        $b.empty();
    //        $b.append("<option value=0>--Select Voucher Campaign--</option>");
    //        for (var i = 0; i < json.length ; i++) {
    //            $b.append("<option value=" + json[i].Id + ">" + json[i].CampaignName + "</option>").trigger('change');
    //        }
    //    }
    //});


    var $br = $('#ddlCampBrand');
    $.ajax({
        type: "POST",
        url: "VoucherCampaign.aspx/GetCouponBrandData",
        dataType: "json",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (msg) {
            json = JSON.parse(msg.d);
            $br.empty();
            $br.append("<option value=0>--Select Brand--</option>");
            for (var i = 0; i < json.length; i++) {
                $br.append("<option value=" + json[i].Id + ">" + json[i].BrandName + "</option>").trigger('change');
            }
        }
    });
    //Bind Coupon Category
    $cb = $("#ddlCampCat");
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
            $cb.append("<option value=0>--Select Category--</option>");
            for (var i = 0; i < json.length; i++) {
                $cb.append("<option value=" + json[i].Id + ">" + json[i].Category + "</option>").trigger('change');
            }
        }
    });

}