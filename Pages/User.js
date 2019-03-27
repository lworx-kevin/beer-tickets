
$(document).ready(function () {
    var json;
    var $b = $('#Role_id');
    $.ajax({
        type: "POST",
        url: "user.aspx/GetUserRoleData",
        dataType: "json",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (msg) {
            json = JSON.parse(msg.d);
            $b.empty();
            $b.append("<option value= 0 >-- Select --</option>");
            for (var i = 0; i < json.length ; i++) {
                $b.append("<option value=" + json[i].id + ">" + json[i].name + "</option>").trigger('change');
            }
        }
    });
});

$(document).ready(function () {                
    BindTable();
});

$("#uname")
.focusout(function () {
    if (!isValidEmailAddress($("#uname").val())) {
        $("#lblEError").show();
        $("#lblEError").html("INVALID EMAIL ID")
        return false;
    }
    else
    {
        $("#lblEError").hide();
        $("#lblEError").html("")
        return true;
    }
})
function isValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);
    // alert( pattern.test(emailAddress) );
    return pattern.test(emailAddress);
};

function CreateNew() {
    $("#lblEError").hide();
    $("#lblError").hide();
    $("#lblentrymode").html("Create");
    $("#EntryMode").val('Add');         
    $("#dverror").empty();           
    $("#uname").val('');
    $("#password").val('');
    $("#givenname").val('');
    $("#familyname").val('');
    $("#auth").val('');           
    $('#myModal').modal('show');
    $("#Role_id").val(0).trigger('change');
}

      

function hideModel() {
    $('#myModal').modal('hide');
}
function EditEntry(editid, view) {
    $("#lblEError").hide();
    $("#lblError").hide();
    if (view == 1) {
        $("#lblentrymode").html("View");
        $("#frmMaster :input").prop("disabled", true);
        $("#btnSubmit").hide();
        $("#btnCancel").prop("disabled", false)
    }
    else {
        $("#lblentrymode").html("Modify");
        $("#frmMaster :input").prop("disabled", false);
        $("#btnSubmit").show();
    }
    //$("#lblentrymode").html("Modify");            
    $("#dverror").empty();
    $("#EntryMode").val('Edit');
    var json;
    $.ajax({
        type: "POST",
        url: "user.aspx/GetUserAdminDataByID",
        dataType: "json",
        data: JSON.stringify({ 'id': editid }),
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function (res) {
            json = JSON.parse(res.d);
            $("#uname").val(json[0].username);
            $("#password").val(json[0].password);
            $("#givenname").val(json[0].givenname);
            $("#familyname").val(json[0].familyname);
            $("#auth").val(json[0].auth);
            $("#Role_id").val(json[0].role_id).trigger('change');
                    
                    
            $("#id").val(json[0].id);
        }
    });
            
    $('#myModal').modal('show');
}




function SaveEntry() {

    var username = $("#uname").val();
    var password = $("#password").val();
    var givenname = $("#givenname").val();
    var familyname = $("#familyname").val();
    var auth = $("#auth").val();
    var roleid = $("#Role_id").val();

    var id = $("#id").val();
   
    if (username != '' && password != '' && isValidEmailAddress($("#uname").val())==true) {
        if (roleid != '' && roleid != '0') {
            var url = '';
            if ($("#EntryMode").val() == 'Add') {
                url = 'user.aspx/AddUserAdminData';
            } else {
                url = 'user.aspx/EditUserAdminData';
            }

            $.ajax({
                type: "POST",
                url: url,
                dataType: "json",
                data:
                    JSON.stringify({
                        'username': username,
                        'password': password,
                        'givenname': givenname,
                        'familyname': familyname,
                        'auth': auth,
                        'roleid': roleid,

                        'id': id
                    }),
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (msg) {
                    $('#myModal').modal('hide');
                    var data = eval(msg.d)
                    if (data == 'Success') {
                        BindTable();
                        $.notify({
                            title: '',
                            message: 'Record Save Succesfully.'
                        }, { type: 'success' });
                    }
                    else
                    {
                        $.notify({
                            title: '',
                            message: 'UserName and Password combination already exists.'
                        }, { type: 'warning' });
                    }

                }
            });
        }
        else {
            $("#lblError").show();
            $("#lblError").html("Please select role.");

        }
    }
    else {
        $("#lblError").show();
        $("#lblError").html("Please enter username and password");

    }
}

      

