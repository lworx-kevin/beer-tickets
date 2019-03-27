//When CreateNew is Clicked
function CreateNew(editid, view) {
    $('#StatusShow').show();
    $('#lblStatusText').show();

    $("#lblError").hide();
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
    $("#txtGlCode").val('');
    $("#txtDepartment").val('');
    //$("#drpStatus").val(0);
    $("#dverror").empty();
             
    $('#mdlCreate').modal('show');
}

function ValidateCoupon(editid, view) {
    $("#frmMaster :input").prop("disabled", false);

    $("#lblError").hide();
    var $select = $('#lblStatusText');
    $select.text("Status");
    $select.show();


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
        url: "CouponFunding.aspx/GetCouponFundingDataById",
        dataType: "json",
        data: JSON.stringify({ 'FundId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            var json = eval(res.d);

            $("#txtGlCode").val(json[0].GlCode);
            $("#txtDepartment").val(json[0].Department);
            //$select.val(json[0].Status);
            $("[name='chkStatus']").bootstrapSwitch('disabled', false);
            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);
            $("#frmMaster :input").prop("disabled", false);

                       
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
        url: "CouponFunding.aspx/GetCouponFundingDataById",
        dataType: "json",
        data: JSON.stringify({ 'FundId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {
                       
            json = JSON.parse(res.d);

            $("#txtGlCode").val(json[0].GlCode);
            $("#txtDepartment").val(json[0].Department);
            //$select.val(json[0].Status);
                       
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
    var GlCode = $("#txtGlCode").val().trim();
    var Department = $("#txtDepartment").val().trim();
    var Status = $("[name='chkStatus']").prop('checked') == true ? 1 : 0;


    var id = $("#CouponFundId").val();
    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {

            url = 'CouponFunding.aspx/InsertCouponFundingData';
            var CouponFunding = {
                'GlCode': GlCode,
                'Department': Department,
                'Status': Status,
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }

        else if (Action == 'edit') {

            url = 'CouponFunding.aspx/InsertCouponFundingData';
            var CouponFunding = {
                'GlCode': GlCode,
                'Department': Department,
                'Status': '0',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }
        else {

            url = 'CouponFunding.aspx/InsertCouponFundingData';
            var CouponFunding = {
                'GlCode': GlCode,
                'Department': Department,
                'Status': Status,
                'Id': 0,
                'Action': 'Add'
            };
        }



        var dataToSend = JSON.stringify({ 'CouponFunding': CouponFunding });

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
                if (data== 'Success') {
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
        $("#lblError").text("Please enter value for Gl Code and Department.");
    }
    waitingDialog.hide();

}


// To validate data entry for coupon type
function Validate() {
    if ($("#txtGlCode").val().toString().trim() == '' || $("#txtDepartment").val().toString().trim() == '') {
        $("#lblError").show();

        return false;
    }
    else {
        return true;
    }
   
}


$(document).ready(function () {
    $("#lblError").hide();
    BindTable();
});