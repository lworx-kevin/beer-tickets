using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for bdcommon
/// </summary>
public class bdcommon
{
    public bdcommon()
    {
    }
    public static void getpermissions(string role,string permissions,string functionId,out bool canAdd, out bool canEdit, out bool canDelete, out bool canView, out string scriptString, out bool CanAppr)
    {
       
        canAdd = false;
        canEdit = false;
        canDelete = false;
        canView = false;
        CanAppr = false;
        scriptString = "";


        if (role == "1") //super admin
        {
            canAdd = true;
            canEdit = true;
            canDelete = true;
            canView = true;
            CanAppr = true;
        }
        else
        {
            string[] perArr = permissions.Split(',');

            if (perArr.Contains(functionId + "a")) canAdd = true;
            if (perArr.Contains(functionId + "e")) canEdit = true;
            if (perArr.Contains(functionId + "d")) canDelete = true;
            if (perArr.Contains(functionId + "v")) canView = true;
            if (perArr.Contains(functionId + "p")) CanAppr = true;
        }


        if (canAdd) { scriptString += "var canAdd=1;"; } else { scriptString += "var canAdd=0;"; }
        if (canEdit) { scriptString += "var canEdit=1;"; } else { scriptString += "var canEdit=0;"; }
        if (canDelete) { scriptString += "var canDelete=1;"; } else { scriptString += "var canDelete=0;"; }
        if (canView) { scriptString += "var canView=1;"; } else { scriptString += "var canView=0;"; }
        if (canView) { scriptString += "var CanAppr=1;"; } else { scriptString += "var CanAppr=0;"; }




    }

    public static string  getNavPath(string target)
    {
        string ret = "";

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); ;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "select module_id,module_title,function_title from view_portal_module_functions where lower(function_target)='" +target.ToLower()+"'";
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader sdr = com.ExecuteReader();

            if (sdr.Read())
            {
               ret= "<li><a href='/functions.aspx?module_id="+sdr.GetInt32(0).ToString()+"'>"+sdr.GetString(1)+" </a></li>";

               ret += "<li class='active'>"+sdr.GetString(2)+"</li>";

            }
        }

       return ret;
    }
    

}


