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

public partial class VGC : System.Web.UI.MasterPage
{

    public StringBuilder sB= new StringBuilder();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        object uname = Session["login"] as object;
        if (uname == null || uname.ToString() == "")
        {
             Response.Redirect("Login.aspx");
        }
        else {
            username.Text = uname.ToString();
        }







        string sql = @"	WITH cte 
     AS (SELECT  module_id,module_title,module_icon,Row_number() 
                  OVER ( 
                    partition BY module_id 
                    ORDER BY Cast(module_id AS INT) DESC) rn from view_portal_module_functions 
                 ) 
SELECT  module_id,module_title,module_icon
FROM   cte 
WHERE  rn = 1 
order by
		case module_id
        when 11 then 1
        when 12 then 2
        when 5 then 3
        when 10 then 4
		when 2 Then 5
        when 6 then 6

    end";


       



        if(Session["role"].ToString()!= "1")
        { 
            
            sql = "SELECT distinct(module_id),module_title,module_icon from view_portal_module_functions where function_id in(" + Session["permissionscsv"].ToString()  + ") ";
        }


        //getting Main Menu
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); 
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            //string sql = "select * from portal_modules where id in(select distinct module_id from  where id in(permissions))";
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader sdr = com.ExecuteReader();
         
            while (sdr.Read())
            {
                int moduleId = 1;
                string moduleicon = "";
                string moduleTitle = "";
                if (!sdr.IsDBNull(0)) moduleId = sdr.GetInt32(0);
                if (!sdr.IsDBNull(1)) moduleTitle = sdr.GetString(1);
                if (!sdr.IsDBNull(2)) moduleicon = sdr.GetString(2);

                sB.Append("<li class='menu_item' id='module"+moduleId.ToString()+"'><a href = '/functions.aspx?module_id="+moduleId.ToString()+"'> <img src='icons/"+ moduleicon + "' class='navIcon' /> "+moduleTitle+"</a></li>");
            }
        }
    }



    
}
