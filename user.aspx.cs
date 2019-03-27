using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.IO.Compression;
using System.Globalization;
using System.Text;

public partial class user : BaseClass
{
    public string navPath;
    public string moduleId;
    public string functionId;
    #region role management variables
    public bool canAdd;
    public bool canEdit;
    public bool canDelete;
    public bool canView; public bool canAppr;
    public string scriptString = "";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        functionInfo fInfo = new functionInfo(this.Page.ToString());
        navPath = fInfo.navInfo;
        moduleId = fInfo.moduleId;
        functionId = fInfo.functionId;

        bdcommon.getpermissions(Session["role"].ToString(),
                Session["permissions"].ToString(), functionId, out canAdd,
                out canEdit, out canDelete, out canView, out scriptString,out canAppr);

        if ((!canAdd) && (!canEdit) && (!canDelete) && (!canView))
        {
            Response.Redirect("/");
        }


    }


    [WebMethod]
    public static String DeleteuserbyId(Int32 UserId)
    {
        var data = Ddatatable.DeleteuserbyId(UserId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }
    [WebMethod]
    public static string GetUserRoleData()
    {
        //send id=0 for all data
        var data = BAL.Select_UserRoleID(0);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string GetUserAdminData()
    {
        //send id=0 for all data
        var data = BAL.Select_UserAdminData(0);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string GetUserAdminDataByID(int id)
    {
        //send id=0 for all data
        var data = BAL.Select_UserAdminData(id);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string AddUserAdminData(string username, string password, string givenname, string familyname, string auth, int roleid)
    {
        String NewPwd = Cryption.GetEncryptedSHA256(password);
        var data = BAL.AddEdit_UserAdmin(username, NewPwd, givenname, familyname, auth, roleid, 0, 1);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string EditUserAdminData(string username, string password, string givenname, string familyname, string auth, int roleid, int id)
    {
        String NewPwd = Cryption.GetEncryptedSHA256(password);
        var data = BAL.AddEdit_UserAdmin(username, NewPwd, givenname, familyname, auth, roleid, id, 2);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }
}