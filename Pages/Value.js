//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#frmMaster :input").prop("disabled", false);
    $('#StatusShow').show();
    $('#lblStatusText').show();

    $("#lblError").hide();
    $(".cke_contents").attr("disabled", false);
    var $select = $('#lblStatusText');
    $select.text("Status");
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);

    $("[name='chkStatus']").bootstrapSwitch('state', false);

    $("[name='chkStatus']").bootstrapSwitch('disabled', true);
    $('#StatusShow').show();
    $("#btnSubmit").show();
    $("#frmMaster :input").prop("disabled", false);
    //CKEDITOR.instances.txtDescription.setReadOnly = false;
    $("#lblentrymode").html("Create");
    $("#EntryMode").val('Add');
    $("#mdlCreate").attr("data-edit", "Add");
    $("#mdlCreate").attr("data-id", 0);
    $("#txtLabel").val('');
    $("#txtValue").val('');

    //$("#drpStatus").val(0);
    $("#dverror").empty();
    //CKEDITOR.instances.txtDescription.setData('');
    $('#mdlCreate').modal('show');
}

function ValidateCoupon(editid, view) {
    $("#frmMaster :input").prop("disabled", false);

    $("#lblError").hide();
    var $select = $('#lblStatusText');
    $select.text("Status");
    $select.show();
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);


    $('#StatusShow').show();
    $("#lblentrymode").html("Promote");
    $("#btnSubmit").show();

    //$("#lblentrymode").html("Modify");
    $("#dverror").empty();
    $("#EntryMode").val('Promote');
    $("#mdlCreate").attr("data-edit", "validate");
    $("#mdlCreate").attr("data-id", editid);

    var json;
    $.ajax({
        type: "POST",
        url: "CouponValue.aspx/GetCouponValueById",
        dataType: "json",
        data: JSON.stringify({ 'ValueId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);

            $("#txtLabel").val(json[0].Label);
            $("#txtValue").val(json[0].Value);

            //CKEDITOR.instances.txtDescription.setData(json[0].Description);
            //$select.val(json[0].Status);
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
        $(".cke_contents").attr("disabled", true);

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
        $select.text("Approved");

    }

    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $select.text('Status');

    var json;
    $.ajax({
        type: "POST",
        url: "CouponValue.aspx/GetCouponValueById",
        dataType: "json",
        data: JSON.stringify({ 'ValueId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);

            $("#txtLabel").val(json[0].Label);
            $("#txtValue").val(json[0].Value);



            //CKEDITOR.instances.txtDescription.setData(json[0].Description);
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
    var Label = $("#txtLabel").val().trim();
    var Value = $("#txtValue").val().trim();

    //var Description = CKEDITOR.instances.txtDescription.getData().trim();



    var Status = $("[name='chkStatus']").prop('checked') == true ? 1 : 0;


    var id = $("#CouponValueId").val();
    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {

            url = 'CouponValue.aspx/InsertCouponValue';
            var CouponValue = {
                'Label': Label,
                'Value': Value,
                'Status': Status,
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }
        else if (Action == 'edit') {

            url = 'CouponValue.aspx/InsertCouponValue';
            var CouponValue = {
                'Label': Label,
                'Value': Value,
                'Status': '0',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }

        else {

            url = 'CouponValue.aspx/InsertCouponValue';
            var CouponValue = {
                'Label': Label,
                'Value': Value,
                'Status': Status,
                'Id': 0,
                'Action': 'Add'
            };
        }



        var dataToSend = JSON.stringify({ 'CouponValue': CouponValue });

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
    if ($("#txtLabel").val().toString().trim() == '') {
        $("#lblError").html("Please enter value for Label.");
        $("#lblError").show();
        return false;
    }
    if ($("#txtValue").val() == 0) {
        $("#lblError").html("Value must be whole number between 0 and 1000");
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

$("#txtValue").keyup(function () {
    var txtQty = $(this).val().replace(/[^\d]+/, '');
    $(this).val(txtQty);
});

$(document).ready(function () {
    $("#lblError").hide();
    BindTable();
});
