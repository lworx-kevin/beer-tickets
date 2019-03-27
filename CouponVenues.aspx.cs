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




public partial class CouponTypes : System.Web.UI.Page
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
    public static string GetCouponTypes()
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetCouponTypes();
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    [WebMethod]
    public static string InsertCouponTypes(Coupons.CouponType CouponType)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.InsertCouponTypes(CouponType);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    [WebMethod]
    public static string GetCouponTypeById(Int32 TypeId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetCouponTypeById(TypeId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    [WebMethod]
    public static string DeleteCouponTypeById(Int32 TypeId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.DeleteCouponTypeById(TypeId);
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
        public String Code { get; set; }
        public String Description { get; set; }
        public Int16 Status { get; set; }
        #endregion
    }
    #endregion
}