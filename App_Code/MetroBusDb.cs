using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Reflection;
using System.Globalization;

/// <summary>
/// Summary description for SSTDatabase
/// </summary>
public static partial class MetroBusdb
{
    private static string GetConnectionString
    {
        get
        {
            string conStr = "";
            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //conStr = "Data Source=" + ConfigurationManager.AppSettings["DataSource"]
            //    + ";Initial Catalog=" + ConfigurationManager.AppSettings["Database"]
            //    + ";User ID=" + ConfigurationManager.AppSettings["DbUser"]
            //    + ";Password=" + ConfigurationManager.AppSettings["DbPassword"];
            return conStr;
        }
    }

    public static SqlConnection OpenConnection(SqlConnection paraSQLCon)
    {
        try
        {
            GC.Collect();
            paraSQLCon = new SqlConnection(MetroBusdb.GetConnectionString);
            paraSQLCon.Open();
        }
        catch (Exception ex)
        {
            
        }

        return paraSQLCon;
    }

    public static void CloseConnection(SqlConnection paraSQLCon)
    {
        try
        {
            if (paraSQLCon != null)
            {
                if (paraSQLCon.State == ConnectionState.Open)
                    paraSQLCon.Close();
                paraSQLCon.Dispose();
                paraSQLCon = null;
            }
        }
        catch (Exception ex)
        {
            
        }

        GC.Collect();
    }

    public static DataTable GetDataTable(SqlCommand paraCmd, out bool isDeadLock)
    {
        DataTable dtReturn = new DataTable();
        isDeadLock = false;
        try
        {
            paraCmd.CommandType = CommandType.Text;
            paraCmd.CommandTimeout = 200;
            using (SqlDataAdapter Adp = new SqlDataAdapter(paraCmd))
            {
                Adp.Fill(dtReturn);
            }
        }
        catch (SqlException e)
        {
            string error1 = "was deadlocked on lock resources with another process and has been chosen as the deadlock victim.";
            string error2 = "A transport-level error has occurred when sending the request to the server.";
            string error3 = "An existing connection was forcibly closed by the remote host.";

            isDeadLock = (e.ToString().Contains(error1)
                            || e.ToString().Contains(error2)
                            || e.ToString().Contains(error3));

            
        }
        return dtReturn;
    }

    public static DataSet GetDataSet(SqlCommand paraCmd, out bool isDeadLock)
    {
        DataSet dtReturn = new DataSet();
        isDeadLock = false;
        try
        {
            paraCmd.CommandType = CommandType.StoredProcedure;
            paraCmd.CommandTimeout = 300;
            using (SqlDataAdapter Adp = new SqlDataAdapter(paraCmd))
            {
                Adp.Fill(dtReturn);
            }
        }
        catch (SqlException e)
        {
            string error1 = "was deadlocked on lock resources with another process and has been chosen as the deadlock victim.";
            string error2 = "A transport-level error has occurred when sending the request to the server.";
            string error3 = "An existing connection was forcibly closed by the remote host.";

            isDeadLock = (e.ToString().Contains(error1)
                            || e.ToString().Contains(error2)
                            || e.ToString().Contains(error3));

            
        }
        return dtReturn;
    }

    public static bool ExecuteStoreProcedure(SqlCommand paraCmd, out bool paraIsDeadLock)
    {
        bool ret = false;
        paraIsDeadLock = false;

        try
        {
            paraCmd.CommandType = CommandType.Text;
            paraCmd.CommandTimeout = 200;
            paraCmd.ExecuteNonQuery();
            ret = true;
        }
        catch (Exception e)
        {
            string error1 = "was deadlocked on lock resources with another process and has been chosen as the deadlock victim.";
            string error2 = "A transport-level error has occurred when sending the request to the server.";
            string error3 = "An existing connection was forcibly closed by the remote host.";

            paraIsDeadLock = (e.ToString().Contains(error1)
                            || e.ToString().Contains(error2)
                            || e.ToString().Contains(error3));

          
        }

        return ret;
    }

    public static bool ExecuteStoreProcedure(SqlCommand paraCmd)
    {
        bool ret = false;
        try
        {
            paraCmd.CommandType = CommandType.Text;
            paraCmd.CommandTimeout = 200;
            paraCmd.ExecuteNonQuery();
            ret = true;
        }
        catch (Exception e)
        {
            
        }

        return ret;
    }



