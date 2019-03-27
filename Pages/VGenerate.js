//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#lblError").hide();
    $('#StatusShow').show();
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
    $("#dverror").empty();


    $("#ddlVoucCamp").val(0).trigger('change');
    $('#mdlCreate').modal('show');
}


//When edit/view is Clicked
function EditEntry(editid, view,Dist) {
                    
    $("#lblError").hide();
    var $select = $('#lblStatusText');

    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    //$select.text('Approved');
    var json;
    $.ajax({
        type: "POST",
        url: "GenerateVouchers.aspx/GetVouchersCampaignById",
        dataType: "json",
        data: JSON.stringify({ 'Id': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);

            $("#ddlVoucCamp").val(json[0].CampaignName).trigger('change');
            $("#ddlDistribution").val(json[0].Distribution).trigger('change');
            $("#lblStatusText").text(json[0].Status);
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
                if (Dist == null) {
                    $("#lblentrymode").html("Modify");
                    $("#frmMaster :input").prop("disabled", false);
                    $select.hide();
                    $('#StatusShow').hide();
                    $("#btnSubmit").show();
                    $("#EntryMode").val('Edit');
                    $("#mdlCreate").attr("data-edit", "edit");
                                    
                }

            }
        }

    });

    $('#mdlCreate').modal('show');


}

function ValidateVoucher(editid, view) {
    $("#lblError").hide();
    var $select = $('#lblStatusText');
    $select.text("Approved");
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
        url: "GenerateVouchers.aspx/GetVouchersCampaignById",
        dataType: "json",
        data: JSON.stringify({ 'Id': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {
            json = JSON.parse(res.d);
            $("#ddlVoucCamp").val(json[0].CampaignName).trigger('change');
            $("#ddlDistribution").val(json[0].Distribution).trigger('change');
            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status=='PENDING'?false:true);
            $("[name='chkStatus']").bootstrapSwitch('disabled', false);

             


        }

    });
    $('#mdlCreate').modal('show');
}


//When cancel is Clicked
function hideModel() {
    $("#lblCouponError").hide();
    $('#mdlCreate .close').click();
}
function hideCouponModel() {
    $("#lblCouponError").hide();
    $('#mdlEditViewCoupon .close').click();
}
                
// To save data entry for Voucher type
function SaveEntry() {
                  
    var FirstNameCol; var LastNameCol; var EmailCol;
    var DataArray = new Array();
    var Data = [];
    var GridData;
    var GridDataArray = [];

    var Email; var FirstName; var LastName;
                  
    $("#lblError").hide();
    waitingDialog.show("Saving  Data Please Wait..");
    $.ajaxSetup({
        async: false
    });
                   
    var MyRows = $('table#tb_GetFieldsName').find('tbody').find('tr');

                    

    for (var i = 0; i < MyRows.length; i++) {

        if ($(MyRows[i]).find('td:eq(1)').find('input').is(':checked'))
        {
            EmailCol = i;
                           
        }
        if ($(MyRows[i]).find('td:eq(2)').find('input').is(':checked')) {

            FirstNameCol = i;
                          
        }
        if ($(MyRows[i]).find('td:eq(3)').find('input').is(':checked')) {
            LastNameCol = i;
        }

    }
    var Email;
    var FirstName; var LastName;
    $('table#tb_BufferData tr').each(function (i, row) {
        var $row = $(row)
        Email = $row.find('td:eq("' + EmailCol + '")').html()
        FirstName = $row.find('td:eq("' + FirstNameCol + '")').html();
        LastName = $row.find('td:eq("' + LastNameCol + '")').html();
                       
        GridData = {


            Email: Email,
            FirstName: FirstName,
            LastName: LastName
        };

        GridDataArray.push(GridData);
    });


                    

    var Distribution = $("#ddlDistribution").val();

                   
    var VoucherCamp = $("#ddlVoucCamp").val();
    var Status = 'VALID';


    var Action = $("#mdlCreate").attr("data-edit");
                    
    if (Validate()) {
        var url = '';
        if (Action == 'validate') {

            url = 'GenerateVouchers.aspx/InsertBulkVoucherWithCampaign';
                           
            var VOCampaign = {
                'Campaign': VoucherCamp,
                'Distribution': Distribution,
                'Status': 'VALID',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            }

        }
        else if (Action == 'edit') {

            url = 'GenerateVouchers.aspx/InsertBulkVoucherWithCampaign';
            var VOCampaign = {
                                
                'Campaign': VoucherCamp,
                'Distribution': Distribution,
                'Status': 'PENDING',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            }

        }

        else {

            url = 'GenerateVouchers.aspx/InsertBulkVoucherWithCampaign';

            var VOCampaign = {

                               
                'Campaign': VoucherCamp,
                'Distribution': Distribution,
                'Status': 'PENDING',
                'Id': 0,
                'Action': 'Add'
            }
        }



        var dataToSend = JSON.stringify({ 'VOCampaign': VOCampaign, 'GridDataArray': GridDataArray });

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
        $("#lblError").html("Please choose Campaign Name and Distribution category");

    }
    waitingDialog.hide();

}


