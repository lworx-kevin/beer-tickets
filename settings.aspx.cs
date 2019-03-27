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

public partial class settings : BaseClass
{
    public string navPath;
    public string moduleId;
    public string functionId;
    #region role management variables
    public bool canAdd;
    public bool canEdit;
    public bool canDelete;
    public bool canView;
    public string scriptString = "";
    public bool canAppr;

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
    public static string GetSettingData()
    {        
        //send id=0 for all data
        var data = BAL.Select_Setting(0);
     
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string GetSettingDataByID(int id)
    {
        //send id=0 for all data
        var data = BAL.Select_Setting(id);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string DeleteDataByID(int id)
    {
        //send id=0 for all data
        /*var data = BAL.Delete_Setting(id);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;*/
        return "";
    }

    [WebMethod]
    public static string AddSettingData(string setting_value)
    {

        var data = BAL.AddEdit_Setting(setting_value,0,1);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string EditSettingData(string setting_value, int id)
    {

        var data = BAL.AddEdit_Setting(setting_value, id,2);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }


}