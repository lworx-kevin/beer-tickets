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

public partial class MenuCategories : BaseClass
{
    public string navPath;
    public string moduleId;
    public string functionId;
    protected void Page_Load(object sender, EventArgs e)
    {

        functionInfo fInfo = new functionInfo(this.Page.ToString());
        navPath = fInfo.navInfo;
        moduleId = fInfo.moduleId;
        functionId = fInfo.functionId;

    }

    [WebMethod]
    public static string GetMenuCategoriesData()
    {
        //send id=0 for all data
        var data = BAL.Select_MenuCategorie(0);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string GetByID(int id)
    {
        //send id=0 for all data
        var data = BAL.Select_MenuCategorie(id);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string AddData(int priority, string name, string image ,string lastmodified) 
    {

        var data = BAL.AddEdit_MenuCategorie(priority,name,image,lastmodified, 0, 1);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string EditData(int priority, string name, string image, string lastmodified, int id)

    {

        var data = BAL.AddEdit_MenuCategorie(priority, name, image, lastmodified, id, 2);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }
}