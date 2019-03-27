using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vouchers
/// </summary>
public class Vouchers
{
	public Vouchers()
	{
		//
		// TODO: Add constructor logic here
		//
	}


}
public class VoucherCamp
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? DepartDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Int32 CouponTypeId { get; set; }
    public Int32 CouponFundingId { get; set; }
    public Int32 CouponCatId { get; set; }
    public Int32 CouponBrandId { get; set; }
    public String CampName { get; set; }
    public String Status { get; set; }
    public String InclProduct { get; set; }
    public String ExclProduct { get; set; }
    public Int16 Id { get; set; }
    public String Action { get; set; }
    public String Code { get; set; }
    public String BrandName { get; set; }
    public Decimal CouponValue { get; set; }
    public Decimal CouponValueId { get; set; }
    public String htmlEnglish { get; set; }
    public String htmlFrench { get; set; }
    public String URLEnglish { get; set; }
    public String URLFrench { get; set; }


}

public class Voucher
{
    public Int32 CouponTypeId { get; set; }
    public Int32 CouponFundingId { get; set; }
    public Int32 CouponCatId { get; set; }
    public Int32 CouponBrandId { get; set; }

    public DateTime? ExpiryDate { get; set; }
    public DateTime IssueDate { get; set; }
    public Int32 CampaignId { get; set; }
    public String CampaignName { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public Decimal VoucherAmount { get; set; }
    public String Status { get; set; }
    public String IncProduct { get; set; }
    public String ExclProduct { get; set; }
    public Int32 Id { get; set; }
    public String Action { get; set; }
    public String VoucherId { get; set; }

}



public class BDates
{

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public String Name { get; set; }
    public String Active { get; set; }
    public Int32 Id { get; set; }
    public String Action { get; set; }


}

public class GiftCertificate
{
    public Int32 CampaignBrandId { get; set; }
    public Int32 CouponTypeId { get; set; }
    public Int32 CouponCatId { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public DateTime IssueDate { get; set; }
    public Int32 CampaignId { get; set; }
    public String CampaignName { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public Decimal CertificateAmount { get; set; }
    public Decimal CertificateValue { get; set; }
    public String Status { get; set; }
    public String InclProduct { get; set; }
    public String ExclProduct { get; set; }
    public Int32 Id { get; set; }
    public String Action { get; set; }
    public String CertificateId { get; set; }

}

public class VOCampaign : GenerateCoupon
{


    public String Token { get; set; }
    public Int32 Campaign { get; set; }
    public String Languange { get; set; }
    public String FName { get; set; }
    public String LName { get; set; }
    public String Email { get; set; }
    public String TypeId { get; set; }
    public Int32 CategoryId { get; set; }
    public Int32 FundingId { get; set; }
    public Int32 BrandId { get; set; }
    public String incProduct { get; set; }
    public String ExclProduct { get; set; }
    public String Action { get; set; }
    public Decimal VoucherAmount { get; set; }
}


 public class NewVoucherData
 {
     public Int32 CategoryId { get; set; }
     public String TypeDesc { get; set; }
     public String CouponPrefix { get; set; }
     public Int32 FundingId { get; set; }
     public Int32 TypeId { get; set; }
     public Int32 BrandId { get; set; }
     public String incProduct { get; set; }
     public String ExclProduct { get; set; }
     public Decimal value { get; set; }
 }

 public class GenerateCoupon
 {
     public Int32 Id { get; set; }
     public String CampaignName { get; set; }
     public String Status { get; set; }
     public Int32 Distribution { get; set; }
     public Int32 Coupons { get; set; }
     public DateTime? Date { get; set; }
     public DateTime? Distributed { get; set; }
     public Int32 SelectedCamId { get; set; }
 }

public class GridDataArray
{
     public String FirstName { get; set; }
     public String LastName { get; set; }
     public String Email { get; set; }
}
public class VCGrid
{
    public Int64 Id { get; set; }
    public String VoucherId { get; set; }
    public String Campaign { get; set; }

    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Status { get; set; }
    public String Email { get; set; }
}

public class CouponGeneration 
{
    public Int32 Id { get; set; }
    public Int32 Generation_Id { get; set; }
    public Int32 Campaign_Id { get; set; }
    public String Email { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public Int32 Distribution { get; set; }
    public DateTime? Distributed { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Approved { get; set; }
    public Int32 Status { get; set; }
    public String VoucherId { get; set; }
    public String Action { get; set; }

}