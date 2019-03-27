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
using System.IO;
using System.Globalization;
using System.Text;


public partial class CouponValue : System.Web.UI.Page
{
    #region Global Variables
    public string navPath;
    public string moduleId;
    public string functionId;
    public bool canAdd;
    public bool canEdit;
    public bool canDelete;
    public bool canView;
    public string scriptString = "";
    public bool canAppr;

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        functionInfo fInfo = new functionInfo(this.Page.ToString());
        navPath = fInfo.navInfo;
        moduleId = fInfo.moduleId;
        functionId = fInfo.functionId;
        if (Session["login"] != null)
        {
            bdcommon.getpermissions(Session["role"].ToString(), Session["permissions"].ToString(), functionId, out canAdd, out canEdit, out canDelete, out canView, out scriptString,out canAppr);
            if ((!canAdd) && (!canEdit) && (!canDelete) && (!canView)) { Response.Redirect("/"); }

        }
        else

        {
            Response.Redirect("/login.aspx");
        }


    }

    #endregion

    #region Web Methods
    [WebMethod]
    public static string GetCouponValue()
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetCouponValue();
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    [WebMethod]
    public static string InsertCouponValue(Coupons.CouponValue CouponValue)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.InsertCouponValue(CouponValue);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    [WebMethod]
    public static string GetCouponValueById(Int32 ValueId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetCouponValueById(ValueId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    [WebMethod]
    public static string DeleteCouponValueById(Int32 ValueId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.DeleteCouponValueById(ValueId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }
    #endregion

    #region Classes
    public class CouponType
    {

        #region Properties
        public String Label { get; set; }
        public String Value { get; set; }
        public Int16 Status { get; set; }
        #endregion
    }
    #endregion
}