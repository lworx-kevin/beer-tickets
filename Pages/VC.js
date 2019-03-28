$(document).ready(function () {
    $("#txtEngEditor").Editor();
    $("#txtFrEditor").Editor();   
});
//When CreateNew is Clicked
function CreateNew(editid, view) {

    $("#lblError").hide();
    $("#URL").hide();

    $('#lblStatusText').show();

    var $select = $('#lblStatusText');
    $select.text("Pending");
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


    //$("#drpStatus").val(0);
    $("#dverror").empty();


    $("#ddlCampType").val(0).trigger('change');

    $("#ddlCampCat").val(0).trigger('change');
    $("#ddlCampType").val(0).trigger('change');

    $('#mdlCreate').modal('show');
}

function ValidateCoupon(editid, view) {
    $("#lblError").hide();
    var $select = $('#lblStatusText');
    $select.text("Approved");
    $select.show();

    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $("#URL").show();

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
        url: "VoucherCampaign.aspx/GetVoucherCampaignById",
        dataType: "json",
        data: JSON.stringify({ 'CampId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);


            $("#ddlCampType").val(json[0].CouponTypeId).trigger('change');
            //$("#ddlCampFunding").val(json[0].CouponFundingId).trigger('change');
            $("#ddlCampCat").val(json[0].CouponCatId).trigger('change');
            $("#ddlCampBrand").val(json[0].CouponBrandId).trigger('change');
            $("#ddlCouponValue").val(json[0].CouponValue).trigger('change');
            $("#txtCampName").val(json[0].CampName);
            //$("#txtCampVal").val(json[0].CampValue);
            $("#txtStartDate").val(json[0].StartDate);
            $("#txtEndDate").val(json[0].EndDate)
            //$("#txtDepartDate").val(json[0].DepartDate);
            //$("#txtReturnDate").val(json[0].ReturnDate)
            $("#txtEngEditor").Editor("setText", json[0].htmlEnglish);
            $("#txtFrEditor").Editor("setText", json[0].htmlFrench);
            $("#txtURLENg").text(json[0].URLEnglish);
            $("#txtURLFR").text(json[0].URLFrench);




            var InclProduct = json[0].InclProduct;
            var ExclProduct = json[0].ExclProduct;

            //Make an array   

            // Set the value


            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);
            $("[name='chkStatus']").bootstrapSwitch('disabled', false);


        }

    });
    $('#mdlCreate').modal('show');
}

