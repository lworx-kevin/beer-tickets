using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Services;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;

public class jdataTable
{
    public jdataTable()
    { }
  
    public static string getJSON(string query)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
       try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    dtReturn = MetroBusdb.GetDataTable(sqlcmd, out isDeadLock);

                    if (isDeadLock && count <= 3)
                    {
                        count++;
                        goto AGAIN;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            MetroBusdb.CloseConnection(SqlCon);
            SqlCon.Dispose();
            SqlCon = null;
            GC.Collect();
        }
        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(dtReturn);

        return JSONString;

    }
    public static string getBrands()
    {
        return getJSON("SELECT  brand_id, long_name,short_name,CASE active WHEN 1 THEN 'Yes' WHEN 0 THEN 'No' END AS status FROM dbo.crm_brands order by brand_id desc");
    }

    public static string getSlides()
    {
        return getJSON("Select id,en_heading,active,CASE active when NULL then 'NA' WHEN 1 THEN 'Yes' WHEN 0 THEN 'No' END AS status  From cms_sliders order by id desc");
    }

    public static string getPages()
    {
        return getJSON("select id,title_en,CASE status WHEN 1 THEN 'Active' WHEN 0 THEN 'Inactive' END AS status from crm_pages");
    }

    public static string getNews()
    {
        return getJSON("Select id,en_newsitem,CASE active WHEN 1 THEN 'Yes' WHEN 2 THEN 'No' END AS status, CASE main_page WHEN 1 THEN 'Yes' WHEN 2 THEN 'No' END AS main_page, (select resort_name from crm_resorts where resort_id=n.resort_id) as resort_name  From cms_news n");
    }

    public static string getAssets()
    {
        string sql = @"SELECT        dbo.crm_assets.id, dbo.crm_assets.en_title, dbo.crm_brands.short_name AS brandName, dbo.crm_resorts.resort_name, dbo.crm_assets_category.en_title AS categoryName, 
                         dbo.crm_assets_grouping.grouping_en AS groupName, CASE crm_assets.status WHEN 1 THEN 'Active' WHEN 0 THEN 'Inactive' END AS active,crm_assets.low_resolution
                        FROM            dbo.crm_assets INNER JOIN
                         dbo.crm_assets_category ON dbo.crm_assets.category_id = dbo.crm_assets_category.id INNER JOIN
                         dbo.crm_brands ON dbo.crm_assets.brand_id = dbo.crm_brands.brand_id INNER JOIN
                         dbo.crm_resorts ON dbo.crm_assets.resort_id = dbo.crm_resorts.resort_id INNER JOIN
                         dbo.crm_assets_grouping ON dbo.crm_assets.grouping_id = dbo.crm_assets_grouping.id ";
        return getJSON(sql);
    }
    public static string getGroups()
    {
        string sql = @" select id, grouping_en, grouping_fr, grouping_es from [dbo].[crm_assets_grouping] with(nolock)";
        return getJSON(sql);
    }
    public static string getResorts()
    {
        string sql = @"SELECT        dbo.crm_resorts.resort_id, dbo.crm_resorts.resort_name, dbo.crm_brands.short_name AS brandName, CASE crm_resorts.booking_active WHEN 1 THEN 'Yes' WHEN 0 THEN 'No' END AS booking_active, 
                         CASE crm_resorts.pms_active WHEN 1 THEN 'Yes' WHEN 0 THEN 'No' END AS pms_active, CASE crm_resorts.adults_only_flag WHEN 1 THEN 'Adults Only' WHEN 0 THEN '' END AS adults_only_flag, 
                         CASE crm_resorts.all_ages_flag WHEN 1 THEN 'All Ages' WHEN 0 THEN '' END AS all_ages_flag, dbo.crm_resorts.pms_last_connect
                         FROM            dbo.crm_brands INNER JOIN
                         dbo.crm_resorts ON dbo.crm_brands.brand_id = dbo.crm_resorts.brand_id";
        return getJSON(sql);
    }
    public static string getRoomTypes()
    {
        string sql = @"SELECT    dbo.pms_roomtypes.roomtype_id ,     dbo.crm_resorts.resort_name, dbo.pms_roomtypes.roomtypecode, dbo.pms_roomtypes.roomtypecategory, dbo.pms_roomtypes.roomtypedescription
                        FROM            dbo.pms_roomtypes INNER JOIN
                        dbo.crm_resorts ON dbo.pms_roomtypes.resort_id = dbo.crm_resorts.resort_id   ";
        return getJSON(sql);
    }
    public static string getAgencies()
    {
        string sql = @"SELECT        agency_id, agency_short_name, agency_city, agency_state, agency_postal, CASE agency_status WHEN 1 THEN 'active' WHEN 2 THEN 'Inactive' END AS status
                    FROM            dbo.crm_agency";
        return getJSON(sql);
    }

    public static string getAgents()
    {
        string sql = @"SELECT        dbo.crm_agents.agent_id, dbo.crm_agents.agent_user_name, dbo.crm_agents.agent_email, dbo.crm_agents.agent_givenname, dbo.crm_agents.agent_lastname, dbo.crm_agency.agency_short_name, 
                         dbo.crm_agents.agent_city, dbo.crm_agents.agent_state, dbo.crm_agents.agent_postal, dbo.crm_agents.agent_status, dbo.states.state
FROM            dbo.crm_agents INNER JOIN
                         dbo.crm_agency ON dbo.crm_agents.agency_id = dbo.crm_agency.agency_id INNER JOIN
                         dbo.states ON dbo.crm_agents.agent_state = dbo.states.id";
        return getJSON(sql);

    }
    public static string getPromotions()
    {
        string sql = @"SELECT      promo_id,  promo_name, base_points, points_multiplier, booking_start_date, booking_end_date, travel_start_date, travel_end_date, CASE reward_promo WHEN 1 THEN 'Reward' WHEN 0 THEN '' END AS reward_promo, 
                         CASE bonus_promo WHEN 1 THEN 'Bonus' WHEN 0 THEN '' END AS bonus_promo, CASE active WHEN 1 THEN 'Yes' WHEN 0 THEN 'No' END AS active
                        FROM            dbo.crm_promotions";
        return getJSON(sql);

    }
    public static string getAwardPoints()
    {
        string sql = @"SELECT     dbo.award_points.award_id,   dbo.crm_agents.agent_email, dbo.crm_resorts.resort_name, dbo.crm_booking.book_rez, dbo.award_points.points, dbo.award_points.award_timestamp, 
                         CASE award_points.confirmed WHEN 0 THEN 'Confirmed' WHEN 1 THEN 'Pending' END AS confirmed
                        FROM            dbo.award_points INNER JOIN
                         dbo.crm_agents ON dbo.award_points.agent_id = dbo.crm_agents.agent_id INNER JOIN
                         dbo.crm_resorts ON dbo.award_points.resort_id = dbo.crm_resorts.resort_id INNER JOIN
                         dbo.crm_booking ON dbo.award_points.booking_id = dbo.crm_booking.booking_id";
        return getJSON(sql);
    }

    public static string getBookings()
    {
        string sql = @"SELECT       dbo.crm_booking.booking_id, dbo.crm_booking.book_date, dbo.crm_resorts.resort_code, dbo.crm_booking.book_rez, dbo.crm_booking.pms_book_rez, dbo.crm_agents.agent_email,crm_booking.book_check_in,crm_booking.book_check_out
                    FROM            dbo.crm_booking INNER JOIN
                         dbo.crm_resorts ON dbo.crm_booking.resort_id = dbo.crm_resorts.resort_id INNER JOIN
                         dbo.crm_agents ON dbo.crm_booking.agent_id = dbo.crm_agents.agent_id";
        return getJSON(sql);
    }


 
}
    
