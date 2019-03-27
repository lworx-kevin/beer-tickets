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
using Dapper;
using System.Configuration;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for DReportDataTable
/// </summary>
public class DReportDataTable
{

    static IDbConnection db;

	public DReportDataTable()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region REports

    #region VC Report
    public static string GetVCReport(String SelectedCampaign)
    {
        Initialize();
        String GetVCReport = DBReportString.GetVCReport;
        var data = (List<Reports.VCReport>)db.Query<Reports.VCReport>(GetVCReport, new { SelectedCampaign = SelectedCampaign });
        return getJSON(data);
    }
    #endregion

    #region VI Report
    public static string GetVIReportData(Reports.VIParams ObjParams)
    {
        Initialize();
        String GetVIReportData = DBReportString.GetVIReportData;
        var data = (List<Reports.VIReport>)db.Query<Reports.VIReport>(GetVIReportData, new { StartDate = ObjParams.StartDate, EndDate = ObjParams.EndDate, VoucherCategory = ObjParams.VoucherCategory });
        return getJSON(data);
    }
    #endregion

    #region VO Report
    public static string GetVOReportData(Reports.VOParams ObjParams)
    {
        Initialize();
        String GetVOReportData = DBReportString.GetVOReportData;
         var data = (List<Reports.VOReport>)db.Query<Reports.VOReport>(GetVOReportData, new { ReportDate = ObjParams.ReportDate, VoucherCategory = ObjParams.VoucherCategory });
        return getJSON(data);
    }
    #endregion

    #region VR Report
    public static string GetVRReportData(Reports.VRParams ObjParams)
    {
        Initialize();
        String GetVRReportData = DBReportString.GetVRReportData;
        var data = (List<Reports.VIReport>)db.Query<Reports.VIReport>(GetVRReportData, new { StartDate = ObjParams.StartDate, EndDate = ObjParams.EndDate, VoucherType = ObjParams.VoucherType });
        return getJSON(data);
    }


    #endregion

    #region GCS Report
    public static string GetGCSReportData(Reports.GCSParams ObjParams)
    {
        Initialize();
        String GetGCSReportData = DBReportString.GetGCSReportData;
        var data = (List<Reports.GCSReport>)db.Query<Reports.GCSReport>(GetGCSReportData, new { StartDate = ObjParams.StartDate, EndDate = ObjParams.EndDate });
        return getJSON(data);
    }
    #endregion

    #region GCO Report
    public static string GetGCORReportData(Reports.GCOParams ObjParams)
    {
        Initialize();
        String GetGCORReportData = DBReportString.GetGCORReportData;
        var data = (List<Reports.GCOReport>)db.Query<Reports.GCOReport>(GetGCORReportData, new { ReportDate = ObjParams.ReportDate});
        return getJSON(data);
    }

    
    #endregion

    #region GCR Report
    public static string GetGCRReportData(Reports.GCSParams ObjParams)
    {
        Initialize();
        String GetGCRReportData = DBReportString.GetGCRReportData;
        var data = (List<Reports.GCRReport>)db.Query<Reports.GCRReport>(GetGCRReportData, new { StartDate = ObjParams.StartDate, EndDate = ObjParams.EndDate });
        return getJSON(data);
    }


    #endregion

    #endregion

    #region Global Method
    public static void Initialize()
    {
        db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    }

    public static string getJSON(dynamic Data)
    {
        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(Data);
        return JSONString;
    }
    #endregion
}