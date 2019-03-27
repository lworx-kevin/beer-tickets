//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#lblError").hide();
    $('#lblStatusText').show();

    var $select = $('#lblStatusText');
    // New added for NStatus
    $select.text("Status");
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $("[name='chkPayC']").bootstrapSwitch('disabled', false);
    $("[name='chkPayC']").bootstrapSwitch('state', false);

    $("[name='chkStatus']").bootstrapSwitch('state', false);
    $("[name='chkStatus']").bootstrapSwitch('disabled', true);


    $('#StatusShow').show();
    $("#btnSubmit").show();
    $("#frmMaster :input").prop("disabled", false);
    $("#lblentrymode").html("Create");
    $("#EntryMode").val('Add');
    $("#mdlCreate").attr("data-edit", "Add");
    $("#mdlCreate").attr("data-id", 0);
    $("#txtCatCode").val('');
    $("#txtCouponPrefix").val('');
    $("#txtDescription").val('');
    //$("#drpStatus").val(0);
    $("#dverror").empty();

    $('#mdlCreate').modal('show');
}

function ValidateCoupon(editid, view) {
    $("#frmMaster :input").prop("disabled", false);

    $("#lblError").hide();
    var $select = $('#lblStatusText');
    // New added for NStatus

    $select.text("Status");
    $select.show();
    $("[name='chkPayC']").bootstrapSwitch('disabled', false);
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
        url: "CouponTypes.aspx/GetCouponCategoryById",
        dataType: "json",
        data: JSON.stringify({ 'CatId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);

            $("#txtCatCode").val(json[0].Category);
            $("#txtCouponPrefix").val(json[0].CouponPrefix);
            $("#txtDescription").val(json[0].Description);

            // $('select[name="drpStatus"]').find('option[value="' + json[0].Status + '"]').attr("selected", true);

            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);
            $("[name='chkPayC']").bootstrapSwitch('state', json[0].PayC == '1' ? true : false);

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

    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $("[name='chkPayC']").bootstrapSwitch('disabled', false);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    // New added for NStatus

    $select.text('Status');

    var json;
    $.ajax({
        type: "POST",
        url: "CouponTypes.aspx/GetCouponCategoryById",
        dataType: "json",
        data: JSON.stringify({ 'CatId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);

            $("#txtCatCode").val(json[0].Category.trim());
            $("#txtCouponPrefix").val(json[0].CouponPrefix.trim());
            $("#txtDescription").val(json[0].Description.trim());

            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);
            $("[name='chkStatus']").bootstrapSwitch('disabled', true);
            $("[name='chkPayC']").bootstrapSwitch('state', json[0].PayC == '1' ? true : false);
            if (view == 1) {
                $("[name='chkPayC']").bootstrapSwitch('disabled', true);
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
// To save data entry for coupon type
function SaveEntry() {

    $("#lblError").hide();
    waitingDialog.show("Saving  Data Please Wait..");
    $.ajaxSetup({
        async: false
    });
    var CatCode = $("#txtCatCode").val().trim();
    var CouponPrefix = $("#txtCouponPrefix").val().trim();
    var Description = $("#txtDescription").val().trim();

    // var Status = $("#lblStatus").text()== 'Approved' ? $("#chkStatus").'  1 : 0;
    // New added for NStatus

    var Status = $("[name='chkStatus']").prop('checked') == true ? 1 : 0;
    var PayC = $("[name='chkPayC']").prop('checked') == true ? 1 : 0;


    var CatId = $("#CatId").val();
    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {

            url = 'CouponTypes.aspx/InsertCouponCategory';
            var CouponCategory = {
                'Category': CatCode,
                'CouponPrefix': CouponPrefix,
                'Description': Description,

                'Status': Status,
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }

        else if (Action == 'edit') {

            url = 'CouponTypes.aspx/InsertCouponCategory';
            var CouponCategory = {
                'Category': CatCode,
                'CouponPrefix': CouponPrefix,
                'Description': Description,
                'PayC':PayC,
                'Status': '0',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }





        else {

            url = 'CouponTypes.aspx/InsertCouponCategory';
            var CouponCategory = {
                'Category': CatCode,
                'CouponPrefix': CouponPrefix,
                'Description': Description,
                'Status': Status,
                'PayC':PayC,
                'Id': 0,
                'Action': 'Add'
            };
        }



        var dataToSend = JSON.stringify({ 'CouponCategory': CouponCategory });

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
    if ($("#txtCatCode").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for code.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtCatCode").val().toString().trim().length < 2) {
        $("#lblError").html("Category code must be two character long.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtCouponPrefix").val().toString().trim().length < 5) {
        $("#lblError").html("Category prefix must be five character long.");
        $("#lblError").show();
        return false;
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