function Validate()
{


    var Distribution = $("#ddlDistribution").val();
    var VoucherCamp = $("#ddlVoucCamp").val();

    if(VoucherCamp=='' || VoucherCamp==0 || VoucherCamp==null)
    {
        return false;
    }
    else if (Distribution == '' || Distribution==0 || Distribution == null) {
        return false;
    }
    else if (document.getElementById("Upload").files.length == 0)
    {
        return "Please select valid CSV file.";
    }
    else
    {
        return true;
    }
}



//When edit/view is Clicked
function EditCouponEntry(editid, view,Dist) {
    $('#mdlEditViewCoupon').modal('show');

    $("#lblError").hide();
    var $select = $('#lblStatusText');
                    
    $("#mdlEditViewCoupon").attr("data-id", '');
    $("#mdlEditViewCoupon").attr("data-id", editid);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    //$select.text('Approved');
    var json;
    $.ajax({
        type: "POST",
        url: "GenerateVouchers.aspx/GetCouponById",
        dataType: "json",
        data: JSON.stringify({ 'Id': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {

            json = JSON.parse(res.d);

            $("#txtEmail").val(json[0].Email);
            $("#txtFirstName").val(json[0].FirstName);
            $("#txtLastName").val(json[0].LastName);
            if (view == 1) {

                $("#lblCouponentrymode").html("View");
                $("#frmCouponMaster :input").prop("disabled", true);
                $("#btnSubmitCoupon").hide();
                $("#lblCouponError").hide();
                $select.show();
                $("#btnCancelCoupon").prop("disabled", false)
                $("#mdlEditViewCoupon").attr("data-edit", "view");
                $("#btnCancelCoupon").html("Close");
            }
            else {
                if (Dist == 0) {
                    $("#lblCouponentrymode").html("Modify");
                    $("#frmCouponMaster :input").prop("disabled", false);
                    $select.hide();
                    $("#btnSubmitCoupon").show();
                    $("#CouponEntryMode").val('Edit');
                    $("#mdlEditViewCoupon").attr("data-edit", "edit");
                    $("#lblCouponError").hide();
                }

            }
        }

    });

    $('#mdlEditViewCoupon').modal('show');

}

function SaveCouponEntry() {
                    
    var FirstName; var LastName; var Email;


    $("#lblCouponError").hide();
    waitingDialog.show("Saving  Data Please Wait..");
    $.ajaxSetup({
        async: false
    });

                   
    Email = $("#txtEmail").val();
    FirstName = $("#txtFirstName").val(); LastName = $("#txtLastName").val();
                    



              
    var Action = $("#mdlEditViewCoupon").attr("data-edit");

    if (FormValidateCoupon()) {
        var url = '';
                        
        if (Action == 'edit') {

            url = 'GenerateVouchers.aspx/EditGenerateCouponData';
            var CouponGeneration = {

                'Email': Email,
                'FirstName': FirstName,
                'LastName': LastName,
                'Id': $("#mdlEditViewCoupon").attr("data-id"),
                'Action': $("#mdlEditViewCoupon").attr("data-edit")
            }

        }



        var dataToSend = JSON.stringify({ 'CouponGeneration': CouponGeneration });
        var Id = $('#mdlDetailListing').attr("data-id");
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
                    $('#mdlEditViewCoupon .close').click();
                    ListView(Id);
                    $.notify({
                        title: '',
                        message: 'Record Saved Succesfully.'
                    }, { type: 'success' });
                }
                else {
                    $('#mdlEditViewCoupon .close').click();

                    ListView(Id);
                    $.notify({
                        title: '',
                        message: 'An error has occured.'
                    }, { type: 'error' });
                }

            }
        });
        $('#mdlEditViewCoupon .close').click();
    }
    else {
        $("#lblCouponError").html("Please enter value for FirstName,LastName and Email");

    }
    waitingDialog.hide();

}



