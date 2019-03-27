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

public partial class CouponBrands : System.Web.UI.Page
{
    #region Global Variables
    public string navPath;
    public string moduleId;
    public string functionId;
    public bool canAdd;
    public bool canEdit;
    public bool canDelete;
    public bool canView;
    public bool canAppr;
    public string scriptString = "";
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

    /// <summary>
    /// This method fetches all non-deleted coupon brand from database without applying any filter
    /// </summary>
    /// <returns>List of object in json format</returns>

    [WebMethod]
    public static string GetCouponBrands()
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetCouponBrands();
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    /// <summary>
    /// This method inserts Coupon Brand into database
    /// </summary>
    /// <param name="Object of CouponBrand Class"></param>
    /// <returns>Return Json Result as Success or Failure</returns>
    [WebMethod]
    public static string InsertCouponBrand(Coupons.CouponBrand CouponBrand)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.InsertCouponBrand(CouponBrand);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }


    /// <summary>
    /// This method fetches coupon brand data for edit and view purposes
    /// </summary>
    /// <param name="BrandId"></param>
    /// <returns>Return the  row matching with id from the database </returns>

    [WebMethod]
    public static string GetCouponBrandById(Int32 BrandId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetCouponBrandById(BrandId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    /// <summary>
    /// This method will update the amtching record with Cancelled status i.e -1
    /// </summary>
    /// <param name="BrandId"></param>
    /// <returns>Return status as Success or Failure</returns>
    [WebMethod]
    public static string DeleteCouponBrandById(Int32 BrandId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.DeleteCouponBrandById(BrandId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }
    #endregion
}