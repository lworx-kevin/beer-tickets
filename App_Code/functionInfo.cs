using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for functionInfo
/// </summary>
public class functionInfo
{
    public functionInfo(string target)
    {
        
        target= target.Substring(4, target.Substring(4).Length - 5) + ".aspx";
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); ;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "select module_id,module_title,function_id,function_title from view_portal_module_functions where lower(function_target)='" + target.ToLower() + "'";
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader sdr = com.ExecuteReader();

            if (sdr.Read())
            {
                navInfo = "<li><a href='/functions.aspx?module_id=" + sdr.GetInt32(0).ToString() + "'>" + sdr.GetString(1) + " </a></li>";

                navInfo += "<li class='active'>" + sdr.GetString(3) + "</li>";

                moduleId = sdr.GetInt32(0).ToString();
                moduleName = sdr.GetString(1);
                functionId = sdr.GetInt32(2).ToString();
                functionName = sdr.GetString(3);

            }
        }
    }
    public string navInfo { get; set; }
    public string moduleId { get; set; }
    public string moduleName { get; set; }
    public string functionId { get; set; }
    public string functionName { get; set; }

}