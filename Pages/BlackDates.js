

//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#lblError").hide();
    $('#StatusShow').show();
    $('#lblStatusText').show();


    $("[name='chkStatus']").bootstrapSwitch('state', false);
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
        url: "BlackoutDates.aspx/GetBDatesById",
        dataType: "json",
        data: JSON.stringify({ 'VoucherId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {
            debugger;
            var json = eval(res.d);



            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Active == "1" ? true : false);
            $("[name='chkStatus']").bootstrapSwitch('disabled', false);


            //$("#ddlVoucCamp").val(json[0].CampaignId).trigger('change');
            $("#txtFirstName").val(json[0].Name);
            $("#txtStartDate").val(json[0].StartDate);
            $("#txtEndDate").val(json[0].EndDate);

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
    var json;
    $.ajax({
        type: "POST",
        url: "BlackoutDates.aspx/GetBDatesById",
        dataType: "json",
        data: JSON.stringify({ 'Id': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);
            $("#txtFirstName").val(json[0].Name);
            $("#txtStartDate").val(json[0].StartDate);
            $("#txtEndDate").val(json[0].EndDate);




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


//When cancel is Clicked
function hideModel() {
    $("#lblError").hide();
    $('#mdlCreate .close').click();
}
// To save data entry for Voucher type
function SaveEntry() {
    debugger;
    $("#lblError").hide();
    waitingDialog.show("Saving  Data Please Wait..");
    $.ajaxSetup({
        async: false
    });

    var StartDate = $("#txtStartDate").val();
    var EndDate = $("#txtEndDate").val();
    //var VoucherCamp = $("#ddlVoucCamp").val();
    var Name = $("#txtFirstName").val();


    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {

            url = 'BlackoutDates.aspx/InsertBlackoutDates';
            var BDates = {
                'Name': Name,
                'StartDate': StartDate,
                'EndDate': EndDate,
                'Active': '1',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            }

        }
        else if (Action == 'edit') {

            url = 'BlackoutDates.aspx/InsertBlackoutDates';
            var BDates = {
                'Name': Name,
                'StartDate': StartDate,
                'EndDate': EndDate,
                'Active': '0',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            }

        }

        else {

            url = 'BlackoutDates.aspx/InsertBlackoutDates';

            var BDates = {

                'Name': Name,
                'StartDate': StartDate,
                'EndDate': EndDate,
                'Active': '0',
                'Id': 0,
                'Action': 'Add'
            }
        }



        var dataToSend = JSON.stringify({ 'BDates': BDates });

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
        $("#lblError").html("Please enter value for Dates");

    }
    waitingDialog.hide();

}












// To validate data entry for Voucher type
function Validate() {
    if (
    $("#txtFirstName").val() == '' ||
    $("#txtStartDate").val() == '' ||
    $("#txtEndDate").val() == '') {
        return false;
    }
    else {
        return true;
    }
    //if ($("#ddlVoucCamp").val() <= 0 && $("#ddlCampCat").val() <= 0) {
    //    $("#lblError").show();
    //    return false;
    //}
    //else {
    //    return true;
    //}
    return true;
}



$(document).ready(function () {
    $("#lblError").hide();
    BindTable();



});

