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
using System.Data.SqlClient;
using System.Configuration;

public partial class Roles : BaseClass
{
    public string navPath;
    public string moduleId;
    public string rolesBlock;
    public string functionId;
    #region role management variables
    public bool canAdd;
    public bool canEdit;
    public bool canDelete;
    public bool canAppr;
    public bool canView;
    public string scriptString = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        functionInfo fInfo = new functionInfo(this.Page.ToString());
        navPath = fInfo.navInfo;
        moduleId = fInfo.moduleId;

        bdcommon.getpermissions(Session["role"].ToString(),
                Session["permissions"].ToString(), functionId, out canAdd,
                out canEdit, out canDelete, out canView, out scriptString, out canAppr);

        if ((!canAdd) && (!canEdit) && (!canDelete) && (!canView) && (!canAppr))
        {
            Response.Redirect("/");
        }

        if (!IsPostBack)
        {
            setRolesBlock();

        }

    }
    public void setRolesBlock()
    {
       

        //get modules

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString + ";MultipleActiveResultSets=True";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand com = new SqlCommand("select id,title from portal_modules order by title", conn);
            SqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
               /* rolesBlock += "<br/><div class='row'>";
                rolesBlock += "<div class='col-md-12'><b>" + sdr.GetString(1) + "</b><hr style='margin-top:0px;'/></div>";
                rolesBlock += "</div>";*/

                rolesBlock += "<br/><br/><div class='row'>";
                rolesBlock += "<div class='col-md-4'><b>" + sdr.GetString(1) + "</b></div>";
                rolesBlock += "<div class='col-md-1'>Add</div>";
                rolesBlock += "<div class='col-md-1'>Edit</div>";
                rolesBlock += "<div class='col-md-2'>Approver</div>";
                rolesBlock += "<div class='col-md-2'>Delete</div>";
                rolesBlock += "<div class='col-md-2'>View</div>";
                rolesBlock += "</div><hr style='margin-bottom:0px;margin-top:0px;'/>";
                SqlCommand func_com = new SqlCommand("select id,title from portal_functions where module_id="+sdr.GetInt32(0).ToString()+"  order by title", conn);
                SqlDataReader func_sdr = func_com.ExecuteReader();
                while (func_sdr.Read())
                {
                    rolesBlock += "<div class='row'>";
                    rolesBlock += "<div class='col-md-4'>" + func_sdr.GetString(1) + "</div>";
                    rolesBlock += "<div class='col-md-1'><input type='checkbox' class='functions' name='func' value='" + func_sdr.GetInt32(0).ToString() + "a' /></div>";
                    rolesBlock += "<div class='col-md-1'><input type='checkbox' class='functions' name='func' value='" + func_sdr.GetInt32(0).ToString() + "e' /></div>";
                    rolesBlock += "<div class='col-md-2'><input type='checkbox' class='functions' name='func' value='" + func_sdr.GetInt32(0).ToString() + "p' /></div>";

                    rolesBlock += "<div class='col-md-2'><input type='checkbox' class='functions' name='func' value='" + func_sdr.GetInt32(0).ToString() + "d' /></div>";
                    rolesBlock += "<div class='col-md-2'><input type='checkbox' class='functions' name='func' value='" + func_sdr.GetInt32(0).ToString() + "v' /></div>";
                    rolesBlock += "</div>";

                    //rolesBlock += "<div class='col-md-6'><input id='func"+func_sdr.GetInt32(0).ToString()+ "' type='checkbox' class='functions' name='func' value='" + func_sdr.GetInt32(0).ToString() + "' />&nbsp;<label id='lblfunctin" + func_sdr.GetInt32(0).ToString() + "'  for='func" + func_sdr.GetInt32(0).ToString() + "'> "+func_sdr.GetString(1)+"</label></div>";
                }
               
            }
            //get functions
        }

       
    }
    [WebMethod]
    public static string GetUserRoleData()
    {
        //send id=0 for all data
        var data = BAL.Select_UserRole(0);

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
        var data = BAL.Select_UserRole(id);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string AddData(string name, string functions)
    {

        var data = BAL.AddEdit_UserRoles(name,functions, 0, 1);

        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
        HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

        return data;
    }

    [WebMethod]
    public static string EditData(string name, string functions,int id)

    {
        try
        {
            var data = BAL.AddEdit_UserRoles(name, functions, id, 2);

            HttpContext context = HttpContext.Current;
            context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
            HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
            HttpContext.Current.Response.ContentType = "application/json charset=utf-8";

            return data;
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }
}