// To validate data entry for Voucher type
function FormValidateCoupon() {

    if ($("#txtEmail").val() == '' && $("#txtFirstName").val() == '' && $("#txtLastName").val() == '') {
        $("#lblCouponError").show();
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

    BindDropdown();
    BindTable();



    //$('#ddlInclProduct').multiselect();
    //$('#ddlExclProduct').multiselect();



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
            for (var i = 0; i < json.length ; i++) {
                $b.append("<option value=" + json[i].Id + ">" + json[i].CampaignName + "</option>").trigger('change');
            }
        }
    });




}



//Upload Section  
$("#Upload").change(function (e) {
                                  

    var fileUpload = document.getElementById("Upload");
    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.csv|.txt)$/;
    if (regex.test(fileUpload.value.toLowerCase())) {
                                 
                                 
        var path = URL.createObjectURL(e.target.files[0]);
        var data;
        $.ajax({
            type: "GET",
            url: path,
            dataType: "text",
            success: function (response) {
                                        
                data = $.csv.toArrays(response);
                generateHtmlTable(data);
            }
        });


    } else {
        alert("Please upload a valid CSV file.");
    }
});


function BufferData(data) {
    var html = '<table id="tb_BufferData" style="display:none;" class="table table-condensed table-hover table-striped">';

    if (typeof (data[0]) === 'undefined') {
        return null;
    } else {
        $.each(data, function (index, row) {
            html += '<tr id="' + index + '">';
            $.each(row, function (index, colData) {
                                             
                html += '<td>';
                html += colData;
                html += '</td>';

                                             
            });

            html += '</tr>';



        });

        html += '</tbody>';
        html += '</table>';
                                    
        $('#csv-display').append(html);


    }



}




function generateHtmlTable(data) {
    BufferData(data);
    var html = '<table id="tb_GetFieldsName"  class="table table-condensed table-hover table-striped">';

    if (typeof (data[0]) === 'undefined') {
        return null;
    } else {
        $.each(data, function (index, row) {
                                         
                                           
            $.each(row, function (index, colData) {
                html += '<tr id="'+index+'">';
                html += '<td>';
                html += colData;
                html += '</td>';

                html += '<td>';

                html += '<input type="radio" name="FieldName" value="Email" />Email';
                html += '</td>';
                html += '<td>';
                html += '<input type="radio" name="FieldEmail" value="FirstName" />FirstName';
                html += '</td>';
                html += '<td>';
                html += '<input type="radio" name="FieldLName" value="LastName" />LastName';
                html += '</td>';
                html += '</tr>';
            });
            return false;
            //}
        });
        html += '</tbody>';
        html += '</table>';
                                    
        $('#csv-display').append(html);
    }
}

