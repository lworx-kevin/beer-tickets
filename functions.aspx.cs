using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

public partial class functions : BaseClass
{
    public StringBuilder sB = new StringBuilder();
    public string module_title;
    public string module_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        //getting Main Menu
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); ;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "select module_title,module_bgcolor,function_title,function_icon,function_target,module_id from view_portal_module_functions where module_id=" + Request.Params["module_id"].ToString() + "";

            if (Session["role"].ToString() != "1")
            {

                sql = "select module_title,module_bgcolor,function_title,function_icon,function_target,module_id from view_portal_module_functions where module_id=" + Request.Params["module_id"].ToString() + " and function_id in(" + Session["permissionscsv"].ToString() + ")";
            }
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader sdr = com.ExecuteReader();

            int functionCount = 1;

            while (sdr.Read())
            {
              
                string module_bgcolor = "";
                string function_title = "";
                string function_icon = "";
                string function_target = "";

                if (!sdr.IsDBNull(0)) module_title = sdr.GetString(0);
                if (!sdr.IsDBNull(1)) module_bgcolor = sdr.GetString(1);
                if (functionCount % 2 == 0)
                {
                    module_bgcolor = "#e4d08b";
                }

                if (!sdr.IsDBNull(2)) function_title = sdr.GetString(2);
                if (!sdr.IsDBNull(3)) function_icon = sdr.GetString(3);
                if (!sdr.IsDBNull(4)) function_target = sdr.GetString(4);
                if (!sdr.IsDBNull(5)) module_id = sdr.GetInt32(5).ToString();
                sB.Append("	 <div class ='col-lg-3' >");
                sB.Append("<a href='" + function_target + "'>");

                sB.Append("	 <div id ='Functions' >");
                sB.Append("	<div class='panel  panel-widget '  style='background-color:" + module_bgcolor + " !important;border-radius: 5%!important;'>");
                sB.Append("	 <div class='row no-padding'>");
                sB.Append("	   <div class='col-lg-3 col-md-3 col-sm-3'>");
                sB.Append("	 </div>");
                sB.Append("	  <div class=''>");
                sB.Append("	<img src='icons/" + function_icon + "' class='navNewIcon'>");
                sB.Append("	 </div>");
                sB.Append("	</div>");
                sB.Append("	  <div >");
                sB.Append("	<div class='large bd_panel_text'>" + function_title + "</div>");
                sB.Append("	</div>");

                sB.Append("	</div>");
                sB.Append("	</div>");
                sB.Append("	 </div>");

                //sB.Append("	    <div class='col-xs-12 col-md-6 col-lg-6'>");
                //sB.Append("		    <div class='panel  panel-widget '>");
                //sB.Append("			    <div class='row no-padding'>");
                //sB.Append("				    <div class='col-sm-3 col-lg-3 widget-left'>");
                //sB.Append("					    <img src='icons/" + function_icon + "'  class='navIcon'/>");
                //sB.Append("				    </div>");
                //sB.Append("				    <div class='col-sm-9 col-lg-9 widget-right' style='background-color:" + module_bgcolor + " !important'>");
                //sB.Append("					    <div class='large bd_panel_text'>" + function_title + "</div>");
                //sB.Append("				    </div>");
                //sB.Append("			    </div>");
                //sB.Append("		    </div>");
                //sB.Append("	    </div>");
                sB.Append("</a>");
                functionCount++;
            }
        }
    }
}