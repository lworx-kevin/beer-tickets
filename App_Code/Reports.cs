using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reports
/// </summary>
public class Reports
{
	public Reports()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   public class VCReport
   {
       public String CampaignName { get; set; }
       public String Type { get; set; }
       public String Funding { get; set; }
       public String Category { get; set; }
       public String Brand { get; set; }
       public String DateofIssue { get; set; }
       public String DateofExpiry { get; set; }
       public String DollarValue { get; set; }
       public String TotalVoucherIssued { get; set; }
       public String TotalVoucherUsed { get; set; }
       public String TotalBookingValue { get; set; }
       public String AverageBookingValue { get; set; }
       public String DateOfUse { get; set; }
       public String BookingNumber { get; set; }
       public String BookingValue { get; set; }
   }

   public class VIParams
   {
       public String StartDate { get; set; }
       public String EndDate { get; set; }
       public String VoucherCategory { get; set; }
   }


   public class VOParams
   {
       public String ReportDate { get; set; }
       public String VoucherCategory { get; set; }
   }

    

   public class VRParams
   {
       public String StartDate { get; set; }
       public String EndDate { get; set; }
       public String VoucherType { get; set; }
   }
    
   public class VOReport
   {
       public String VoucherNumber { get; set; }
       public String CustomerLastName { get; set; }
       public String CustomerFirstName { get; set; }
       public String DateOfIssue { get; set; }
       public String DateOfExpiry { get; set; }
       public String DollarValueIssued { get; set; }
       public String DollarValueOutstanding { get; set; }
   }



   public class VIReport
   {
        public String VoucherNumber { get; set; }
        public String  CustomerLastName { get; set; }
        public String CustomerFirstName { get; set; }
        public String DateOfIssue { get; set; }
        public String DateOfExpiry { get; set; }
        public String DateofUse { get; set; }
        public String DollarValueIssue { get; set; }
        public String BookingNumber { get; set; }
        public String BookingValue { get; set; }
   }


   public class GCSParams
   {
       public String StartDate { get; set; }
       public String EndDate { get; set; }
   }

   public class GCSReport
   {
       public String GCNumber { get; set; }
       public String CustomerLastName { get; set; }
       public String CustomerFirstName { get; set; }
       public String DateOfIssue { get; set; }
       public String DateOfExpiry { get; set; }
       public String DollarValueIssue { get; set; }
       public String DollarValueRemaining { get; set; }
   }


   public class GCRReport
   {
        public String GCNumber { get; set; }
        public String  CustomerLastName { get; set; }
        public String CustomerFirstName { get; set; }
        public String DateOfIssue { get; set; }
        public String DateOfExpiry { get; set; }
        public String DateofUse { get; set; }
        public String DollarValueIssue { get; set; }
        public String BookingNumber { get; set; }
        public String BookingValue { get; set; }
   }

   public class GCOParams
   {
       public String ReportDate { get; set; }
   }

   public class GCOReport
   {
       public String GCNumber { get; set; }
       public String CustomerLastName { get; set; }
       public String CustomerFirstName { get; set; }
       public String DateOfIssue { get; set; }
       public String DateOfExpiry { get; set; }
       public String DollarValueIssue { get; set; }
       public String DollarValueOutstanding { get; set; }
   }

}