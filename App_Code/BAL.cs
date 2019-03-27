using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Services;
using System.Reflection;
using System.Text;
using System.Configuration;
using Dapper;

/// <summary>
/// Summary description for BAL
/// </summary>
public partial class BAL
{
    static IDbConnection db;
    public static DataTable Login(string Uname, string Pass)
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
                using (SqlCommand sqlcmd = new SqlCommand("select  username,role_id,functions,id  from view_portal_users_roles where username =@Uname AND password =@Pass", SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "Uname", SqlDbType.VarChar, Uname);
                    MetroBusdb.AddInParameter(sqlcmd, "Pass", SqlDbType.VarChar, Pass);

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
        //string JSONString = string.Empty;
        //JSONString = JsonConvert.SerializeObject(dtReturn);
        return dtReturn;

    }

    public static string Select_Brands(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_brands where brand_id =@id";
        }
        else
        {
            query = "select * from crm_brands";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_PortalContent(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_pages where id =@id";
        }
        else
        {
            query = "select * from crm_pages";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    #region Delete Functions
    public static string Delete_Brands(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_brands where brand_id =@id";
        }
        else
        {
            query = "Delete  from crm_brands where brand_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_News(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from cms_news where id =@id";
        }
        else
        {
            query = "Delete  from cms_news where id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_ResortImage(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_images where image_id =@id";
        }
        else
        {
            query = "Delete  from crm_images where image_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_ResortCard(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_tentcards where tentcard_id =@id";
        }
        else
        {
            query = "Delete  from crm_tentcards where tentcard_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_Regions(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_regions where region_id =@id";
        }
        else
        {
            query = "Delete  from crm_regions where region_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_Resorts(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_resorts where resort_id =@id";
        }
        else
        {
            query = "Delete  from crm_resorts where resort_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_roomtype(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from pms_roomtypes where roomtype_id =@id";
        }
        else
        {
            query = "Delete  from pms_roomtypes where roomtype_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_TTOP(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_ttoo where ttoo_id =@id";
        }
        else
        {
            query = "Delete  from crm_ttoo where ttoo_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_Slides(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from cms_sliders where id =@id";
        }
        else
        {
            query = "Delete  from cms_sliders where id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_CrmPages(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_pages where id =@id";
        }
        else
        {
            query = "Delete  from crm_pages where id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    #endregion

    public static string AddEdit_Brands
        (string short_name, string long_name, string logo, string description_title, string description_content, string map, string facebook_url, string twitter_url, string instagram_url, string google_url,
        string youtube_url, string pinterest_url, int adults_only_flag, int all_ages_flag,bool brandStatus,
        int id, int status)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_brands  ";
            query += "(short_name,long_name,description_title ,description_content,facebook_url, twitter_url,instagram_url ,google_url ,youtube_url,pinterest_url,adults_only_flag, all_ages_flag ,logo,map,active )";
            query += " VALUES ";
            query += " ( @short_name ,@long_name,@description_title ,@description_content,@facebook_url, @twitter_url,@instagram_url ,@google_url ,@youtube_url,@pinterest_url,@adults_only_flag, @all_ages_flag ,@logo ,@map,@active)";
        }
        else {
            query = "UPDATE crm_brands SET   ";
            query += "short_name = @short_name, long_name = @long_name ,description_title = @description_title , description_content = @description_content ,facebook_url = @facebook_url ,twitter_url = @twitter_url, ";
            query += "instagram_url = @instagram_url ,google_url = @google_url ,youtube_url = @youtube_url ,pinterest_url = @pinterest_url , adults_only_flag = @adults_only_flag ,all_ages_flag = @all_ages_flag ,logo=@logo ,map=@map ,active=@active";
            query += " Where brand_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "short_name", SqlDbType.VarChar, short_name);
                    MetroBusdb.AddInParameter(sqlcmd, "long_name", SqlDbType.VarChar, long_name);
                    MetroBusdb.AddInParameter(sqlcmd, "description_title", SqlDbType.VarChar, description_title);
                    MetroBusdb.AddInParameter(sqlcmd, "description_content", SqlDbType.VarChar, description_content);
                    MetroBusdb.AddInParameter(sqlcmd, "facebook_url", SqlDbType.VarChar, facebook_url);
                    MetroBusdb.AddInParameter(sqlcmd, "twitter_url", SqlDbType.VarChar, twitter_url);
                    MetroBusdb.AddInParameter(sqlcmd, "instagram_url", SqlDbType.VarChar, instagram_url);
                    MetroBusdb.AddInParameter(sqlcmd, "google_url", SqlDbType.VarChar, google_url);
                    MetroBusdb.AddInParameter(sqlcmd, "youtube_url", SqlDbType.VarChar, youtube_url);
                    MetroBusdb.AddInParameter(sqlcmd, "pinterest_url", SqlDbType.VarChar, pinterest_url);
                    MetroBusdb.AddInParameter(sqlcmd, "adults_only_flag", SqlDbType.Int, adults_only_flag);
                    MetroBusdb.AddInParameter(sqlcmd, "all_ages_flag", SqlDbType.Int, all_ages_flag);
                    MetroBusdb.AddInParameter(sqlcmd, "logo", SqlDbType.VarChar, logo);
                    MetroBusdb.AddInParameter(sqlcmd, "map", SqlDbType.VarChar, map);
                    MetroBusdb.AddInParameter(sqlcmd, "active", SqlDbType.Int, brandStatus?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Resort(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select crm_resorts.*,crm_brands.short_name AS Bshort_name ,crm_regions.short_name AS Bregion  From crm_resorts  LEFT OUTER JOIN crm_brands ON crm_resorts.brand_id = crm_brands.brand_id  LEFT OUTER JOIN crm_regions ON crm_resorts.region_id = crm_regions.region_id where resort_id =@id";
        }
        else
        {
            query = "Select crm_resorts.*,crm_brands.short_name AS Bshort_name ,crm_regions.short_name AS Bregion  From crm_resorts  LEFT OUTER JOIN crm_brands ON crm_resorts.brand_id = crm_brands.brand_id  LEFT OUTER JOIN crm_regions ON crm_resorts.region_id = crm_regions.region_id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_Resort
        (int brand_id, string resort_name, string resort_code, string pms_code, string pms_sub_code, string ip_address,
        string port, int booking_active, int pms_active, string pms_last_connect, string description_title, string description_content, int region_id, string facebook_url, string twitter_url,
        string instagram_url, string google_url, string youtube_url, string pinterest_url, int adults_only_flag, int all_ages_flag, int id, int status)
    {

        string dt = pms_last_connect.Substring(6, 4) + "-" +
                    pms_last_connect.Substring(3, 2) + "-" +
                    pms_last_connect.Substring(0, 2);

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_resorts (brand_id,resort_name,resort_code,pms_code,pms_sub_code,ip_address,port,booking_active,pms_active,pms_last_connect,description_title,description_content,region_id,facebook_url, twitter_url,instagram_url ,google_url ,youtube_url,pinterest_url,adults_only_flag, all_ages_flag )";
            query += " VALUES ( @brand_id , @resort_name , @resort_code , @pms_code , @pms_sub_code , @ip_address , @port , @booking_active , @pms_active , @dt ,@description_title ,@description_content,@region_id,@facebook_url, @twitter_url,@instagram_url ,@google_url ,@youtube_url,@pinterest_url,@adults_only_flag,@all_ages_flag)";
        }
        else
        {
            query = "UPDATE crm_resorts SET   ";
            query += "brand_id = @brand_id , resort_name = @resort_name ,";
            query += "resort_code = @resort_code , pms_code = @pms_code ,";
            query += "pms_sub_code = @pms_sub_code, ip_address = @ip_address ,";
            query += "port = @port , booking_active = @booking_active,";
            query += "pms_active = @pms_active, pms_last_connect = @dt ,description_title = @description_title , description_content = @description_content,region_id = @region_id ,facebook_url = @facebook_url ,twitter_url = @twitter_url, ";
            query += "instagram_url = @instagram_url ,google_url = @google_url ,youtube_url = @youtube_url ,pinterest_url = @pinterest_url,adults_only_flag=@adults_only_flag, all_ages_flag=@all_ages_flag ";
            query += " Where resort_id =@id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "brand_id", SqlDbType.Int, brand_id);
                    MetroBusdb.AddInParameter(sqlcmd, "resort_name", SqlDbType.VarChar, resort_name);
                    MetroBusdb.AddInParameter(sqlcmd, "resort_code", SqlDbType.VarChar, resort_code);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_code", SqlDbType.VarChar, pms_code);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_sub_code", SqlDbType.VarChar, pms_sub_code);
                    MetroBusdb.AddInParameter(sqlcmd, "ip_address", SqlDbType.VarChar, ip_address);
                    MetroBusdb.AddInParameter(sqlcmd, "port", SqlDbType.VarChar, port);
                    MetroBusdb.AddInParameter(sqlcmd, "booking_active", SqlDbType.SmallInt, booking_active);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_active", SqlDbType.SmallInt, pms_active);
                    MetroBusdb.AddInParameter(sqlcmd, "dt", SqlDbType.Date, dt);
                    MetroBusdb.AddInParameter(sqlcmd, "description_title", SqlDbType.VarChar, description_title);
                    MetroBusdb.AddInParameter(sqlcmd, "description_content", SqlDbType.VarChar, description_content);
                    MetroBusdb.AddInParameter(sqlcmd, "region_id", SqlDbType.Int, region_id);
                    MetroBusdb.AddInParameter(sqlcmd, "facebook_url", SqlDbType.VarChar, facebook_url);
                    MetroBusdb.AddInParameter(sqlcmd, "twitter_url", SqlDbType.VarChar, twitter_url);
                    MetroBusdb.AddInParameter(sqlcmd, "instagram_url", SqlDbType.VarChar, instagram_url);
                    MetroBusdb.AddInParameter(sqlcmd, "google_url", SqlDbType.VarChar, google_url);
                    MetroBusdb.AddInParameter(sqlcmd, "youtube_url", SqlDbType.VarChar, youtube_url);
                    MetroBusdb.AddInParameter(sqlcmd, "pinterest_url", SqlDbType.VarChar, pinterest_url);
                    MetroBusdb.AddInParameter(sqlcmd, "adults_only_flag", SqlDbType.Int, adults_only_flag);
                    MetroBusdb.AddInParameter(sqlcmd, "all_ages_flag", SqlDbType.Int, all_ages_flag);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Room(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from pms_roomtypes where roomtype_id =@id";
        }
        else
        {
            query = "select * from pms_roomtypes";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_Room(int resort_id, string roomtypecategory, string roomtypecode, string roomtypedescription, string roomtypemenu, int id, int status)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  pms_roomtypes (resort_id,roomtypecategory,roomtypecode,roomtypedescription,roomtypemenu) VALUES (@resort_id,@roomtypecategory, @roomtypecode ,@roomtypedescription,@roomtypemenu)";
        }
        else
        {
            query = "UPDATE pms_roomtypes SET resort_id=@resort_id,roomtypecategory=@roomtypecategory,roomtypecode = @roomtypecode, roomtypedescription = @roomtypedescription, roomtypemenu=@roomtypemenu   Where roomtype_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "resort_id", SqlDbType.Int, resort_id);
                    MetroBusdb.AddInParameter(sqlcmd, "roomtypecategory", SqlDbType.VarChar, roomtypecategory);
                    MetroBusdb.AddInParameter(sqlcmd, "roomtypecode", SqlDbType.VarChar, roomtypecode);
                    MetroBusdb.AddInParameter(sqlcmd, "roomtypedescription", SqlDbType.VarChar, roomtypedescription);
                    MetroBusdb.AddInParameter(sqlcmd, "roomtypemenu", SqlDbType.VarChar, roomtypemenu);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Agencies(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_agency where agency_id =@id";
        }
        else
        {
            query = "select * from crm_agency";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_Agencies
        (string agency_short_name, string agency_irs_name, string agency_email,
        string agency_address, string agency_address2, string agency_city,
        string agency_state, string agency_postal, string agency_country,
        string agency_telephone, string agency_mobile, string agency_fax,
        string agency_core, string agency_iata, string agency_abta,
        string agency_arc, string agency_clia, string agency_atol, string agency_true, string agency_taxid, int agency_status,
        int id, int status)
    {

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_agency ";
            query += "(agency_short_name,agency_irs_name,agency_email,agency_address,agency_address2,agency_city,agency_state,agency_postal,agency_country,";
            query += "agency_telephone,agency_mobile,agency_fax,agency_core,agency_iata,agency_abta,agency_arc,agency_clia,agency_atol,agency_true,agency_taxid,agency_status)";
            query += "VALUES ";
            query += "(@agency_short_name,@agency_irs_name, @agency_email, @agency_address, @agency_address2, @agency_city, @agency_state, @agency_postal, @agency_country,";
            query += "@agency_telephone,@agency_mobile,@agency_fax,@agency_core,@agency_iata,@agency_abta,@agency_arc,@agency_clia,@agency_atol,@agency_true,@agency_taxid ,@agency_status)";
        }
        else
        {
            query = "UPDATE crm_agency SET    ";
            query += "agency_short_name = @agency_short_name, agency_irs_name = @agency_irs_name, agency_email=@agency_email, agency_address=@agency_address,";
            query += "agency_address2 = @agency_address2, agency_city = @agency_city, agency_state=@agency_state, agency_postal=@agency_postal,";
            query += "agency_country = @agency_country, agency_telephone = @agency_telephone, agency_mobile=@agency_mobile, agency_fax=@agency_fax,";
            query += "agency_core = @agency_core, agency_iata = @agency_iata, agency_abta=@agency_abta, agency_arc=@agency_arc,";
            query += "agency_clia = @agency_clia, agency_atol = @agency_atol, agency_true=@agency_true,agency_taxid=@agency_taxid ,agency_status =@agency_status ";
            query += " Where agency_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "agency_short_name", SqlDbType.VarChar, agency_short_name);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_irs_name", SqlDbType.VarChar, agency_irs_name);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_email", SqlDbType.VarChar, agency_email);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_address", SqlDbType.VarChar, agency_address);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_address2", SqlDbType.VarChar, agency_address2);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_city", SqlDbType.VarChar, agency_city);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_state", SqlDbType.VarChar, agency_state);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_postal", SqlDbType.VarChar, agency_postal);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_country", SqlDbType.VarChar, agency_country);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_telephone", SqlDbType.VarChar, agency_telephone);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_mobile", SqlDbType.VarChar, agency_mobile);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_fax", SqlDbType.VarChar, agency_fax);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_core", SqlDbType.VarChar, agency_core);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_iata", SqlDbType.VarChar, agency_iata);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_abta", SqlDbType.VarChar, agency_abta);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_arc", SqlDbType.VarChar, agency_arc);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_clia", SqlDbType.VarChar, agency_clia);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_atol", SqlDbType.VarChar, agency_atol);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_true", SqlDbType.VarChar, agency_true);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_taxid", SqlDbType.VarChar, agency_taxid);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_status", SqlDbType.TinyInt, agency_status);

                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }


    public static string Select_TTOP(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_ttoo where ttoo_id =@id";
        }
        else
        {
            query = "select * from crm_ttoo";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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


    public static string AddEdit_TTOP
       (string ttoo_short_name, string ttoo_irs_name, string ttoo_email,
       string ttoo_address, string ttoo_address2, string ttoo_city,
       string ttoo_state, string ttoo_postal, string ttoo_country,
       string ttoo_telephone, string ttoo_mobile, string ttoo_fax, string ttoo_taxid,
       int id, int status)
    {

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_ttoo ";
            query += "(ttoo_short_name,ttoo_irs_name,ttoo_email,ttoo_address,ttoo_address2,ttoo_city,ttoo_state,ttoo_postal,ttoo_country,";
            query += "ttoo_telephone,ttoo_mobile,ttoo_fax,ttoo_taxid)";
            query += "VALUES ";
            query += "(@ttoo_short_name,@ttoo_irs_name, @ttoo_email, @ttoo_address, @ttoo_address2, @ttoo_city, @ttoo_state, @ttoo_postal, @ttoo_country,";
            query += "@ttoo_telephone,@ttoo_mobile,@ttoo_fax,@ttoo_taxid)";
        }
        else
        {
            query = "UPDATE crm_ttoo SET    ";
            query += "ttoo_short_name = @ttoo_short_name, ttoo_irs_name = @ttoo_irs_name, ttoo_email=@ttoo_email, ttoo_address=@ttoo_address,";
            query += "ttoo_address2 = @ttoo_address2, ttoo_city = @ttoo_city, ttoo_state=@ttoo_state, ttoo_postal=@ttoo_postal,";
            query += "ttoo_country = @ttoo_country, ttoo_telephone = @ttoo_telephone, ttoo_mobile=@ttoo_mobile, ttoo_fax=@ttoo_fax,";
            query += "ttoo_taxid = @ttoo_taxid ";
            query += " Where ttoo_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_short_name", SqlDbType.VarChar, ttoo_short_name);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_irs_name", SqlDbType.VarChar, ttoo_irs_name);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_email", SqlDbType.VarChar, ttoo_email);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_address", SqlDbType.VarChar, ttoo_address);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_address2", SqlDbType.VarChar, ttoo_address2);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_city", SqlDbType.VarChar, ttoo_city);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_state", SqlDbType.VarChar, ttoo_state);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_postal", SqlDbType.VarChar, ttoo_postal);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_country", SqlDbType.VarChar, ttoo_country);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_telephone", SqlDbType.VarChar, ttoo_telephone);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_mobile", SqlDbType.VarChar, ttoo_mobile);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_fax", SqlDbType.VarChar, ttoo_fax);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_taxid", SqlDbType.VarChar, ttoo_taxid);

                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }


    public static string Select_AgentView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select CA.*,CG.agency_short_name as agency_short_name  From crm_agents AS CA LEFT OUTER JOIN  crm_agency AS CG ON  CA.agency_id = CG.agency_id Where agent_id =@id";
        }
        else
        {
            query = "Select CA.*,CG.agency_short_name as agency_short_name  From crm_agents AS CA LEFT OUTER JOIN  crm_agency AS CG ON  CA.agency_id = CG.agency_id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_BookingView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select cb.* ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname as agent_lastname ,ca.agent_status as agent_status,";
            query += " cr.resort_name ,cag.agency_short_name as agency_short_name   from crm_booking AS cb   ";
            query += " LEFT OUTER JOIN crm_agents AS ca ON cb.agent_id = ca.agent_id   ";
            query += " LEFT OUTER JOIN crm_agency AS cag ON ca.agency_id = cag.agency_id  ";
            query += " LEFT OUTER JOIN crm_resorts AS cr ON cb.resort_id = cr.resort_id  Where cb.booking_id =@id";
        }
        else
        {
            query = "Select cb.* ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname as agent_lastname ,ca.agent_status as agent_status,";
            query += "cr.resort_name ,cag.agency_short_name as agency_short_name   from crm_booking AS cb ";
            query += " LEFT OUTER JOIN crm_agents AS ca ON cb.agent_id = ca.agent_id ";
            query += " LEFT OUTER JOIN crm_agency AS cag ON ca.agency_id = cag.agency_id ";
            query += " LEFT OUTER JOIN crm_resorts AS cr ON cb.resort_id = cr.resort_id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_CardView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select ac.* ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname from award_cards AS ac LEFT OUTER JOIN crm_agents AS ca ON ac.agent_id = ca.agent_id";

        }
        else
        {
            query = "select ac.* ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname from award_cards AS ac LEFT OUTER JOIN crm_agents AS ca ON ac.agent_id = ca.agent_id";

        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_PointView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select ac.* ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname from award_points AS ac LEFT OUTER JOIN crm_agents AS ca ON ac.agent_id = ca.agent_id";

        }
        else
        {
            query = "select ac.* ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname from award_points AS ac LEFT OUTER JOIN crm_agents AS ca ON ac.agent_id = ca.agent_id";

        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_RewardsView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select al.*  ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname as agent_lastname From award_loads as al LEFT OUTER JOIN crm_agents as ca ON al.agent_id = ca.agent_id";

        }
        else
        {
            query = "Select al.*  ,ca.agent_email as agent_email ,ca.agent_givenname as agent_givenname ,ca.agent_lastname as agent_lastname From award_loads as al LEFT OUTER JOIN crm_agents as ca ON al.agent_id = ca.agent_id";

        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_AdminLogView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select * from portal_adminlog";

        }
        else
        {
            query = "Select * from portal_adminlog";

        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_UserRoleID(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select * From portal_userpanel_roles";
        }
        else
        {
            query = "Select * From portal_userpanel_roles";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_UserAdminData(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select ua.*,ur.name  From portal_userpanel_admin as ua LEFT OUTER JOIN portal_userpanel_roles as ur ON ua.role_id = ur.id where ua.id=@ID and ua.Status <>-1";
        }
        else
        {
            query = "Select ua.*,ur.name  From portal_userpanel_admin as ua LEFT OUTER JOIN portal_userpanel_roles as ur ON ua.role_id = ur.id  where ua.Status <>-1";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "ID", SqlDbType.Int, id);

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


    public static string getJSON(dynamic Data)
    {
        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(Data);
        return JSONString;
    }
    public static string AddEdit_UserAdmin(string username, string password, string givenname, string familyname, string auth, int role_id,  int id, int status)
    {
        try
        {
            string query = "";
            Initialize();
            var result = "[]";
            if (status == 1)
            {


                query = @"

if not exists(select 1 from portal_userpanel_admin where username = @username and password = @password and status !=-1)
begin
Insert  into portal_userpanel_admin (username,password,givenname,familyname,auth,role_id,last_modified,Status)
 values(@username,@password,@givenname,@familyname,@auth,@role_id,getdate(),0)
 Select 'Success'
 end
 else
 begin
 select 'Exists'
 end";
            }
            else
            {
                query = "UPDATE portal_userpanel_admin SET username = @username, password = @password , givenname = @givenname, familyname = @familyname,auth = @auth,role_id = @role_id,last_modified =getdate()  Where id = @id select 'Success'";

            }
            result = db.Query<String>(query, new
            {
                   username= username,
                    password=password,
                  givenname= givenname,
                   familyname= familyname,
                  auth= auth,
                   role_id= role_id,
                   
                   id= id
            }).First();
            return getJSON(result);
        }

        catch (Exception ex)
        {
           
            return getJSON("Failure");

        }


    }


    public static void Initialize()
    {
        db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    }


    public static string Select_WinnersView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select cpa.* ,cp.short_name as Priceshort_name ,cr.resort_name as resort_name ,cag.agency_short_name as  agency_short_name ,";
            query += "  cA.agent_email as agent_email ,cA.agent_givenname as agent_givenname , cB.book_date as book_date,cB.book_check_in as book_check_in ,";
            query += " cB.book_check_out AS book_check_out ,cB.book_nights As book_nights ,cB.pms_poststay as pms_poststay ,cB.pms_prestay as pms_prestay ";
            query += " from crm_prizes_awarded AS cpa ";
            query += " LEFT OUTER JOIN crm_prizes AS cp ON cpa.prize_id = cp.prize_id";
            query += " LEFT OUTER JOIN crm_resorts AS cr ON cpa.resort_id = cr.resort_id";
            query += "  LEFT OUTER JOIN crm_agency AS cag ON cpa.agency_id = cag.agency_id";
            query += "    LEFT OUTER JOIN crm_agents AS cA ON cpa.agent_id = cA.agent_id";
            query += "    LEFT OUTER JOIN crm_booking AS cB ON cpa.booking_id = cB.booking_id";

        }
        else
        {
            query = "select cpa.* ,cp.short_name as Priceshort_name ,cr.resort_name as resort_name ,cag.agency_short_name as  agency_short_name ,";
            query += "  cA.agent_email as agent_email ,cA.agent_givenname as agent_givenname , cB.book_date as book_date,cB.book_check_in as book_check_in ,";
            query += " cB.book_check_out AS book_check_out ,cB.book_nights As book_nights ,cB.pms_poststay as pms_poststay ,cB.pms_prestay as pms_prestay ";
            query += "from crm_prizes_awarded AS cpa ";
            query += " LEFT OUTER JOIN crm_prizes AS cp ON cpa.prize_id = cp.prize_id";
            query += " LEFT OUTER JOIN crm_resorts AS cr ON cpa.resort_id = cr.resort_id";
            query += "  LEFT OUTER JOIN crm_agency AS cag ON cpa.agency_id = cag.agency_id";
            query += "    LEFT OUTER JOIN crm_agents AS cA ON cpa.agent_id = cA.agent_id";
            query += "    LEFT OUTER JOIN crm_booking AS cB ON cpa.booking_id = cB.booking_id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_ReservationView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select PR.* ,CR.resort_name as resort_name ";
            query += " from pms_reservation  as PR";
            query += " LEFT OUTER JOIN crm_resorts CR ON PR.resort_id = CR.resort_id ";


        }
        else
        {
            query = "Select PR.* ,CR.resort_name as resort_name ";
            query += " from pms_reservation  as PR";
            query += " LEFT OUTER JOIN crm_resorts CR ON PR.resort_id = CR.resort_id ";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_GuestView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select PG.*  , PR.rez_id as  rez_id ,";
            query += " PR.checkin as checkin, PR.checkout as checkout ,PR.nights as nights ,PR.reservationstate as reservationstate";
            query += " From pms_guest as PG ";
            query += " LEFT OUTER JOIN pms_reservation as PR ON PG.rez_id = PR.rez_id";
        }
        else
        {
            query = "Select PG.*  , PR.rez_id as  rez_id ,";
            query += " PR.checkin as checkin, PR.checkout as checkout ,PR.nights as nights ,PR.reservationstate as reservationstate";
            query += " From pms_guest as PG ";
            query += " LEFT OUTER JOIN pms_reservation as PR ON PG.rez_id = PR.rez_id";

        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_BerkeleySessionView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select* From award_sessions";

        }
        else
        {
            query = "Select* From award_sessions";


        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Select_NewHotelSessionView(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select PL.*  ,CR.resort_name as resort_name From pms_log as PL LEFT OUTER JOIN crm_resorts as CR ON PL.resort_id = CR.resort_id";

        }
        else
        {
            query = "Select PL.*  ,CR.resort_name as resort_name From pms_log as PL LEFT OUTER JOIN crm_resorts as CR ON PL.resort_id = CR.resort_id";

        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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


    public static string Select_Country(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from countries where id =@id";
        }
        else
        {
            query = "select * from countries";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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



    public static string Select_Promotions(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_promotions where promo_id =@id";
        }
        else
        {
            query = "select * from crm_promotions";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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


    public static string AddEdit_Promotions
        (string promo_name, string booking_start_date, string booking_end_date,
        string travel_start_date, string travel_end_date, int minimum_nights,
        string agent_status_restriction_csv, string country_restriction_csv,
        string resort_restriction_csv, string roomtype_restruction_csv,
        string agency_restriction_csv, string ttoo_restriction_csv, string rules_url, int id, int status, int base_points, Decimal points_multiplier, int reward_promo, int bonus_promo, int active)
    {
        string bookingstartdate = DateTime.Now.ToShortDateString();
        string bookingenddate = DateTime.Now.ToShortDateString();
        string travelstartdate = DateTime.Now.ToShortDateString();
        string travelenddate = DateTime.Now.ToShortDateString();
        if (booking_start_date != "")
        {
            bookingstartdate = booking_start_date.Substring(6, 4) + "-" +
                                      booking_start_date.Substring(3, 2) + "-" +
                                      booking_start_date.Substring(0, 2);
        }
        if (booking_end_date != "")
        {
            bookingenddate = booking_end_date.Substring(6, 4) + "-" +
                                 booking_end_date.Substring(3, 2) + "-" +
                                 booking_end_date.Substring(0, 2);
        }
        if (travel_start_date != "")
        {
            travelstartdate = travel_start_date.Substring(6, 4) + "-" +
                                    travel_start_date.Substring(3, 2) + "-" +
                                    travel_start_date.Substring(0, 2);
        }
        if (travel_end_date != "")
        {
            travelenddate = travel_end_date.Substring(6, 4) + "-" +
                                   travel_end_date.Substring(3, 2) + "-" +
                                   travel_end_date.Substring(0, 2);
        }

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_promotions   ";
            query += "(promo_name,booking_start_date,booking_end_date,travel_start_date,travel_end_date,minimum_nights,agent_status_restriction_csv,country_restriction_csv,resort_restriction_csv,roomtype_restriction_csv,agency_restriction_csv,ttoo_restriction_csv,rules_url,base_points,points_multiplier, reward_promo, bonus_promo, active)";
            query += "VALUES";
            query += "(@promo_name,@bookingstartdate,@bookingenddate,@travelstartdate,@travelenddate,@minimum_nights,@agent_status_restriction_csv,@country_restriction_csv,@resort_restriction_csv,@roomtype_restriction_csv,@agency_restriction_csv,@ttoo_restriction_csv,@rules_url,@base_points,@points_multiplier,@reward_promo,@bonus_promo,@active)";
        }
        else
        {
            query = "UPDATE crm_promotions SET ";
            query += "promo_name = @promo_name, booking_start_date = @bookingstartdate ,booking_end_date =@bookingenddate ,travel_start_date =@travelstartdate ,travel_end_date =@travelenddate ,";
            query += "minimum_nights =@minimum_nights ,agent_status_restriction_csv =@agent_status_restriction_csv ,country_restriction_csv =@country_restriction_csv ,";
            query += "resort_restriction_csv =@resort_restriction_csv ,roomtype_restriction_csv =@roomtype_restriction_csv,agency_restriction_csv =@agency_restriction_csv ,";
            query += "ttoo_restriction_csv =@ttoo_restriction_csv ,rules_url =@rules_url,base_points=@base_points,points_multiplier=@points_multiplier,reward_promo=@reward_promo, bonus_promo=@bonus_promo, active=@active";
            query += " Where promo_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "promo_name", SqlDbType.VarChar, promo_name);
                    MetroBusdb.AddInParameter(sqlcmd, "bookingstartdate", SqlDbType.DateTime, bookingstartdate);
                    MetroBusdb.AddInParameter(sqlcmd, "bookingenddate", SqlDbType.DateTime, bookingenddate);
                    MetroBusdb.AddInParameter(sqlcmd, "travelstartdate", SqlDbType.DateTime, travelstartdate);
                    MetroBusdb.AddInParameter(sqlcmd, "travelenddate", SqlDbType.DateTime, travelenddate);
                    MetroBusdb.AddInParameter(sqlcmd, "minimum_nights", SqlDbType.Int, minimum_nights);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_status_restriction_csv", SqlDbType.VarChar, agent_status_restriction_csv);
                    MetroBusdb.AddInParameter(sqlcmd, "country_restriction_csv", SqlDbType.VarChar, country_restriction_csv);
                    MetroBusdb.AddInParameter(sqlcmd, "resort_restriction_csv", SqlDbType.VarChar, resort_restriction_csv);
                    MetroBusdb.AddInParameter(sqlcmd, "roomtype_restriction_csv", SqlDbType.VarChar, roomtype_restruction_csv);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_restriction_csv", SqlDbType.VarChar, agency_restriction_csv);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_restriction_csv", SqlDbType.VarChar, ttoo_restriction_csv);
                    MetroBusdb.AddInParameter(sqlcmd, "rules_url", SqlDbType.VarChar, rules_url);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "base_points", SqlDbType.Int, base_points);
                    MetroBusdb.AddInParameter(sqlcmd, "points_multiplier", SqlDbType.Decimal, points_multiplier);
                    MetroBusdb.AddInParameter(sqlcmd, "reward_promo", SqlDbType.Int, reward_promo);
                    MetroBusdb.AddInParameter(sqlcmd, "bonus_promo", SqlDbType.Int, bonus_promo);
                    MetroBusdb.AddInParameter(sqlcmd, "active", SqlDbType.Int, active);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }



    public static string Select_Prize(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_prizes where prize_id =@id";
        }
        else
        {
            query = "select * from crm_prizes";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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



    public static string AddEdit_Prizes
        (int promo_id, string short_name, string name, string image_url, double prize_value, int frequency_hourly, int frequency_daily, int frequency_weekly, int frequency_monthly,
        int frequency_odds, int total_prizes, int remaining_prizes, string created, string updated, int id, int status)
    {
        string createdt = created.Substring(6, 4) + "-" +
                          created.Substring(3, 2) + "-" +
                          created.Substring(0, 2);
        string updatedt = updated.Substring(6, 4) + "-" +
                          updated.Substring(3, 2) + "-" +
                          updated.Substring(0, 2);

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_prizes  ";
            query += "(promo_id,short_name,name,image_url,prize_value,frequency_hourly,frequency_daily,frequency_weekly,frequency_monthly,frequency_odds,total_prizes,remaining_prizes,created,updated)";
            query += " VALUES";
            query += "(@promo_id,@short_name,@name,@image_url,@prize_value,@frequency_hourly,@frequency_daily,@frequency_weekly,@frequency_monthly,@frequency_odds,@total_prizes,@remaining_prizes,@createdt,@updatedt)";
        }
        else
        {
            query = "UPDATE crm_prizes SET promo_id = @promo_id,short_name = @short_name ,name = @name ,image_url = @image_url, prize_value = @prize_value,";
            query += " frequency_hourly = @frequency_hourly, frequency_daily = @frequency_daily,frequency_weekly = @frequency_weekly, ";
            query += " frequency_monthly = @frequency_monthly, frequency_odds = @frequency_odds, total_prizes = @total_prizes, ";
            query += "  remaining_prizes = @remaining_prizes, created = @createdt,updated = @updatedt  Where prize_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "promo_id", SqlDbType.Int, promo_id);
                    MetroBusdb.AddInParameter(sqlcmd, "short_name", SqlDbType.VarChar, short_name);
                    MetroBusdb.AddInParameter(sqlcmd, "name", SqlDbType.VarChar, name);
                    MetroBusdb.AddInParameter(sqlcmd, "image_url", SqlDbType.VarChar, image_url);
                    MetroBusdb.AddInParameter(sqlcmd, "prize_value", SqlDbType.Decimal, prize_value);
                    MetroBusdb.AddInParameter(sqlcmd, "frequency_hourly", SqlDbType.Int, frequency_hourly);
                    MetroBusdb.AddInParameter(sqlcmd, "frequency_daily", SqlDbType.Int, frequency_daily);
                    MetroBusdb.AddInParameter(sqlcmd, "frequency_weekly", SqlDbType.Int, frequency_weekly);
                    MetroBusdb.AddInParameter(sqlcmd, "frequency_monthly", SqlDbType.Int, frequency_monthly);
                    MetroBusdb.AddInParameter(sqlcmd, "frequency_odds", SqlDbType.Int, frequency_odds);
                    MetroBusdb.AddInParameter(sqlcmd, "total_prizes", SqlDbType.Int, total_prizes);
                    MetroBusdb.AddInParameter(sqlcmd, "remaining_prizes", SqlDbType.Int, remaining_prizes);
                    MetroBusdb.AddInParameter(sqlcmd, "createdt", SqlDbType.DateTime, createdt);
                    MetroBusdb.AddInParameter(sqlcmd, "updatedt", SqlDbType.DateTime, updatedt);

                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }


    public static string Select_PMSAgents(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select PA.*  ,PR.checkin as checkin,PR.checkout as checkout ,PR.nights as nights,PR.reservationstate as reservationstate, ";
            query += "CR.resort_name as resort_name ,CA.agency_short_name as agency_short_name ,CT.ttoo_short_name as ttoo_short_name ,";
            query += " CAT.agent_email as agent_email ,CAT.agent_givenname as agent_givenname ,CAT.agent_lastname as agent_lastname  ";
            query += " From pms_agent as PA  ";
            query += " LEFT OUTER JOIN pms_reservation PR ON PR.rez_id = PA.rez_id  LEFT OUTER JOIN crm_resorts CR ON CR.resort_id = PR.resort_id";
            query += "  LEFT OUTER JOIN crm_agency CA ON CA.agency_id = PA.agency_id    LEFT OUTER JOIN crm_ttoo CT ON CT.ttoo_id = PA.ttoo_id   LEFT OUTER JOIN crm_agents CAT ON CAT.agent_id = PA.agent_id ";
            query += " Where PA.rezagent_id =@id";
        }
        else
        {
            query = "Select PA.*  ,PR.checkin as checkin,PR.checkout as checkout ,PR.nights as nights,PR.reservationstate as reservationstate, ";
            query += "CR.resort_name as resort_name ,CA.agency_short_name as agency_short_name ,CT.ttoo_short_name as ttoo_short_name ,";
            query += " CAT.agent_email as agent_email ,CAT.agent_givenname as agent_givenname ,CAT.agent_lastname as agent_lastname  ";
            query += " From pms_agent as PA  ";
            query += " LEFT OUTER JOIN pms_reservation PR ON PR.rez_id = PA.rez_id  LEFT OUTER JOIN crm_resorts CR ON CR.resort_id = PR.resort_id";
            query += "  LEFT OUTER JOIN crm_agency CA ON CA.agency_id = PA.agency_id    LEFT OUTER JOIN crm_ttoo CT ON CT.ttoo_id = PA.ttoo_id   LEFT OUTER JOIN crm_agents CAT ON CAT.agent_id = PA.agent_id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_pms_agent(int rez_id, int agent_id, int agency_id, int ttoo_id, string contract, int id, int status)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  pms_agent (  rez_id ,  agent_id ,  agency_id ,  ttoo_id ,  contract  )";
            query += "VALUES (   @rez_id ,  @agent_id ,  @agency_id ,  @ttoo_id ,  @contract  )";
        }
        else
        {
            query = "UPDATE pms_agent SET     rez_id=@rez_id,  agent_id=@agent_id,  agency_id=@agency_id,  ttoo_id=@ttoo_id,  contract=@contract ";
            query += " Where  rezagent_id = @id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "rez_id", SqlDbType.Int, rez_id);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_id", SqlDbType.Int, agent_id);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_id", SqlDbType.Int, agency_id);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_id", SqlDbType.Int, ttoo_id);
                    MetroBusdb.AddInParameter(sqlcmd, "contract", SqlDbType.VarChar, contract);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_UserRole(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select * From portal_userpanel_roles  where id =@id";
        }
        else
        {
            query = "Select * From portal_userpanel_roles ";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_UserRoles(string name, string functions, int id, int status)
    {

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  portal_userpanel_roles (  name ,  functions ,  last_modified  )";
            query += " VALUES ( @name ,  @functions ,  getdate()  )";
        }
        else
        {
            query = "UPDATE portal_userpanel_roles SET  name=@name,  functions=@functions,  last_modified=getdate() ";
            query += " Where  id = @id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "name", SqlDbType.VarChar, name);
                    MetroBusdb.AddInParameter(sqlcmd, "functions", SqlDbType.VarChar, functions);
                   
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_LoyalGuest(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select * From crm_loyalty  where loyalty_id =@id";
        }
        else
        {
            query = "Select * From crm_loyalty";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_loyalty(string loyalty_email, string loyalty_prefix, string loyalty_givenname, string loyalty_familyname,
        string loyalty_address, string loyalty_address2, string loyalty_city, string loyalty_state, string loyalty_zip, string loyalty_country,
        string loyalty_telephone, string loyalty_mobile, string created, string modified, int id, int status)
    {
        string createdt = created.Substring(6, 4) + "-" +
                          created.Substring(3, 2) + "-" +
                          created.Substring(0, 2);
        string modifiedt = modified.Substring(6, 4) + "-" +
                          modified.Substring(3, 2) + "-" +
                          modified.Substring(0, 2);

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_loyalty ( loyalty_email ,  loyalty_prefix ,  loyalty_givenname ,  loyalty_familyname ,  loyalty_address ,  loyalty_address2 ,  loyalty_city ,  loyalty_state ,  loyalty_zip ,  loyalty_country ,  loyalty_telephone ,  loyalty_mobile ,  created ,  modified )";
            query += " VALUES (  @loyalty_email ,  @loyalty_prefix ,  @loyalty_givenname ,  @loyalty_familyname ,  @loyalty_address ,  @loyalty_address2 ,  @loyalty_city ,  @loyalty_state ,  @loyalty_zip ,  @loyalty_country ,  @loyalty_telephone ,  @loyalty_mobile ,  @createdt ,  @modifiedt  )";
        }
        else
        {
            query = "UPDATE crm_loyalty SET   loyalty_email=@loyalty_email,  loyalty_prefix=@loyalty_prefix,  loyalty_givenname=@loyalty_givenname,  loyalty_familyname=@loyalty_familyname,  loyalty_address=@loyalty_address,  loyalty_address2=@loyalty_address2,  loyalty_city=@loyalty_city,  loyalty_state=@loyalty_state,  loyalty_zip=@loyalty_zip,  loyalty_country=@loyalty_country,  loyalty_telephone=@loyalty_telephone,  loyalty_mobile=@loyalty_mobile,  created=@createdt,  modified=@modifiedt ";
            query += "  Where  loyalty_id = @id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_email", SqlDbType.VarChar, loyalty_email);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_prefix ", SqlDbType.VarChar, loyalty_prefix);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_givenname ", SqlDbType.VarChar, loyalty_givenname);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_familyname ", SqlDbType.VarChar, loyalty_familyname);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_address ", SqlDbType.VarChar, loyalty_address);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_address2 ", SqlDbType.VarChar, loyalty_address2);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_city ", SqlDbType.VarChar, loyalty_city);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_state ", SqlDbType.VarChar, loyalty_state);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_zip ", SqlDbType.VarChar, loyalty_zip);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_country ", SqlDbType.VarChar, loyalty_country);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_telephone ", SqlDbType.VarChar, loyalty_telephone);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_mobile ", SqlDbType.VarChar, loyalty_mobile);
                    MetroBusdb.AddInParameter(sqlcmd, "createdt ", SqlDbType.DateTime, createdt);
                    MetroBusdb.AddInParameter(sqlcmd, "modifiedt ", SqlDbType.DateTime, modifiedt);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Ballots(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select CB.*  ,CA.agent_email as agent_email ,CA.agent_givenname as agent_givenname , CA.agent_lastname as agent_lastname  ";
            query += " From crm_ballots as CB  LEFT OUTER JOIN crm_agents CA ON CA.agent_id = CB.agent_id Where ballot_id =@id";
        }
        else
        {
            query = "Select CB.*  ,CA.agent_email as agent_email ,CA.agent_givenname as agent_givenname , CA.agent_lastname as agent_lastname  ";
            query += " From crm_ballots as CB  LEFT OUTER JOIN crm_agents CA ON CA.agent_id = CB.agent_id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_Ballots
        (int agent_id, string ballot_date, string ballot_source, string ballot_emaillist, string ballot_form_data_1, string ballot_form_data_2, string ballot_form_data_3,
        string ballot_form_data_4, string ballot_form_data_5, string ballot_form_data_6, string ballot_form_data_7, string ballot_form_data_8, string ballot_form_data_9,
        int ballot_optin, string ballot_consumer, string ballot_bridal, string ballot_agent, string ballot_ttoo, string ballot_meeting_planner, string ballot_tourist_board_member,
        string ballot_media, string ballot_insider, string guest_checkin_date, string guest_checkout_date, string guest_book_id, string ip,
        string modified, int id, int status)
    {
        string ballotdate = ballot_date.Substring(6, 4) + "-" +
                          ballot_date.Substring(3, 2) + "-" +
                          ballot_date.Substring(0, 2);
        string guestcheckindate = guest_checkin_date.Substring(6, 4) + "-" +
                          guest_checkin_date.Substring(3, 2) + "-" +
                          guest_checkin_date.Substring(0, 2);
        string guestcheckoutdate = guest_checkout_date.Substring(6, 4) + "-" +
                         guest_checkout_date.Substring(3, 2) + "-" +
                         guest_checkout_date.Substring(0, 2);
        string modifiedt = modified.Substring(6, 4) + "-" +
                        modified.Substring(3, 2) + "-" +
                        modified.Substring(0, 2);

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_ballots (  agent_id ,  ballot_date ,  ballot_source ,  ballot_emaillist ,  ballot_form_data_1 ,  ballot_form_data_2 ,  ballot_form_data_3 ,  ballot_form_data_4 ,  ballot_form_data_5 ,  ballot_form_data_6 ,  ballot_form_data_7 ,  ballot_form_data_8 ,  ballot_form_data_9 ,  ballot_optin ,  ballot_consumer ,  ballot_bridal ,  ballot_agent ,  ballot_ttoo ,  ballot_meeting_planner ,  ballot_tourist_board_member ,  ballot_media ,  ballot_insider ,  guest_checkin_date ,  guest_checkout_date ,  guest_book_id ,  ip ,  modified )";
            query += " VALUES (  @agent_id ,  @ballotdate ,  @ballot_source ,  @ballot_emaillist ,  @ballot_form_data_1 ,  @ballot_form_data_2 ,  @ballot_form_data_3 ,  @ballot_form_data_4 ,  @ballot_form_data_5 ,  @ballot_form_data_6 ,  @ballot_form_data_7 ,  @ballot_form_data_8 ,  @ballot_form_data_9 ,  @ballot_optin ,  @ballot_consumer ,  @ballot_bridal ,  @ballot_agent ,  @ballot_ttoo ,  @ballot_meeting_planner ,  @ballot_tourist_board_member ,  @ballot_media ,  @ballot_insider ,  @guestcheckindate ,  @guestcheckoutdate ,  @guest_book_id ,  @ip ,  @modifiedt  )";
        }
        else
        {
            query = " UPDATE crm_ballots SET   agent_id=@agent_id,  ballot_date=@ballotdate,  ballot_source=@ballot_source,  ballot_emaillist=@ballot_emaillist,";
            query += " ballot_form_data_1=@ballot_form_data_1,  ballot_form_data_2=@ballot_form_data_2,  ballot_form_data_3=@ballot_form_data_3,  ballot_form_data_4=@ballot_form_data_4,";
            query += " ballot_form_data_5=@ballot_form_data_5,  ballot_form_data_6=@ballot_form_data_6,  ballot_form_data_7=@ballot_form_data_7,  ballot_form_data_8=@ballot_form_data_8,";
            query += "  ballot_form_data_9=@ballot_form_data_9,  ballot_optin=@ballot_optin,  ballot_consumer=@ballot_consumer,  ballot_bridal=@ballot_bridal,  ballot_agent=@ballot_agent,";
            query += "  ballot_ttoo=@ballot_ttoo,  ballot_meeting_planner=@ballot_meeting_planner,  ballot_tourist_board_member=@ballot_tourist_board_member,  ballot_media=@ballot_media, ";
            query += "  ballot_insider=@ballot_insider,  guest_checkin_date=@guestcheckindate,  guest_checkout_date=@guestcheckoutdate,  guest_book_id=@guest_book_id,  ip=@ip, ";
            query += " modified=@modifiedt  ";
            query += "  Where  ballot_id = @id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id ", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_id", SqlDbType.Int, agent_id);
                    MetroBusdb.AddInParameter(sqlcmd, "ballotdate ", SqlDbType.DateTime, ballotdate);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_source ", SqlDbType.VarChar, ballot_source);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_emaillist ", SqlDbType.VarChar, ballot_emaillist);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_1 ", SqlDbType.VarChar, ballot_form_data_1);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_2 ", SqlDbType.VarChar, ballot_form_data_2);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_3 ", SqlDbType.VarChar, ballot_form_data_3);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_4 ", SqlDbType.VarChar, ballot_form_data_4);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_5 ", SqlDbType.VarChar, ballot_form_data_5);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_6 ", SqlDbType.VarChar, ballot_form_data_6);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_7 ", SqlDbType.VarChar, ballot_form_data_7);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_8 ", SqlDbType.VarChar, ballot_form_data_8);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_form_data_9 ", SqlDbType.VarChar, ballot_form_data_9);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_optin ", SqlDbType.Int, ballot_optin);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_consumer ", SqlDbType.Char, ballot_consumer);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_bridal ", SqlDbType.Char, ballot_bridal);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_agent ", SqlDbType.Char, ballot_agent);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_ttoo ", SqlDbType.Char, ballot_ttoo);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_meeting_planner ", SqlDbType.Char, ballot_meeting_planner);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_tourist_board_member ", SqlDbType.Char, ballot_tourist_board_member);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_media ", SqlDbType.Char, ballot_media);
                    MetroBusdb.AddInParameter(sqlcmd, "ballot_insider ", SqlDbType.Char, ballot_insider);
                    MetroBusdb.AddInParameter(sqlcmd, "guestcheckindate ", SqlDbType.Date, guestcheckindate);
                    MetroBusdb.AddInParameter(sqlcmd, "guestcheckoutdate ", SqlDbType.Date, guestcheckoutdate);
                    MetroBusdb.AddInParameter(sqlcmd, "guest_book_id ", SqlDbType.VarChar, guest_book_id);
                    MetroBusdb.AddInParameter(sqlcmd, "ip ", SqlDbType.VarChar, ip);
                    MetroBusdb.AddInParameter(sqlcmd, "modifiedt ", SqlDbType.DateTime, modifiedt);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Leads(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select LD.* ,CR.resort_name as resort_name ,CB.book_date as book_date ,CB.book_check_in as book_check_in ,CB.book_check_out as book_check_out ,CB.book_nights  as book_nights ,";
            query += " CB.pms_prestay as pms_prestay ,CB.pms_poststay as pms_poststay ";
            query += " From crm_leads as LD ";
            query += " LEFT OUTER JOIN crm_booking as CB ON CB.booking_id = LD.booking_id ";
            query += " LEFT OUTER JOIN crm_resorts as CR ON CR.resort_id = CB.resort_id ";
            query += "Where lead_id =@id";
        }
        else
        {
            query = "Select LD.* ,CR.resort_name as resort_name ,CB.book_date as book_date ,CB.book_check_in as book_check_in ,CB.book_check_out as book_check_out ,CB.book_nights  as book_nights ,";
            query += " CB.pms_prestay as pms_prestay ,CB.pms_poststay as pms_poststay ";
            query += " From crm_leads as LD ";
            query += " LEFT OUTER JOIN crm_booking as CB ON CB.booking_id = LD.booking_id ";
            query += " LEFT OUTER JOIN crm_resorts as CR ON CR.resort_id = CB.resort_id ";

        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_Leads
        (int agent_id, int loyalty_id, int booking_id, string lead_date, string lead_source, string lead_emaillist, string lead_booking_id,
        string lead_check_in_date, string lead_check_out_date, string lead_wedding_date, int lead_resort, string lead_email, string lead_prefix,
        string lead_givenname, string lead_familyname, string lead_address, string lead_address2, string lead_city, string lead_state, string lead_zip, string lead_country,
        string lead_telephone, string lead_fax, string lead_mobile, string lead_form_data_1, string lead_form_data_2, string lead_form_data_3, string lead_form_data_4,
        string lead_form_data_5, string lead_form_data_6, string lead_form_data_7, string lead_form_data_8, string lead_form_data_9, int lead_optin, string lead_consumer,
        string lead_bridal, string lead_agent, string lead_ttoo, string lead_meeting_planner, string lead_tourist_board_member, string lead_media, string lead_insider,
        string ip, string modified, int id, int status)
    {

        string leaddate = lead_date.Substring(6, 4) + "-" +
                          lead_date.Substring(3, 2) + "-" +
                          lead_date.Substring(0, 2);
        string leadcheckindate = lead_check_in_date.Substring(6, 4) + "-" +
                                 lead_check_in_date.Substring(3, 2) + "-" +
                                 lead_check_in_date.Substring(0, 2);
        string leadcheckoutdate = lead_check_out_date.Substring(6, 4) + "-" +
                                  lead_check_out_date.Substring(3, 2) + "-" +
                                  lead_check_out_date.Substring(0, 2);
        string leadweddingdate = lead_wedding_date.Substring(6, 4) + "-" +
                                 lead_wedding_date.Substring(3, 2) + "-" +
                                 lead_wedding_date.Substring(0, 2);
        string modifiedt = modified.Substring(6, 4) + "-" +
                                 modified.Substring(3, 2) + "-" +
                                 modified.Substring(0, 2);

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_leads (  agent_id ,  loyalty_id ,  booking_id ,  lead_date ,  lead_source ,  lead_emaillist ,  lead_booking_id ,  lead_check_in_date ,  lead_check_out_date ,  lead_wedding_date ,  lead_resort ,  lead_email ,  lead_prefix ,  lead_givenname ,  lead_familyname ,  lead_address ,  lead_address2 ,  lead_city ,  lead_state ,  lead_zip ,  lead_country ,  lead_telephone ,  lead_fax ,  lead_mobile ,  lead_form_data_1 ,  lead_form_data_2 ,  lead_form_data_3 ,  lead_form_data_4 ,  lead_form_data_5 ,  lead_form_data_6 ,  lead_form_data_7 ,  lead_form_data_8 ,  lead_form_data_9 ,  lead_optin ,  lead_consumer ,  lead_bridal ,  lead_agent ,  lead_ttoo ,  lead_meeting_planner ,  lead_tourist_board_member ,  lead_media ,  lead_insider ,  ip ,  modified  )";
            query += " VALUES (  @agent_id ,  @loyalty_id ,  @booking_id ,  @leaddate ,  @lead_source ,  @lead_emaillist ,  @lead_booking_id ,  @leadcheckindate ,  @leadcheckoutdate ,  @leadweddingdate ,  @lead_resort ,  @lead_email ,  @lead_prefix ,  @lead_givenname ,  @lead_familyname ,  @lead_address ,  @lead_address2 ,  @lead_city ,  @lead_state ,  @lead_zip ,  @lead_country ,  @lead_telephone ,  @lead_fax ,  @lead_mobile ,  @lead_form_data_1 ,  @lead_form_data_2 ,  @lead_form_data_3 ,  @lead_form_data_4 ,  @lead_form_data_5 ,  @lead_form_data_6 ,  @lead_form_data_7 ,  @lead_form_data_8 ,  @lead_form_data_9 ,  @lead_optin ,  @lead_consumer ,  @lead_bridal ,  @lead_agent ,  @lead_ttoo ,  @lead_meeting_planner ,  @lead_tourist_board_member ,  @lead_media ,  @lead_insider ,  @ip ,  @modifiedt )";
        }
        else
        {
            query = "UPDATE crm_leads SET   agent_id=@agent_id,  loyalty_id=@loyalty_id,  booking_id=@booking_id,  lead_date=@leaddate,  lead_source=@lead_source, ";
            query += "  lead_emaillist=@lead_emaillist,  lead_booking_id=@lead_booking_id,  lead_check_in_date=@leadcheckindate,  lead_check_out_date=@leadcheckoutdate, ";
            query += "  lead_wedding_date=@leadweddingdate,  lead_resort=@lead_resort,  lead_email=@lead_email,  lead_prefix=@lead_prefix,  lead_givenname=@lead_givenname, ";
            query += " lead_familyname=@lead_familyname,  lead_address=@lead_address,  lead_address2=@lead_address2,  lead_city=@lead_city,  lead_state=@lead_state,  lead_zip=@lead_zip,";
            query += " lead_country=@lead_country,  lead_telephone=@lead_telephone,  lead_fax=@lead_fax,  lead_mobile=@lead_mobile,  lead_form_data_1=@lead_form_data_1, ";
            query += " lead_form_data_2=@lead_form_data_2,  lead_form_data_3=@lead_form_data_3,  lead_form_data_4=@lead_form_data_4,  lead_form_data_5=@lead_form_data_5, ";
            query += " lead_form_data_6=@lead_form_data_6,  lead_form_data_7=@lead_form_data_7,  lead_form_data_8=@lead_form_data_8,  lead_form_data_9=@lead_form_data_9,";
            query += " lead_optin=@lead_optin,  lead_consumer=@lead_consumer,  lead_bridal=@lead_bridal,  lead_agent=@lead_agent,  lead_ttoo=@lead_ttoo, ";
            query += " lead_meeting_planner=@lead_meeting_planner,  lead_tourist_board_member=@lead_tourist_board_member,  lead_media=@lead_media,  lead_insider=@lead_insider,  ip=@ip,";
            query += " modified=@modifiedt  ";
            query += " Where  lead_id = @id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id ", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_id ", SqlDbType.Int, agent_id);
                    MetroBusdb.AddInParameter(sqlcmd, "loyalty_id ", SqlDbType.Int, loyalty_id);
                    MetroBusdb.AddInParameter(sqlcmd, "booking_id ", SqlDbType.Int, booking_id);
                    MetroBusdb.AddInParameter(sqlcmd, "leaddate ", SqlDbType.DateTime2, leaddate);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_source ", SqlDbType.VarChar, lead_source);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_emaillist ", SqlDbType.VarChar, lead_emaillist);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_booking_id ", SqlDbType.VarChar, lead_booking_id);
                    MetroBusdb.AddInParameter(sqlcmd, "leadcheckindate ", SqlDbType.Date, leadcheckindate);
                    MetroBusdb.AddInParameter(sqlcmd, "leadcheckoutdate ", SqlDbType.Date, leadcheckoutdate);
                    MetroBusdb.AddInParameter(sqlcmd, "leadweddingdate ", SqlDbType.Date, leadweddingdate);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_resort ", SqlDbType.Int, lead_resort);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_email ", SqlDbType.VarChar, lead_email);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_prefix ", SqlDbType.VarChar, lead_prefix);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_givenname ", SqlDbType.VarChar, lead_givenname);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_familyname ", SqlDbType.VarChar, lead_familyname);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_address ", SqlDbType.VarChar, lead_address);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_address2 ", SqlDbType.VarChar, lead_address2);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_city ", SqlDbType.VarChar, lead_city);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_state ", SqlDbType.VarChar, lead_state);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_zip ", SqlDbType.VarChar, lead_zip);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_country ", SqlDbType.VarChar, lead_country);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_telephone ", SqlDbType.VarChar, lead_telephone);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_fax ", SqlDbType.VarChar, lead_fax);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_mobile ", SqlDbType.VarChar, lead_mobile);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_1 ", SqlDbType.VarChar, lead_form_data_1);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_2 ", SqlDbType.VarChar, lead_form_data_2);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_3 ", SqlDbType.VarChar, lead_form_data_3);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_4 ", SqlDbType.VarChar, lead_form_data_4);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_5 ", SqlDbType.VarChar, lead_form_data_5);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_6 ", SqlDbType.VarChar, lead_form_data_6);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_7 ", SqlDbType.VarChar, lead_form_data_7);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_8 ", SqlDbType.VarChar, lead_form_data_8);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_form_data_9 ", SqlDbType.VarChar, lead_form_data_9);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_optin ", SqlDbType.Int, lead_optin);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_consumer ", SqlDbType.Char, lead_consumer);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_bridal ", SqlDbType.Char, lead_bridal);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_agent ", SqlDbType.Char, lead_agent);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_ttoo ", SqlDbType.Char, lead_ttoo);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_meeting_planner ", SqlDbType.Char, lead_meeting_planner);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_tourist_board_member ", SqlDbType.Char, lead_tourist_board_member);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_media ", SqlDbType.Char, lead_media);
                    MetroBusdb.AddInParameter(sqlcmd, "lead_insider ", SqlDbType.Char, lead_insider);
                    MetroBusdb.AddInParameter(sqlcmd, "ip ", SqlDbType.NVarChar, ip);
                    MetroBusdb.AddInParameter(sqlcmd, "modifiedt ", SqlDbType.DateTime2, modifiedt);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string AddEdit_CRM_agents
        (int agency_id, string agent_prefix, string agent_givenname, string agent_lastname, string agent_birthdate, string agent_email, string agent_address,
        string agent_address2, string agent_city, string agent_state, string agent_postal, string agent_country, string agent_telephone, string agent_mobile, string agent_fax,
        string agency_core, string agency_iata, string agency_abta, string agency_arc, string agency_clia, string agency_atol, string agency_true, string agency_taxid,
        string agent_status, string agent_status_enroll, 
        string agent_status_graduate, string agent_status_refresh,
        bool chkSpecializationGroup,
bool chkspeDestWedding,
bool chkspeMeetingPlanner,
bool chkspeFamilyFriendly,
bool chkspeAdultOnly,
bool chkspeLuxResorts,
bool chkTermsCondi,
bool chkEmailMarketing,
        int id, int status)
    {
        string agentbirthdate = DateTime.Now.ToShortDateString();
        string agentstatusenroll = DateTime.Now.ToShortDateString();
        string agentstatusgraduate = DateTime.Now.ToShortDateString();
        string agentstatusrefresh = DateTime.Now.ToShortDateString();

        if (agent_birthdate != "" || agent_birthdate.Length > 0)
        {
            agentbirthdate = agent_birthdate.Substring(6, 4) + "-" +
                          agent_birthdate.Substring(3, 2) + "-" +
                          agent_birthdate.Substring(0, 2);
        }
        if (agent_status_enroll != "" || agent_status_enroll.Length > 0)
        {
            agentstatusenroll = agent_status_enroll.Substring(6, 4) + "-" +
                             agent_status_enroll.Substring(3, 2) + "-" +
                             agent_status_enroll.Substring(0, 2);
        }

        if (agent_status_graduate != "" || agent_status_graduate.Length > 0)
        {
            agentstatusgraduate = agent_status_graduate.Substring(6, 4) + "-" +
                         agent_status_graduate.Substring(3, 2) + "-" +
                         agent_status_graduate.Substring(0, 2);
        }
        if (agent_status_refresh != "" || agent_status_refresh.Length > 0)
        {
            agentstatusrefresh = agent_status_refresh.Substring(6, 4) + "-" +
                        agent_status_refresh.Substring(3, 2) + "-" +
                        agent_status_refresh.Substring(0, 2);
        }


        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_agents (   agency_id ,  agent_prefix ,  agent_givenname ,  agent_lastname ,  agent_birthdate ,  agent_email ,  agent_address ,  agent_address2 ,  agent_city ,  agent_state ,  agent_postal ,  agent_country ,  agent_telephone ,  agent_mobile ,  agent_fax ,  agency_core ,  agency_iata ,  agency_abta ,  agency_arc ,  agency_clia ,  agency_atol ,  agency_true ,  agency_taxid ,  agent_status ,  agent_status_enroll ,  agent_status_graduate ,  agent_status_refresh,agent_spec_group, agent_spec_wedding, agent_spec_meeting, agent_spec_family, agent_spec_adults, agent_spec_luxury, agent_agree,agent_receiveEmail   )";
            query += "  VALUES (   @agency_id ,  @agent_prefix ,  @agent_givenname ,  @agent_lastname ,  @agentbirthdate ,  @agent_email ,  @agent_address ,  @agent_address2 ,  @agent_city ,  @agent_state ,  @agent_postal ,  @agent_country ,  @agent_telephone ,  @agent_mobile ,  @agent_fax ,  @agency_core ,  @agency_iata ,  @agency_abta ,  @agency_arc ,  @agency_clia ,  @agency_atol ,  @agency_true ,  @agency_taxid ,  @agent_status ,  @agentstatusenroll ,  @agentstatusgraduate ,  @agentstatusrefresh,@agent_spec_group, @agent_spec_wedding, @agent_spec_meeting, @agent_spec_family, @agent_spec_adults, @agent_spec_luxury,  @agent_agree,@agent_receiveEmail   )";
        }
        else
        {
            query = " UPDATE crm_agents SET     agency_id=@agency_id,  agent_prefix=@agent_prefix,  agent_givenname=@agent_givenname,";
            query += "  agent_lastname=@agent_lastname,  agent_birthdate=@agentbirthdate,  agent_email=@agent_email,  agent_address=@agent_address,  agent_address2=@agent_address2, ";
            query += "  agent_city=@agent_city,  agent_state=@agent_state,  agent_postal=@agent_postal,  agent_country=@agent_country,  agent_telephone=@agent_telephone, ";
            query += "  agent_mobile=@agent_mobile,  agent_fax=@agent_fax,  agency_core=@agency_core,  agency_iata=@agency_iata,  agency_abta=@agency_abta,  agency_arc=@agency_arc, ";
            query += "  agency_clia=@agency_clia,  agency_atol=@agency_atol,  agency_true=@agency_true,  agency_taxid=@agency_taxid,  agent_status=@agent_status, ";
            query += "  agent_status_enroll=@agentstatusenroll,  agent_status_graduate=@agentstatusgraduate,  agent_status_refresh=@agentstatusrefresh, ";
            query += "  agent_spec_group=@agent_spec_group, agent_spec_wedding=@agent_spec_wedding, agent_spec_meeting=@agent_spec_meeting, agent_spec_family=@agent_spec_family, ";
            query += "  agent_spec_adults=@agent_spec_adults, agent_spec_luxury=@agent_spec_luxury, agent_agree=@agent_agree,agent_receiveEmail=@agent_receiveEmail   ";
            query += "  Where  agent_id = @id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id ", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_id ", SqlDbType.Int, agency_id);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_prefix ", SqlDbType.VarChar, agent_prefix);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_givenname ", SqlDbType.VarChar, agent_givenname);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_lastname ", SqlDbType.VarChar, agent_lastname);
                    MetroBusdb.AddInParameter(sqlcmd, "agentbirthdate ", SqlDbType.Date, agentbirthdate);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_email ", SqlDbType.VarChar, agent_email);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_address ", SqlDbType.VarChar, agent_address);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_address2 ", SqlDbType.VarChar, agent_address2);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_city ", SqlDbType.VarChar, agent_city);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_state ", SqlDbType.VarChar, agent_state);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_postal ", SqlDbType.VarChar, agent_postal);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_country ", SqlDbType.VarChar, agent_country);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_telephone ", SqlDbType.VarChar, agent_telephone);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_mobile ", SqlDbType.VarChar, agent_mobile);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_fax ", SqlDbType.VarChar, agent_fax);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_core ", SqlDbType.VarChar, agency_core);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_iata ", SqlDbType.VarChar, agency_iata);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_abta ", SqlDbType.VarChar, agency_abta);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_arc ", SqlDbType.VarChar, agency_arc);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_clia ", SqlDbType.VarChar, agency_clia);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_atol ", SqlDbType.VarChar, agency_atol);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_true ", SqlDbType.VarChar, agency_true);
                    MetroBusdb.AddInParameter(sqlcmd, "agency_taxid ", SqlDbType.VarChar, agency_taxid);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_status ", SqlDbType.VarChar, agent_status);
                    MetroBusdb.AddInParameter(sqlcmd, "agentstatusenroll ", SqlDbType.Date, agentstatusenroll);
                    MetroBusdb.AddInParameter(sqlcmd, "agentstatusgraduate ", SqlDbType.Date, agentstatusgraduate);
                    MetroBusdb.AddInParameter(sqlcmd, "agentstatusrefresh ", SqlDbType.Date, agentstatusrefresh);

                    MetroBusdb.AddInParameter(sqlcmd, "agent_spec_group ", SqlDbType.Int, chkSpecializationGroup?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_spec_wedding ", SqlDbType.Int, chkspeDestWedding?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_spec_meeting ", SqlDbType.Int, chkspeMeetingPlanner?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_spec_family ", SqlDbType.Int, chkspeFamilyFriendly?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_spec_adults ", SqlDbType.Int, chkspeAdultOnly?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_spec_luxury ", SqlDbType.Int, chkspeLuxResorts?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_agree ", SqlDbType.Int, chkTermsCondi?1:0);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_receiveEmail ", SqlDbType.Int, chkEmailMarketing? 1 : 0);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_MenuCategorie(int Id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (Id != 0)
        {
            query = "Select * From portal_userpanel_categories  where id = @Id";
        }
        else
        {
            query = "Select * From portal_userpanel_categories ";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "Id", SqlDbType.Int, Id);

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

    public static string AddEdit_MenuCategorie(int priority, string name, string image, string last_modified, int ID, int status)
    {

        string lastmodified = last_modified.Substring(6, 4) + "-" +
                                 last_modified.Substring(3, 2) + "-" +
                                 last_modified.Substring(0, 2);

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  portal_userpanel_categories (  priority ,  name , image, last_modified  )";
            query += " VALUES ( @priority ,@name , @image ,  @lastmodified  )";
        }
        else
        {
            query = "UPDATE portal_userpanel_categories SET  priority=@priority,name=@name,  image=@image,  last_modified=@lastmodified ";
            query += " Where  id = @ID";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "ID", SqlDbType.Int, ID);
                    MetroBusdb.AddInParameter(sqlcmd, "priority", SqlDbType.Int, priority);
                    MetroBusdb.AddInParameter(sqlcmd, "name", SqlDbType.VarChar, name);
                    MetroBusdb.AddInParameter(sqlcmd, "image", SqlDbType.VarChar, image);
                    MetroBusdb.AddInParameter(sqlcmd, "lastmodified", SqlDbType.DateTime, lastmodified);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string AddEdit_booking
        (int agent_id, int ttoo_id, int resort_id, int promo_id, int roomtype_id, string book_date, string book_rez, string book_check_in,
        string book_check_out, int book_nights, int book_roomtype, int book_terms, int book_group, int book_wedding, string guest_firstname, string guest_lastname,
        string guest_email, int guest_loyalty, int pms_prestay, int pms_poststay, string pms_check_in, string pms_check_out, int pms_nights, int pms_roomtype,
        decimal pms_pretax_value, decimal pms_posttax_value, string created, string updated, int id, int status, string pms_book_rez)
    {
        string bookdate = DateTime.Now.ToShortDateString();
        string bookcheckin = DateTime.Now.ToShortDateString();
        string bookcheckout = DateTime.Now.ToShortDateString();
        string pmscheckin = DateTime.Now.ToShortDateString();
        string pmscheckout = DateTime.Now.ToShortDateString();
        string createdt = DateTime.Now.ToShortDateString();
        string updatedt = DateTime.Now.ToShortDateString();

        if (book_date != "" || book_date.Count() > 0)
        {
            bookdate = book_date.Substring(6, 4) + "-" +
                    book_date.Substring(3, 2) + "-" +
                    book_date.Substring(0, 2);
        }
        if (book_check_in != "" || book_check_in.Count() > 0)
        {
            bookcheckin = book_check_in.Substring(6, 4) + "-" +
                    book_check_in.Substring(3, 2) + "-" +
                    book_check_in.Substring(0, 2);
        }
        if (book_check_out != "" || book_check_out.Count() > 0)
        {
            bookcheckout = book_check_out.Substring(6, 4) + "-" +
                book_check_out.Substring(3, 2) + "-" +
                book_check_out.Substring(0, 2);
        }
        if (pms_check_in != "" || pms_check_in.Count() > 0)
        {
            pmscheckin = pms_check_in.Substring(6, 4) + "-" +
                pms_check_in.Substring(3, 2) + "-" +
                pms_check_in.Substring(0, 2);
        }
        if (pms_check_out != "" || pms_check_out.Count() > 0)
        {
            pmscheckout = pms_check_out.Substring(6, 4) + "-" +
                    pms_check_out.Substring(3, 2) + "-" +
                    pms_check_out.Substring(0, 2);
        }
        if (created != "" || created.Count() > 0)
        {
            createdt = created.Substring(6, 4) + "-" +
                    created.Substring(3, 2) + "-" +
                    created.Substring(0, 2);
        }
        if (updated != "" || updated.Count() > 0)
        {
            updatedt = updated.Substring(6, 4) + "-" +
                updated.Substring(3, 2) + "-" +
                updated.Substring(0, 2);
        }

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_booking (  agent_id ,  ttoo_id ,  resort_id ,  promo_id ,  roomtype_id ,  book_date ,  book_rez ,  book_check_in ,  book_check_out ,  book_nights ,  book_roomtype ,  book_terms ,  book_group ,  book_wedding ,  guest_firstname ,  guest_lastname ,  guest_email ,  guest_loyalty ,  pms_prestay ,  pms_poststay ,  pms_check_in ,  pms_check_out ,  pms_nights ,  pms_roomtype ,  pms_pretax_value ,  pms_posttax_value ,  created ,  updated,pms_book_rez  )";
            query += "VALUES (   @agent_id ,  @ttoo_id ,  @resort_id ,  @promo_id ,  @roomtype_id ,  @bookdate ,  @book_rez ,  @bookcheckin ,  @bookcheckout ,  @book_nights ,  @book_roomtype ,  @book_terms ,  @book_group ,  @book_wedding ,  @guest_firstname ,  @guest_lastname ,  @guest_email ,  @guest_loyalty ,  @pms_prestay ,  @pms_poststay ,  @pmscheckin ,  @pmscheckout ,  @pms_nights ,  @pms_roomtype ,  @pms_pretax_value ,  @pms_posttax_value ,  @createdt ,  @updatedt,@pms_book_rez  )";
        }
        else
        {
            query = "UPDATE crm_booking SET  agent_id=@agent_id,  ttoo_id=@ttoo_id,  resort_id=@resort_id,  promo_id=@promo_id,  roomtype_id=@roomtype_id,  book_date=@bookdate,  ";
            query += " book_rez=@book_rez,  book_check_in=@bookcheckin,  book_check_out=@bookcheckout,  book_nights=@book_nights,  book_roomtype=@book_roomtype,  book_terms=@book_terms, ";
            query += " book_group=@book_group,  book_wedding=@book_wedding,  guest_firstname=@guest_firstname,  guest_lastname=@guest_lastname,  guest_email=@guest_email, ";
            query += " guest_loyalty=@guest_loyalty,  pms_prestay=@pms_prestay,  pms_poststay=@pms_poststay,  pms_check_in=@pmscheckin,  pms_check_out=@pmscheckout, ";
            query += " pms_nights=@pms_nights,  pms_roomtype=@pms_roomtype,  pms_pretax_value=@pms_pretax_value,  pms_posttax_value=@pms_posttax_value,  created=@createdt, ";
            query += " updated=@updatedt ,pms_book_rez=@pms_book_rez ";
            query += "  Where  booking_id = @id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "agent_id", SqlDbType.Int, agent_id);
                    MetroBusdb.AddInParameter(sqlcmd, "ttoo_id", SqlDbType.Int, ttoo_id);
                    MetroBusdb.AddInParameter(sqlcmd, "resort_id", SqlDbType.Int, resort_id);
                    MetroBusdb.AddInParameter(sqlcmd, "promo_id", SqlDbType.Int, promo_id);
                    MetroBusdb.AddInParameter(sqlcmd, "roomtype_id", SqlDbType.Int, roomtype_id);
                    MetroBusdb.AddInParameter(sqlcmd, "bookdate", SqlDbType.DateTime2, bookdate);
                    MetroBusdb.AddInParameter(sqlcmd, "book_rez", SqlDbType.VarChar, book_rez);
                    MetroBusdb.AddInParameter(sqlcmd, "bookcheckin", SqlDbType.DateTime2, bookcheckin);
                    MetroBusdb.AddInParameter(sqlcmd, "bookcheckout", SqlDbType.DateTime2, bookcheckout);
                    MetroBusdb.AddInParameter(sqlcmd, "book_nights", SqlDbType.Int, book_nights);
                    MetroBusdb.AddInParameter(sqlcmd, "book_roomtype", SqlDbType.Int, book_roomtype);
                    MetroBusdb.AddInParameter(sqlcmd, "book_terms", SqlDbType.Int, book_terms);
                    MetroBusdb.AddInParameter(sqlcmd, "book_group", SqlDbType.Int, book_group);
                    MetroBusdb.AddInParameter(sqlcmd, "book_wedding", SqlDbType.Int, book_wedding);
                    MetroBusdb.AddInParameter(sqlcmd, "guest_firstname", SqlDbType.VarChar, guest_firstname);
                    MetroBusdb.AddInParameter(sqlcmd, "guest_lastname", SqlDbType.VarChar, guest_lastname);
                    MetroBusdb.AddInParameter(sqlcmd, "guest_email", SqlDbType.VarChar, guest_email);
                    MetroBusdb.AddInParameter(sqlcmd, "guest_loyalty", SqlDbType.Int, guest_loyalty);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_prestay", SqlDbType.Int, pms_prestay);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_poststay", SqlDbType.Int, pms_poststay);
                    MetroBusdb.AddInParameter(sqlcmd, "pmscheckin", SqlDbType.DateTime2, pmscheckin);
                    MetroBusdb.AddInParameter(sqlcmd, "pmscheckout", SqlDbType.DateTime2, pmscheckout);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_nights", SqlDbType.Int, pms_nights);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_roomtype", SqlDbType.Int, pms_roomtype);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_pretax_value", SqlDbType.Decimal, pms_pretax_value);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_posttax_value", SqlDbType.Decimal, pms_posttax_value);
                    MetroBusdb.AddInParameter(sqlcmd, "createdt", SqlDbType.DateTime2, createdt);
                    MetroBusdb.AddInParameter(sqlcmd, "updatedt", SqlDbType.DateTime2, updatedt);
                    MetroBusdb.AddInParameter(sqlcmd, "pms_book_rez", SqlDbType.VarChar, pms_book_rez);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Slides(int Id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (Id != 0)
        {
            query = "Select * From cms_sliders  where id = @Id";
        }
        else
        {
            query = "Select * From cms_sliders ";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "Id", SqlDbType.Int, Id);

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

    public static string AddEdit_sliders
        (string en_heading, string en_sub_heading, string en_action_title, string en_action_url,
        string es_heading, string es_sub_heading, string es_action_title, string es_action_url, string fr_heading,
        string fr_sub_heading, string fr_action_title, string fr_action_url, string image_url, int active, int resort_id, int main_page, int ID, int status)
    {

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  cms_sliders (en_heading,en_sub_heading,en_action_title,en_action_url,es_heading,es_sub_heading,es_action_title,es_action_url,fr_heading,fr_sub_heading,fr_action_title,fr_action_url,image_url,active,resort_id,main_page)";
            query += " VALUES (@en_heading,@en_sub_heading,@en_action_title,@en_action_url,@es_heading,@es_sub_heading,@es_action_title,@es_action_url,@fr_heading,@fr_sub_heading,@fr_action_title,@fr_action_url,@image_url,@active,@resort_id,@main_page)";
        }
        else
        {
            query = "UPDATE cms_sliders SET  en_heading=@en_heading,en_sub_heading=@en_sub_heading,en_action_title=@en_action_title,en_action_url=@en_action_url,es_heading=@es_heading,es_sub_heading=@es_sub_heading,es_action_title=@es_action_title,es_action_url=@es_action_url,fr_heading=@fr_heading,fr_sub_heading=@fr_sub_heading,fr_action_title=@fr_action_title,fr_action_url=@fr_action_url,image_url=@image_url,active=@active,resort_id =@resort_id ,main_page = @main_page ";
            query += " Where  id = @ID";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, ID);
                    MetroBusdb.AddInParameter(sqlcmd, "en_heading", SqlDbType.VarChar, en_heading);
                    MetroBusdb.AddInParameter(sqlcmd, "en_sub_heading", SqlDbType.VarChar, en_sub_heading);
                    MetroBusdb.AddInParameter(sqlcmd, "en_action_title", SqlDbType.VarChar, en_action_title);
                    MetroBusdb.AddInParameter(sqlcmd, "en_action_url", SqlDbType.VarChar, en_action_url);
                    MetroBusdb.AddInParameter(sqlcmd, "es_heading", SqlDbType.VarChar, es_heading);
                    MetroBusdb.AddInParameter(sqlcmd, "es_sub_heading", SqlDbType.VarChar, es_sub_heading);
                    MetroBusdb.AddInParameter(sqlcmd, "es_action_title", SqlDbType.VarChar, es_action_title);
                    MetroBusdb.AddInParameter(sqlcmd, "es_action_url", SqlDbType.VarChar, es_action_url);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_heading", SqlDbType.VarChar, fr_heading);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_sub_heading", SqlDbType.VarChar, fr_sub_heading);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_action_title", SqlDbType.VarChar, fr_action_title);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_action_url", SqlDbType.VarChar, fr_action_url);
                    MetroBusdb.AddInParameter(sqlcmd, "image_url", SqlDbType.VarChar, image_url);
                    MetroBusdb.AddInParameter(sqlcmd, "active", SqlDbType.Int, active);
                    MetroBusdb.AddInParameter(sqlcmd, "resort_id", SqlDbType.Int, resort_id);
                    MetroBusdb.AddInParameter(sqlcmd, "main_page", SqlDbType.Int, main_page);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_News(int Id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (Id != 0)
        {
            query = "Select * From cms_news  where id = @Id";
        }
        else
        {
            query = "Select * From cms_news ";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "Id", SqlDbType.Int, Id);

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

    public static string AddEdit_News
        (string en_newsitem, string en_action_title, string en_action_url, string es_newsitem, string es_action_title,
        string es_action_url, string fr_newsitem, string fr_action_title,
        string fr_action_url, int active, int resort_id, int main_page,
        int ID, int status)
    {

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  cms_news (en_newsitem,en_action_title ,en_action_url,es_newsitem,es_action_title ,es_action_url,fr_newsitem,fr_action_title ,fr_action_url,active ,resort_id ,main_page)";
            query += " VALUES (@en_newsitem,@en_action_title ,@en_action_url,@es_newsitem,@es_action_title ,@es_action_url,@fr_newsitem,@fr_action_title ,@fr_action_url,@active ,@resort_id ,@main_page)";
        }
        else
        {
            query = "UPDATE cms_news SET  en_newsitem=@en_newsitem,en_action_title=@en_action_title ,en_action_url=@en_action_url,es_newsitem=@es_newsitem,es_action_title=@es_action_title ,es_action_url=@es_action_url,fr_newsitem=@fr_newsitem,fr_action_title=@fr_action_title ,fr_action_url=@fr_action_url,active=@active,resort_id = @resort_id ,main_page = @main_page ";
            query += " Where  id = @ID";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "ID", SqlDbType.Int, ID);
                    MetroBusdb.AddInParameter(sqlcmd, "en_newsitem", SqlDbType.VarChar, en_newsitem);
                    MetroBusdb.AddInParameter(sqlcmd, "en_action_title", SqlDbType.VarChar, en_action_title);
                    MetroBusdb.AddInParameter(sqlcmd, "en_action_url", SqlDbType.VarChar, en_action_url);

                    MetroBusdb.AddInParameter(sqlcmd, "es_newsitem", SqlDbType.VarChar, es_newsitem);
                    MetroBusdb.AddInParameter(sqlcmd, "es_action_title", SqlDbType.VarChar, es_action_title);
                    MetroBusdb.AddInParameter(sqlcmd, "es_action_url", SqlDbType.VarChar, es_action_url);

                    MetroBusdb.AddInParameter(sqlcmd, "fr_newsitem", SqlDbType.VarChar, fr_newsitem);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_action_title", SqlDbType.VarChar, fr_action_title);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_action_url", SqlDbType.VarChar, fr_action_url);

                    MetroBusdb.AddInParameter(sqlcmd, "active", SqlDbType.Int, active);
                    MetroBusdb.AddInParameter(sqlcmd, "resort_id", SqlDbType.Int, resort_id);
                    MetroBusdb.AddInParameter(sqlcmd, "main_page", SqlDbType.Int, main_page);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Setting(int Id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (Id != 0)
        {
            query = "Select * From cms_settings  where id = @Id";
        }
        else
        {
            query = "Select * From cms_settings ";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "Id", SqlDbType.Int, Id);

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

    public static string AddEdit_Setting(string setting_value, int ID, int status)
    {

        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  cms_settings (setting_value)";
            query += " VALUES (@setting_value)";
        }
        else
        {
            query = "UPDATE cms_settings SET  setting_value=@setting_value ";
            query += " Where  id = @ID";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "ID", SqlDbType.Int, ID);
                    MetroBusdb.AddInParameter(sqlcmd, "setting_value", SqlDbType.VarChar, setting_value);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }
    public static string Select_Regions(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_regions where region_id =@id";
        }
        else
        {
            query = "select * from crm_regions";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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


    public static string AddEdit_Regions(string short_name, string long_name, int id, int status)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_regions (short_name,long_name) VALUES ( @short_name ,@long_name)";
        }
        else {
            query = "UPDATE crm_regions SET short_name = @short_name, long_name = @long_name   Where region_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "short_name", SqlDbType.VarChar, short_name);
                    MetroBusdb.AddInParameter(sqlcmd, "long_name", SqlDbType.VarChar, long_name);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Images(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select crm_images.*,crm_resorts.resort_name AS resort_name From crm_images LEFT OUTER JOIN crm_resorts ON crm_resorts.resort_id = crm_images.resort_id where crm_images.image_id =@id";
        }
        else
        {
            query = "Select crm_images.*,crm_resorts.resort_name AS resort_name From crm_images LEFT OUTER JOIN crm_resorts ON crm_resorts.resort_id = crm_images.resort_id ";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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


    public static string AddEdit_Images(int resort_id, string image_url, string image_alt_text, int id, int status)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_images (resort_id,image_url,image_alt_text) VALUES ( @resort_id,@image_url,@image_alt_text)";
        }
        else {
            query = "UPDATE crm_images SET resort_id = @resort_id, image_url = @image_url, image_alt_text = @image_alt_text   Where image_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "@resort_id", SqlDbType.Int, resort_id);
                    MetroBusdb.AddInParameter(sqlcmd, "@image_url", SqlDbType.VarChar, image_url);
                    MetroBusdb.AddInParameter(sqlcmd, "@image_alt_text", SqlDbType.VarChar, image_alt_text);
                    MetroBusdb.AddInParameter(sqlcmd, "@id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Cards(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Select crm_tentcards.*,crm_resorts.resort_name AS resort_name From crm_tentcards LEFT OUTER JOIN crm_resorts ON crm_resorts.resort_id = crm_tentcards.resort_id where tentcard_id =@id";
        }
        else
        {
            query = "Select crm_tentcards.tentcard_id,crm_tentcards.title,crm_resorts.resort_name AS resort_name From crm_tentcards LEFT OUTER JOIN crm_resorts ON crm_resorts.resort_id = crm_tentcards.resort_id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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


    public static string AddEdit_Cards(int resort_id, string title_bkgd_hex, string title_text_hex, string title, string description, string read_more_url, int id, int status)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (status == 1)
        {
            query = "Insert into  crm_tentcards (resort_id, title_bkgd_hex, title_text_hex, title, description, read_more_url) VALUES (@resort_id,@title_bkgd_hex,@title_text_hex,@title,@description,@read_more_url)";
        }
        else {
            query = "UPDATE crm_tentcards SET resort_id=@resort_id, title_bkgd_hex=@title_bkgd_hex, title_text_hex=@title_text_hex, title=@title, description=@description, read_more_url=@read_more_url   Where tentcard_id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "@resort_id", SqlDbType.Int, resort_id);
                    MetroBusdb.AddInParameter(sqlcmd, "@title_bkgd_hex", SqlDbType.VarChar, title_bkgd_hex);
                    MetroBusdb.AddInParameter(sqlcmd, "@title_text_hex", SqlDbType.VarChar, title_text_hex);
                    MetroBusdb.AddInParameter(sqlcmd, "@title", SqlDbType.VarChar, title);
                    MetroBusdb.AddInParameter(sqlcmd, "@description", SqlDbType.VarChar, description);
                    MetroBusdb.AddInParameter(sqlcmd, "@read_more_url", SqlDbType.VarChar, read_more_url);

                    MetroBusdb.AddInParameter(sqlcmd, "@id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_Assets(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = @"SELECT        
dbo.crm_assets.id, 
dbo.crm_assets.category_id, 
dbo.crm_assets.brand_id, 
dbo.crm_assets.grouping_id,
dbo.crm_assets.resort_id, 
dbo.crm_assets.en_title, 
dbo.crm_assets.es_title, dbo.crm_assets.fr_title,
dbo.crm_assets.low_resolution, 
                         dbo.crm_assets.high_resolution, dbo.crm_assets.status, crm_assets_category.en_title AS CategoryName, crm_assets_category.icon
                            FROM            dbo.crm_assets LEFT OUTER JOIN
                         crm_assets_category ON dbo.crm_assets.category_id = crm_assets_category.id where dbo.crm_assets.id =@id";
        }
        else
        {
            query = @"SELECT        dbo.crm_assets.id, dbo.crm_assets.category_id, dbo.crm_assets.brand_id, dbo.crm_assets.resort_id, dbo.crm_assets.en_title, dbo.crm_assets.es_title, dbo.crm_assets.fr_title, dbo.crm_assets.low_resolution, 
                         dbo.crm_assets.high_resolution, dbo.crm_assets.status, crm_assets_category.en_title AS CategoryName, crm_assets_category.icon
                        FROM            dbo.crm_assets LEFT OUTER JOIN
                         crm_assets_category ON dbo.crm_assets.category_id = crm_assets_category.id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_Assets(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_assets where id =@id";
        }
        else
        {
            query = "Delete  from crm_assets where id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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
    
    public static string AddEdit_Assets
       (int category_id,int group_id, int resort_id, int brand_id, string en_title,
        string es_title, string fr_title, string low_resolution, string high_resolution,
        int status, int id, int sts)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (sts == 1)
        {
            query = "Insert into  crm_assets  ";
            query += "(category_id,grouping_id, resort_id, brand_id, en_title, es_title, fr_title, low_resolution, high_resolution, status)";
            query += " VALUES ";
            query += " (@category_id,@grouping_id, @resort_id, @brand_id, @en_title, @es_title, @fr_title, @low_resolution, @high_resolution, @status)";
        }
        else
        {
            query = "UPDATE crm_assets SET   ";
            query += "category_id = @category_id,grouping_id=@grouping_id, resort_id = @resort_id ,brand_id = @brand_id , en_title = @en_title ,es_title = @es_title ,fr_title = @fr_title, ";
            query += "low_resolution = @low_resolution ,high_resolution = @high_resolution ,status = @status  ";
            query += " Where id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "category_id", SqlDbType.Int, category_id);
                    MetroBusdb.AddInParameter(sqlcmd, "grouping_id", SqlDbType.Int, group_id);
                    MetroBusdb.AddInParameter(sqlcmd, "resort_id", SqlDbType.Int, resort_id);
                    MetroBusdb.AddInParameter(sqlcmd, "brand_id", SqlDbType.Int, brand_id);
                    MetroBusdb.AddInParameter(sqlcmd, "en_title", SqlDbType.VarChar, en_title);
                    MetroBusdb.AddInParameter(sqlcmd, "es_title", SqlDbType.VarChar, es_title);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_title", SqlDbType.VarChar, fr_title);
                    MetroBusdb.AddInParameter(sqlcmd, "low_resolution", SqlDbType.VarChar, low_resolution);
                    MetroBusdb.AddInParameter(sqlcmd, "high_resolution", SqlDbType.VarChar, high_resolution);
                    MetroBusdb.AddInParameter(sqlcmd, "status", SqlDbType.Int, status);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }
    #region Grouping
    public static string Select_Groups(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = @"select id, grouping_en, grouping_fr, grouping_es from [dbo].[crm_assets_grouping] with(nolock) where id =@id";
        }
       
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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
    public static string Delete_Groups(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_assets_grouping where id =@id";
        }
        else
        {
            query = "Delete  from crm_assets_grouping where id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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
    public static string AddEdit_Groups
      (string grouping_en,
       string grouping_fr, string grouping_es,
        int id, int sts)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        StringBuilder sbQuery = new StringBuilder();
        if (sts == 1)
        {
            sbQuery.Append(@"Insert into  crm_assets_grouping (grouping_en, grouping_fr, grouping_es ) VALUES (@grouping_en,@grouping_fr, @grouping_es)");
        }
        else
        {
            sbQuery.Append(@"UPDATE  crm_assets_grouping  SET grouping_en = @grouping_en,grouping_fr=@grouping_fr, grouping_es= @grouping_es Where id = @id");
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(sbQuery.ToString(), SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "grouping_en", SqlDbType.VarChar, grouping_en);
                    MetroBusdb.AddInParameter(sqlcmd, "grouping_fr", SqlDbType.VarChar, grouping_fr);
                    MetroBusdb.AddInParameter(sqlcmd, "grouping_es", SqlDbType.VarChar, grouping_es);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }
    #endregion

    public static string Select_AssetsGrouping(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select id, grouping_en, grouping_fr, grouping_es from [dbo].[crm_assets_grouping] where id =@id";
        }
        else
        {
            query = "select id, grouping_en, grouping_fr, grouping_es from [dbo].[crm_assets_grouping]";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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
    public static string Select_AssetCategory(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select * from crm_assets_category where id =@id";
        }
        else
        {
            query = "select * from crm_assets_category";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string Delete_AssetCategory(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "Delete  from crm_assets_category where id =@id";
        }
        else
        {
            query = "Delete  from crm_assets_category where id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_AssetCategory
      (string en_title, string es_title, string fr_title, string icon, string icon_background_color, string text_background_color, string text_color, int status, int id, int sts)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (sts == 1)
        {
            query = "Insert into  crm_assets_category  ";
            query += "( en_title, es_title, fr_title, icon, icon_background_color, text_background_color, text_color , status)";
            query += " VALUES ";
            query += " ( @en_title, @es_title, @fr_title, @icon, @icon_background_color, @text_background_color, @text_color ,@status)";
        }
        else
        {
            query = "UPDATE crm_assets_category SET   ";
            query += " en_title = @en_title ,es_title = @es_title ,fr_title = @fr_title, ";
            query += "icon = @icon ,icon_background_color = @icon_background_color,text_background_color = @text_background_color, text_color = @text_color ,status = @status  ";
            query += "  Where id = @id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {

                    MetroBusdb.AddInParameter(sqlcmd, "en_title", SqlDbType.VarChar, en_title);
                    MetroBusdb.AddInParameter(sqlcmd, "es_title", SqlDbType.VarChar, es_title);
                    MetroBusdb.AddInParameter(sqlcmd, "fr_title", SqlDbType.VarChar, fr_title);
                    MetroBusdb.AddInParameter(sqlcmd, "icon", SqlDbType.VarChar, icon);
                    MetroBusdb.AddInParameter(sqlcmd, "icon_background_color", SqlDbType.VarChar, icon_background_color);
                    MetroBusdb.AddInParameter(sqlcmd, "text_background_color", SqlDbType.VarChar, text_background_color);
                    MetroBusdb.AddInParameter(sqlcmd, "text_color", SqlDbType.VarChar, text_color);
                    MetroBusdb.AddInParameter(sqlcmd, "status", SqlDbType.Int, status);
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }

    public static string Select_AgentsByAgencyID(int id)
    {
        int count = 0;
        AGAIN:
        DataTable dtReturn = new DataTable();
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;
        string query = "";
        if (id != 0)
        {
            query = "select agent_id ,agent_email from crm_agents where agency_id =@id";
        }
        else
        {
            query = "select agent_id ,agent_email from crm_agents where agency_id =@id";
        }
        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id", SqlDbType.Int, id);

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

    public static string AddEdit_CRMPages(int id, string title_en, string title_fr, string title_es, string content_en, string content_fr, string content_es, int status, int sts)
    {
        int count = 0;
        AGAIN:
        // DataTable dtReturn = new DataTable();
        bool result = false;
        SqlConnection SqlCon = new SqlConnection();
        bool isDeadLock = false;

        string query = "";
        if (sts == 1)
        {
            query = @"Insert into  crm_pages (  title_en ,  title_fr ,  title_es ,  content_en ,  content_fr ,  content_es ,  status  )
            VALUES (   @title_en ,  @title_fr ,  @title_es ,  @content_en ,  @content_fr ,  @content_es ,  @status  )";
        }
        else {
            query = @"UPDATE crm_pages SET  title_en=@title_en,  title_fr=@title_fr,  title_es=@title_es,  content_en=@content_en,  content_fr=@content_fr,  content_es=@content_es,  status=@status 
            Where id=@id";
        }

        try
        {
            SqlCon = MetroBusdb.OpenConnection(SqlCon);
            if (SqlCon.State == ConnectionState.Open)
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, SqlCon))
                {
                    MetroBusdb.AddInParameter(sqlcmd, "id ", SqlDbType.Int, id);
                    MetroBusdb.AddInParameter(sqlcmd, "title_en ", SqlDbType.VarChar, title_en);
                    MetroBusdb.AddInParameter(sqlcmd, "title_fr ", SqlDbType.VarChar, title_fr);
                    MetroBusdb.AddInParameter(sqlcmd, "title_es ", SqlDbType.VarChar, title_es);
                    MetroBusdb.AddInParameter(sqlcmd, "content_en ", SqlDbType.NText, content_en);
                    MetroBusdb.AddInParameter(sqlcmd, "content_fr ", SqlDbType.NText, content_fr);
                    MetroBusdb.AddInParameter(sqlcmd, "content_es ", SqlDbType.NText, content_es);
                    MetroBusdb.AddInParameter(sqlcmd, "status ", SqlDbType.Int, status);
                    result = MetroBusdb.ExecuteStoreProcedure(sqlcmd, out isDeadLock);

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
        JSONString = JsonConvert.SerializeObject(result);
        return JSONString;

    }


}