//When edit/view is Clicked
function EditEntry(editid, view) {

    $("#lblError").hide();
    $('#StatusShow').show();

    var $select = $('#lblStatusText');

    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $select.text('Approved');
    $("#URL").show();
    var json;
    $.ajax({
        type: "POST",
        url: "VoucherCampaign.aspx/GetVoucherCampaignById",
        dataType: "json",
        data: JSON.stringify({ 'CampId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);



            $("#ddlCampType").val(json[0].CouponTypeId).trigger('change');
            //$("#ddlCampFunding").val(json[0].CouponFundingId).trigger('change');
            $("#ddlCampCat").val(json[0].CouponCatId).trigger('change');
            $("#ddlCampBrand").val(json[0].CouponBrandId).trigger('change');
            $("#ddlCouponValue").val(json[0].CouponValue).trigger('change');

            $("#txtCampName").val(json[0].CampName);
            //$("#txtCampVal").val(json[0].CampValue);
            $("#txtStartDate").val(json[0].StartDate);
            $("#txtEndDate").val(json[0].EndDate);
            //$("#txtDepartDate").val(json[0].DepartDate);
           // $("#txtReturnDate").val(json[0].ReturnDate);
            $("#txtEngEditor").Editor("setText", json[0].htmlEnglish);
            $("#txtFrEditor").Editor("setText", json[0].htmlFrench);
            $("#txtURLENg").text(json[0].URLEnglish);
            $("#txtURLFR").text(json[0].URLFrench);

            var InclProduct = json[0].InclProduct;
            var ExclProduct = json[0].ExclProduct;

            //Make an array

            var Incdataarray = InclProduct.split(",");
            var Excdataarray = ExclProduct.split(",");

            // Set the value

       


            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);
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

function BindMultiSelect() {

    // Bind Coupon Brand
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

            for (var i = 0; i < json.length ; i++) {
                $b.append("<option value=" + json[i].Id + ">" + json[i].ProductName + "</option>").trigger('change');
            }
            $b.multiselect('rebuild');

            
        }
    });

  
}

//When cancel is Clicked
function hideModel() {
    $("#lblError").hide();
    $('#mdlCreate .close').click();
}
// To save data entry for coupon type
function SaveEntry() {
    debugger;
    $("#lblError").hide();
    //waitingDialog.show("Saving  Data Please Wait..");
    $.ajaxSetup({
        async: false
    });

    var StartDate = $("#txtStartDate").val();
    var EndDate = $("#txtEndDate").val();
    var DepartDate = '';//$("#txtDepartDate").val(); here 
    var ReturnDate = '';//$("#txtReturnDate").val(); here 
    var CouponType = $("#ddlCampType").val();
    //var CouponFunding = 26;//$("#ddlCampFunding").val();
    var CouponCat = $("#ddlCampCat").val();
    var CouponBrand = $("#ddlCampBrand").val();
    var CampName = $("#txtCampName").val();
    var CouponValue = $("#ddlCouponValue").val();
    var htmlEnglish = $("#txtEngEditor").Editor("getText");
    var htmlFrench = $("#txtFrEditor").Editor("getText");


    //var CampValue = $("#txtCampVal").val();
    var Status = $('#lblStatusText').text() == 'Approved' && $("[name='chkStatus']").prop('checked') == true ? 1 : 0;
    var InclProduct = 0;// here 
        //$("#ddlInclProduct").val() == null ? 0 : $("#ddlInclProduct").val();
    var ExclProduct = 0; // here 
        //$("#ddlExclProduct").val() == null ? 0 : $("#ddlExclProduct").val(); 



    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {
            url = 'VoucherCampaign.aspx/InsertVoucherCampaign';
            var VoucherCamp = {
                'StartDate': StartDate,
                'EndDate': EndDate,
                'DepartDate': DepartDate,
                'ReturnDate': ReturnDate,
                'CouponTypeId': CouponType,
                //'CouponFundingId': CouponFunding, //here 
                'CouponCatId': CouponCat,
                'CouponBrandId': CouponBrand,
                'CampName': CampName,
                'CouponValue': CouponValue,
                'Status': Status,
                'InclProduct': InclProduct.toString(),
                'ExclProduct': ExclProduct.toString(),
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit"),
                'htmlEnglish': htmlEnglish,
                'htmlFrench': htmlFrench
            }
        }
        else if (Action == 'edit') {

            url = 'VoucherCampaign.aspx/InsertVoucherCampaign';
            var VoucherCamp = {
                'StartDate': StartDate,
                'EndDate': EndDate,
                'DepartDate': DepartDate,
                'ReturnDate': ReturnDate,

                'CouponTypeId': CouponType,
                //'CouponFundingId': CouponFunding,
                'CouponCatId': CouponCat,
                'CouponBrandId': CouponBrand,
                'CampName': CampName,
                'CouponValue': CouponValue,
                'Status': 0,
                'InclProduct': InclProduct.toString(),
                'ExclProduct': ExclProduct.toString(),
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit"),
                'htmlEnglish': htmlEnglish,
                'htmlFrench': htmlFrench
            }
        }


        else {

            url = 'VoucherCampaign.aspx/InsertVoucherCampaign';

            var VoucherCamp = {
                'StartDate': StartDate,
                'EndDate': EndDate,
                'DepartDate': DepartDate,
                'ReturnDate': ReturnDate,

                'CouponTypeId': CouponType,
                //'CouponFundingId': CouponFunding,
                'CouponCatId': CouponCat,
                'CouponBrandId': CouponBrand,
                'CampName': CampName,
                'CouponValue': CouponValue,
                'Status': Status,
                'InclProduct': InclProduct.toString(),
                'ExclProduct': ExclProduct.toString(),
                'Id': 0,
                'Action': 'Add',
                'htmlEnglish': htmlEnglish,
                'htmlFrench': htmlFrench
            }
        }



        var dataToSend = JSON.stringify({ 'VoucherCamp': VoucherCamp });

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
                else if (data == 'Exists') {
                   
                    $.notify({
                        title: '',
                        message: 'Campaign Name already exists.'
                    }, { type: 'warning' });
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
        $("#lblError").html("Please enter value for Brand,Voucher Type,Voucher Category,Campaign Funding, Campaign Name,Value:");

    }
    //waitingDialog.hide();

}




// To validate data entry for coupon type
function Validate() {
    var CampName = $("#txtCampName").val();
    //var CampValue = $("#txtCampVal").val();






    if (CampName.toString().trim() == '' || $("#ddlCampType").val() <= 0 //|| //$("#ddlCampFunding").val() <= 0 here 

        || $("#ddlCampCat").val() <= 0 || $("#ddlCampBrand").val() <= 0 || $("#ddlCouponValue").val() <= 0) {
        $("#lblError").show();
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
    BindMultiSelect();



});

function BindDropdown() {
    // Bind Coupon Brand
    var $b = $('#ddlCampBrand');
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
            $b.empty();
            $b.append("<option value=0>--Select Brand--</option>");
            for (var i = 0; i < json.length ; i++) {
                $b.append("<option value=" + json[i].Id + ">" + json[i].BrandName + "</option>").trigger('change');
            }
        }
    });

    // Bind Coupon Value
    var $btt = $('#ddlCouponValue');
    $.ajax({
        type: "POST",
        url: "VoucherCampaign.aspx/GetCouponValueData",
        dataType: "json",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (msg) {
            json = JSON.parse(msg.d);
            $btt.empty();
            $btt.append("<option value=0>--Select Value--</option>");
            for (var i = 0; i < json.length ; i++) {
                $btt.append("<option value=" + json[i].Id + ">" + json[i].Value + "</option>").trigger('change');
            }
        }
    });

    // Bind Coupon Type
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
            for (var i = 0; i < json.length ; i++) {
                $ab.append("<option value=" + json[i].Id + ">" + json[i].Code + "</option>").trigger('change');
            }
        }
    });


    //Bind Coupon Funding
    //$bb = $("#ddlCampFunding");


    //$.ajax({
    //    type: "POST",
    //    url: "VoucherCampaign.aspx/GetCouponFundingData",
    //    dataType: "json",
    //    data: "{}",
    //    contentType: "application/json; charset=utf-8",
    //    async: true,
    //    cache: false,
    //    success: function (msg) {
    //        json = JSON.parse(msg.d);
    //      //  $bb.empty();
    //       // $bb.append("<option value=0>--Select Funding--</option>");
    //        //for (var i = 0; i < json.length ; i++) {
    //          //  $bb.append("<option value=" + json[i].Id + ">" + json[i].Department + "</option>").trigger('change');
    //       // }
    //    }
    //});


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
            for (var i = 0; i < json.length ; i++) {
                $cb.append("<option value=" + json[i].Id + ">" + json[i].Category + "</option>").trigger('change');
            }
        }
    });



}
