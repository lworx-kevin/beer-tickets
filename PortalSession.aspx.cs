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

public partial class PortalSession : BaseClass
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
    public static string GETAdminLog()
    {
        //send id=0 for all data
        var data = BAL.Select_AdminLogView(0);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }
}