    public static void AddInParameter(SqlCommand paraCmd, string paraName, SqlDbType paraSqlDbType, object paraValue)
    {
        try
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = paraName;
            parameter.Value = paraValue;
            parameter.SqlDbType = paraSqlDbType;
            parameter.Direction = ParameterDirection.Input;
            paraCmd.Parameters.Add(parameter);

        }
        catch (Exception ex)
        {
            
        }
    }

    public static SqlParameter AddOutParameter(SqlCommand paraCmd, string paraName, SqlDbType paraSqlDbType, int paraSize)
    {
        SqlParameter parameter = new SqlParameter();

        try
        {
            parameter.ParameterName = paraName;
            parameter.SqlDbType = paraSqlDbType;
            parameter.Size = paraSize;
            parameter.Direction = ParameterDirection.Output;
            paraCmd.Parameters.Add(parameter);

        }
        catch (Exception ex)
        {
            
        }
        
        return parameter;
    }

    public static SqlParameter AddOutParameter(SqlCommand paraCmd, string paraName, SqlDbType paraSqlDbType)
    {
        SqlParameter parameter = new SqlParameter();

        try
        {
            parameter.ParameterName = paraName;
            parameter.SqlDbType = paraSqlDbType;
            parameter.Direction = ParameterDirection.Output;
            paraCmd.Parameters.Add(parameter);

        }
        catch (Exception ex)
        {
            
        }
        
        return parameter;
    }

    //public static WebProxy NoProxy()
    //{
    //    WebProxy proxy = new WebProxy();
    //    if(Shared.DbValueToBoolean(ConfigurationManager.AppSettings["IsProxy"]))
    //    {
    //        proxy = new WebProxy("http://192.168.0.201:4480");
    //        proxy.Credentials = new NetworkCredential("khodan", "kdn942");
    //        WebRequest.DefaultWebProxy = proxy;
    //    }
    //    return proxy;
    //}

    public static DataTable ListToDataTable<T>(IList<T> varlist)
    {
        DataTable dt = new DataTable();

        //special handling for value types and string
        //In value type, the DataTable is expected to contain the values of all the variables (items) present in List.
        //Hence I create only one column in the DataTable named “Values”,
        //Though String is a reference type, due to its behavior 
        //I treat it as a special case and handle it as value type only.
        if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
        {
            DataColumn dc = new DataColumn("Values");

            dt.Columns.Add(dc);

            foreach (T item in varlist)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item;
                dt.Rows.Add(dr);
            }
        }
        //for reference types other than  string
        // Used PropertyInfo class of System.Reflection
        else
        {

            //find all the public properties of this Type using reflection
            PropertyInfo[] propT = typeof(T).GetProperties();

            foreach (PropertyInfo pi in propT)
            {
                //create a datacolumn for each property
                DataColumn dc = new DataColumn(pi.Name, pi.PropertyType);
                dt.Columns.Add(dc);
            }

            //now we iterate through all the items , take the corresponding values and add a new row in dt
            for (int item = 0; item < varlist.Count(); item++)
            {
                DataRow dr = dt.NewRow();

                for (int property = 0; property < propT.Length; property++)
                {
                    dr[property] = propT[property].GetValue(varlist[item], null);
                }

                dt.Rows.Add(dr);
            }
        }
        dt.AcceptChanges();
        return dt;
    }

    public static string ConvertTo12Hours(string input)
    {
        //string input = "22:45";
        if (input == "")
            return "00:00 AM";

        var timeFromInput = DateTime.ParseExact(input, "H:m", null, DateTimeStyles.None);

        string timeIn12HourFormatForDisplay = timeFromInput.ToString(
            "hh:mm tt",
            CultureInfo.InvariantCulture);
        return timeIn12HourFormatForDisplay;
        //var timeInTodayDate = DateTime.Today.Add(timeFromInput.TimeOfDay);

        //var timeInAnotherDate = new DateTime(2000, 1, 1).Add(timeFromInput.TimeOfDay);
    }

    public static List<T> DataTableToList<T>(DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }
        return data;
    }
    private static T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }
}
