using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBReportString
/// </summary>
public class DBReportString
{
	public DBReportString()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Report

    #region VC Report
    public static String GetVCReport = @"DECLARE @sql nvarchar(max);declare @list varchar(max);
set @list = ( select (coalesce(@SelectedCampaign+',','')))  

set @list = (select LEFT(@list,LEN(@list)-1))  
set @sql='WITH cte 
     AS ( SELECT [CampaignName],vc.id
      ,CT.Code as Type
      ,CF.GlCode as Funding
      ,CC.Category as category
      ,CB.BrandName as Brand
      ,CONVERT(VARCHAR(20), [StartDate] , 20) as 	StartDate
      ,CONVERT(VARCHAR(20), [EndDate], 20) as EndDate
		,CAST( CV.Value AS dECIMAL(18,2)) as BookingValue 
,CAST( CV.Value AS dECIMAL(18,2))  as DollarValue 
		,CONVERT(VARCHAR(20),  VM.UseDate , 20) as UseDate,

		VM.UseRezId As BookingNumber,
		Used = Count(case when isdate(VM.UseDate)=1 and VM.UseDate<>''1900-01-01 00:00:00'' and vM.status<>''INVALID''   then 1 end)
                           OVER( 
                             partition BY VM.CampaignId), 
								rn = Row_number() 
								OVER( 
								partition BY VM.CampaignId order by VM.updated asc) ,
TotalBookingValue = Sum(case when isdate(VM.UseDate)=1 and VM.UseDate<>''1900-01-01 00:00:00'' and vM.status<>''INVALID''  then isnull(VM.UseSaleAmount,0) end)
Over (partition By VM.CampaignId),



             Issued =     Count(VM.ID) 
                           OVER( 
                             partition BY VM.CampaignId), 
                rn1 = Row_number() 
                       OVER( 
                         partition BY VM.CampaignId order by VM.updated asc 
                         ) 
         FROM [dbo].[VoucherCampaign] VC
				inner join VoucherMaster VM on VM.CampaignId = VC.Id 
                left join CouponTypes CT on CT.Id = VC.TypeId
                left join CouponFunding CF on CF.Id = VC.FundingId
                left join CouponCategory CC on CC.Id = VC.CategoryId
                left join CouponBrand CB on CB.Id = VC.BrandId
				left join CouponValue CV on CV.Id = VC.Value where vc.status <>-1 and vc.status<>0  and  vM.status<>''INVALID'' ) 
			SELECT [CampaignName], 
					  Type, 
					   Funding, 
					   Category, 
					   Brand,
					   StartDate as 	DateofIssue ,
					   EndDate as  DateofExpiry,
					   	DollarValue as DollarValue,
					   Issued as  TotalVoucherIssued,
					   CAST( isnull(Used,1) AS int)  as TotalVoucherUsed,
					   CAST( isnull(TotalBookingValue,1) AS dECIMAL(18,2))  as TotalBookingValue,
					    CAST( cast ((TotalBookingValue/nullif(Used,0)) as money) AS dECIMAL(18,2))   as AverageBookingValue,
	 isnull(UseDate,convert(smalldatetime,UseDate,101/102/103) ) as DateOfUse,
	isnull(BookingNumber,'''') As BookingNumber,
	  CAST(  cast (isnull(BookingValue,0) as money) AS dECIMAL(18,2)) as BookingValue

FROM   cte 

WHERE  rn = 1 and rn1=1 and 
1 = CASE WHEN  CONVERT(VARCHAR(20),'+@list+')  like  ''0''  then 1                    
   WHEN Id in ('+@list+')  THEN 1 END
'


Execute sp_executesql @sql  
";
    #endregion

    #region VI Report

    public static String GetVIReportData = @"
set @StartDate = case when @StartDate='0' then '1990-01-01' else @StartDate end
set @EndDate = case when @EndDate='0' then getdate()+1 else @EndDate end
DECLARE @sql nvarchar(max);declare @list varchar(max);
set @list = ( select (coalesce(@VoucherCategory+',','')))  

set @list = (select LEFT(@list,LEN(@list)-1)) 

set @sql='select VoucherId as VoucherNumber,
FirstName as CustomerFirstName,
LastName as CustomerLastName,
CONVERT(VARCHAR(20), [IssueDate] , 20) as DateOfIssue,
CONVERT(VARCHAR(20), [ExpiryDate] , 20) as DateOfExpiry,
CAST(voucherAmount AS dECIMAL(18,2)) as DollarValueIssue,
CONVERT(VARCHAR(20), [UseDate] , 20) as DateofUse,

UseRezId as BookingNumber,
CAST(UseSaleAmount AS dECIMAL(18,2)) as BookingValue
from VoucherMaster where Status <> ''INVALID'' and

1 = CASE WHEN  CONVERT(VARCHAR(20),'+@list+')  like  ''0''  then 1                   
   WHEN categoryId in ('+@list+')  THEN 1 END and
IssueDate between  '''+ CONVERT(VARCHAR(20),Cast(@StartDate as Date))+'''  and '''+CONVERT(VARCHAR(20),Cast(@EndDate as Date)) +'''and  status <>''INVALID'''
Execute sp_executesql @sql";

    #endregion

    #region Vo Report

    public static String GetVOReportData = @"set @ReportDate = case when @ReportDate='0' then getdate()+1 else @ReportDate end
DECLARE @sql nvarchar(max);declare @list varchar(max);
set @list = ( select (coalesce(@VoucherCategory+',','')))  

set @list = (select LEFT(@list,LEN(@list)-1)) 

set @sql='WITH cte 
		AS (select VoucherId as VoucherNumber,
		FirstName as CustomerFirstName,
		LastName as CustomerLastName,
CONVERT(VARCHAR(20), [IssueDate] , 20) as DateOfIssue,
CONVERT(VARCHAR(20), [ExpiryDate] , 20) as DateOfExpiry,
		CategoryId,
		--voucherAmount as DollarValueIssued,
		IssueDate,
		DollarValueIssued = Sum(isnull(VoucherAmount,0))
		OVER( 
		partition BY CategoryId), 
		rn = Row_number() 
		OVER( 
		partition BY CategoryId order by vm.updated asc) ,
		TotalSaleAmount =Sum(isnull(UseSaleAmount,0))
		OVER( 
		partition BY CategoryId)
								
		from vouchermaster vm inner join couponcategory CT on Ct.id =vm.CategoryId  where categoryid is not null and ct.Status!=-1 and  vm.status <>''INVALID'' and vm.status <>''0'' and
IssueDate <=  '''+ CONVERT(VARCHAR(20),Cast(@ReportDate as Date))+''' )  
		select VoucherNumber,CustomerfirstName,CustomerLastName,DateofIssue,DateofExpiry
		,CAST(DollarValueIssued AS dECIMAL(18,2)) AS DollarValueIssued
		,CAST((DollarValueIssued-TotalSaleAmount) AS dECIMAL(18,2))  as DollarValueOutstanding,CategoryId
		from cte where rn = 1 and
1 = CASE WHEN  CONVERT(VARCHAR(20),'+@list+')  like  ''0''  then 1                    
   WHEN categoryId in ('+@list+')  THEN 1 END '
Execute sp_executesql @sql
";

    #endregion

    #region VR Report

    public static String GetVRReportData = @"
set @StartDate = case when @StartDate='0' then '1990-01-01' else @StartDate end
set @EndDate = case when @EndDate='0' then getdate()+1 else @EndDate end
DECLARE @sql nvarchar(max);declare @list varchar(max);
set @list = ( select (coalesce(@VoucherType+',','')))  

set @list = (select LEFT(@list,LEN(@list)-1)) 

set @sql='select VoucherId as VoucherNumber,
FirstName as CustomerFirstName,
LastName as CustomerLastName,
CONVERT(VARCHAR(20), [IssueDate] , 20) as DateOfIssue,
CONVERT(VARCHAR(20), [ExpiryDate] , 20) as DateOfExpiry,
CAST(voucherAmount AS dECIMAL(18,2))  as DollarValueIssue,
CONVERT(VARCHAR(20), [UseDate] , 20) as DateofUse,

UseRezId as BookingNumber,
CAST(UseSaleAmount AS dECIMAL(18,2))  as BookingValue
from VoucherMaster where 

1 = CASE WHEN  CONVERT(VARCHAR(20),'+@list+')  like  ''0''  then 1                  
   WHEN TypeId in ('+@list+')  THEN 1 END and
UseDate between  '''+ CONVERT(VARCHAR(20),Cast(@StartDate as Date))+'''  and '''+CONVERT(VARCHAR(20),Cast(@EndDate as Date)) +''' and status <>''INVALID'' and status <>''0'''
Execute sp_executesql @sql";

    #endregion

    #region GCS Report

    public static String GetGCSReportData = @"
set @StartDate = case when @StartDate='0' then '1990-01-01' else @StartDate end
set @EndDate = case when @EndDate='0' then getdate()+1 else @EndDate end
DECLARE @sql nvarchar(max);declare @list varchar(max);

set @sql='select certificateId as GCNumber,
FirstName as CustomerFirstName,
LastName as CustomerLastName,
CONVERT(VARCHAR(20), [IssueDate] , 20) as DateOfIssue,
CONVERT(VARCHAR(20), [ExpiryDate] , 20) as DateOfExpiry,
CAST(CertificateAmount AS dECIMAL(18,2))   as DollarValueIssue,
CAST(CertificateValue AS dECIMAL(18,2))   as DollarValueRemaining
from CertificateMaster where 

IssueDate between  '''+ CONVERT(VARCHAR(20),Cast(@StartDate as Date))+'''  and '''+CONVERT(VARCHAR(20),Cast(@EndDate as Date)) +''' and status <>''INVALID'''
Execute sp_executesql @sql";

    #endregion

    #region GCO Report

    public static String GetGCORReportData = @"
set @ReportDate = case when @ReportDate='0' then getdate()+1 else @ReportDate end

DECLARE @sql nvarchar(max);declare @list varchar(max);

set @sql='select certificateId as GCNumber,
FirstName as CustomerFirstName,
LastName as CustomerLastName,
CONVERT(VARCHAR(20), [IssueDate] , 20) as DateOfIssue,
CONVERT(VARCHAR(20), [ExpiryDate] , 20) as DateOfExpiry,
CAST(CertificateAmount AS dECIMAL(18,2))   as DollarValueIssue,
CAST(CertificateValue AS dECIMAL(18,2))   as DollarValueOutStanding
from CertificateMaster where 

IssueDate <= '''+ CONVERT(VARCHAR(20),Cast(@ReportDate as Date))+''' and status <>''INVALID'''
Execute sp_executesql @sql";


    #endregion


    
            #region CGR Report

    public static String GetGCRReportData = @"
set @StartDate = case when @StartDate='0' then '1990-01-01' else @StartDate end
set @EndDate = case when @EndDate='0' then getdate()+1 else @EndDate end
DECLARE @sql nvarchar(max);declare @list varchar(max);

set @sql='select CertificateId as GCNumber,
FirstName as CustomerFirstName,
LastName as CustomerLastName,
CONVERT(VARCHAR(20), [IssueDate] , 20) as DateOfIssue,
CONVERT(VARCHAR(20), [ExpiryDate] , 20) as DateOfExpiry,

CAST(CertificateAmount AS dECIMAL(18,2))  as DollarValueIssue,
CONVERT(VARCHAR(20), [UseDate] , 20) as DateofUse,
UseRezId as BookingNumber,
CAST(CertificateAmount - CertificateValue AS dECIMAL(18,2))   as BookingValue
from CertificateMaster where 

UseDate between  '''+ CONVERT(VARCHAR(20),Cast(@StartDate as Date))+'''  and '''+CONVERT(VARCHAR(20),Cast(@EndDate as Date)) +'''  and (CertificateAmount - CertificateValue )>0 and status <>''INVALID'''
Execute sp_executesql @sql";

    #endregion

    #endregion
}