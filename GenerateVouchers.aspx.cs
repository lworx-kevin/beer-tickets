using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenerateVouchers : System.Web.UI.Page
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
    public bool AlreadySend;
    public string scriptString = "";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Ddatatable Ddata = new Ddatatable();
        functionInfo fInfo = new functionInfo(this.Page.ToString());
        navPath = fInfo.navInfo;
        moduleId = fInfo.moduleId;
        functionId = fInfo.functionId;
        if (Session["login"] != null)
        {
            bdcommon.getpermissions(Session["role"].ToString(), Session["permissions"].ToString(), functionId, out canAdd, out canEdit, out canDelete, out canView, out scriptString, out canAppr);
            if ((!canAdd) && (!canEdit) && (!canDelete) && (!canView)) { Response.Redirect("/"); }

        }
        else
        {
            Response.Redirect("/login.aspx");
        }



    }

    [WebMethod]
    public static string InsertBulkVoucherWithCampaign(VOCampaign VOCampaign, List<GridDataArray> GridDataArray)
    {
       
       var data = Ddatatable.InsertVoucherWithCampaign(VOCampaign,GridDataArray);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    
        
    }



    [WebMethod]
    public static string GetVouchersWithCampaign()
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetVouchersWithCampaign();
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

    [WebMethod]
    public static string GetVouchersCampaignById(Int32 Id)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.GetVouchersCampaignById(Id);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }

       [WebMethod]
    public static string DeleteVoucherWithCampaignbyId(Int32 GenId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.DeleteVoucherWithCampaignbyId(GenId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }
    
           [WebMethod]
       public static string SendVoucherWithCampaignbyId(Int32 GenId)
    {

        //send id=0 for all data
        //var data = BAL.Select_Brands(0);
        var data = Ddatatable.SendVoucherWithCampaignbyId(GenId);
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
        return data;
    }




    #endregion

           #region Coupon generatiion

           [WebMethod]
           public static string DeleteCouponById(Int32 Id)
           {

               //send id=0 for all data
               //var data = BAL.Select_Brands(0);
               var data = Ddatatable.DeleteCouponById(Id);
               HttpContext context = HttpContext.Current;
               context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
               HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
               HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
               return data;
           }

           [WebMethod]
           public static string EditGenerateCouponData(CouponGeneration CouponGeneration)
           {

               var data = Ddatatable.EditGenerateCouponData(CouponGeneration);
               HttpContext context = HttpContext.Current;
               context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
               HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
               HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
               return data;


           }
           [WebMethod]
           public static string GetCouponById(Int32 Id)
           {

               //send id=0 for all data
               //var data = BAL.Select_Brands(0);
               var data = Ddatatable.GetCouponById(Id);
               HttpContext context = HttpContext.Current;
               context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
               HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
               HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
               return data;
           }
           [WebMethod]
           public static string GetVCouponsListing(Int32 Id)
           {

               //send id=0 for all data
               //var data = BAL.Select_Brands(0);
               var data = Ddatatable.GetVCouponsListing(Id);
               HttpContext context = HttpContext.Current;
               context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
               HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
               HttpContext.Current.Response.ContentType = "application/json charset=utf-8";
               return data;
           }
           #endregion
}