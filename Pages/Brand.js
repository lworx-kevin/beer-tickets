//On Image Change
$("#ImgBrand").on("change", function () {
    var files = !!this.files ? this.files : [];
    if (!files.length || !window.FileReader) return;// no file selected, or no FileReader support                
    var reader = new FileReader(); // instance of the FileReader
    reader.readAsDataURL(files[0]); // read the local file
    reader.onloadend = function (e) { // set image data as background of div
        $("#imgdisplay").attr("src", e.target.result);

    }
});




//When CreateNew is Clicked
function CreateNew(editid, view) {
    $("#btnCancel").html("Cancel")
    $("#lblError").hide();
    $('#StatusShow').show();
    $('#lblStatusText').show();
    $("#dvImgBrowse").show();
    var $select = $('#lblStatusText');
    $select.text("Status");
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $("[name='chkStatus']").bootstrapSwitch('state', false);



    $('#StatusShow').show();
    $("#btnSubmit").show();
    $("#frmMaster :input").prop("disabled", false);
    $("#lblentrymode").html("Create");
    $("#EntryMode").val('Add');
    $("#mdlCreate").attr("data-edit", "Add");
    $("#mdlCreate").attr("data-id", 0);
    $("#txtBrandName").val('');
    $("#ImgBrand").val('');
    $("#imgdisplay").attr("src", '');
    $("[name='chkStatus']").bootstrapSwitch('disabled', true);

    //$("#drpStatus").val(0);
    $("#dverror").empty();

    $('#mdlCreate').modal('show');
}

function ValidateCoupon(editid, view) {
    $("#btnCancel").html("Cancel")
    $("#lblError").hide();
    var $select = $('#lblStatusText');
    $select.text("Status");
    $select.show();
    $("#dvImgBrowse").hide();
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
        url: "CouponBrands.aspx/GetCouponBrandById",
        dataType: "json",
        data: JSON.stringify({ 'BrandId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {
            debugger;
            var json = eval(res.d);
            $("#txtBrandName").val(json[0].BrandName);
            //if (view == 1) {
            $("#imgdisplay").attr("src", 'http://portal.sunwingvouchers.com/media/' + json[0].BrandImage);
            $("#imgdisplay").css({ 'width': '150px', 'height': 'auto' });  // Set new height
            //$("#txtBrandName").val(json[0].BrandName);
            //$("#ImgBrand").val("http://portal.sunwingvouchers.com/media/" + json[0].BrandImage);
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

        $("#lblentrymode").html("View");
        $("#frmMaster :input").prop("disabled", true);
        $("#btnSubmit").hide();
        $select.show();
        $('#StatusShow').show();
        $("#btnCancel").prop("disabled", false)
        $("#mdlCreate").attr("data-edit", "view");
        $("#dvImgBrowse").hide();
        $("#btnCancel").html("Close");
                    
    }
    else {
        $("#dvImgBrowse").show();
        $("#btnCancel").html("Cancel")
        $("#lblentrymode").html("Modify");
        $("#frmMaster :input").prop("disabled", false);
        $select.hide();
        $('#StatusShow').hide();
        $("#btnSubmit").show();
        $("#EntryMode").val('Edit');
        $("#mdlCreate").attr("data-edit", "edit");
        $("#dvImgBrowse").show();

    }

    $("#mdlCreate").attr("data-id", '');
    $("#mdlCreate").attr("data-id", editid);
    $("[name='chkStatus']").bootstrapSwitch('disabled', false);
    $select.text('Status');

    var json;
    $.ajax({
        type: "POST",
        url: "CouponBrands.aspx/GetCouponBrandById",
        dataType: "json",
        data: JSON.stringify({ 'BrandId': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {
                     
            json = JSON.parse(res.d);
            $("[name='chkStatus']").bootstrapSwitch('state', json[0].Status == '1' ? true : false);
            $("[name='chkStatus']").bootstrapSwitch('disabled', true);
            $("#txtBrandName").val(json[0].BrandName);
            //if (view == 1) {
            $("#imgdisplay").attr("src", 'http://portal.sunwingvouchers.com/media/' + json[0].BrandImage);
            $("#imgdisplay").css({ 'width': '150px', 'height': 'auto' });  // Set new height
                            
            //var Img = 'http://portal.sunwingvouchers.com/media/' + json[0].BrandImage;
            //$('input[type="file"]').attr('value', Img);
            //$('#ImgBrand').val(Img);
            //$('#ImgBrand').attr('value',Img);
            //}
                        
        }

    });

    $('#mdlCreate').modal('show');

}

function readURL(input, Img) {
                
    var reader = new FileReader();
    reader.readAsDataURL(Img);
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
    var BrandName = $("#txtBrandName").val().trim();
    //var CouponPrefix = $("#ImgBrand").val().trim();
    // var Status = $("#lblStatus").text()== 'Approved' ? $("#chkStatus").'  1 : 0;

    var Status =  $("[name='chkStatus']").prop('checked') == true ? 1 : 0;
                
    if (window.FormData !== undefined) {
        var data = new FormData();
                    
                    
        var files = $("#ImgBrand").get(0).files;
                    
        if (files.length > 0) {
            var l = $("#imgdisplay").val();
            data.append("imgdisplay", files[0]);

            $.ajax({
                url: "http://portal.sunwingvouchers.com/upload.ashx",
                type: "POST",
                async: false,
                data: data,
                contentType: false,
                processData: false,
                success: function (result) { $("#imgdisplay").val(result); },
                error: function (err) {
                    alert(err.statusText)
                }
            });
        }
    } else { return false; }
    BrandImage = $("#imgdisplay").val();

             
    var Action = $("#mdlCreate").attr("data-edit");
    if (Validate()) {
        var Brand;
          







        var url = '';
        if ( Action == 'validate') {

            url = 'CouponBrands.aspx/InsertCouponBrand';
            var CouponBrand = {
                'BrandName': BrandName,
                'BrandImage': BrandImage,
                'Status': Status,
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }

        else if (Action == 'edit') {

            url = 'CouponBrands.aspx/InsertCouponBrand';
            var CouponBrand = {
                'BrandName': BrandName,
                'BrandImage': BrandImage,
                'Status': '0',
                'Id': $("#mdlCreate").attr("data-id"),
                'Action': $("#mdlCreate").attr("data-edit")
            };




        }




        else {

            url = 'CouponBrands.aspx/InsertCouponBrand';
            var CouponBrand = {
                'BrandName': BrandName,
                'BrandImage': BrandImage,
                'Status': Status,
                'Id': 0,
                'Action': 'Add'
            };
        }



        var dataToSend = JSON.stringify({ 'CouponBrand': CouponBrand });

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
                else if (data[0]== 'Exist') {
                    $('#mdlCreate .close').click();
                    BindTable();
                    $.notify({
                        title: '',
                        message: 'Brand Name must be unique.'
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
    if ($("#txtBrandName").val().toString().trim() == '') {
        $("#lblError").html("Please Enter Brand Name.");
        $("#lblError").show();
        return false;
    }
                

    return true;
}
          
 


          $(document).ready(function () {
              $("#lblError").hide();
              BindTable();


          });

