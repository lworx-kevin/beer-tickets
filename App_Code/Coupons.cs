using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Coupons
/// </summary>
public class Coupons
{
	public Coupons()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public class CouponType
    {

        #region Properties
        public String Code { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public Int16 Id { get; set; }
        public String Action { get; set; }
        #endregion
    }


    public class CouponValue
    {

        #region Properties
        public String Label { get; set; }
        public String Value { get; set; }
        public String Status { get; set; }
        public Int16 Id { get; set; }
        public String Action { get; set; }
        #endregion
    }

    public class CouponFunding
    {
        public String GlCode { get; set; }
        public String Department { get; set; }
        public String Status { get; set; }
        public Int16 Id { get; set; }
        public String Action { get; set; }

    }

    public class CouponCategory
    {
        public String Category { get; set; }
        public String Description { get; set; }
        public String CouponPrefix { get; set; }
        public String Status { get; set; }
        public String PayC { get; set; }
        public Int16 Id { get; set; }
        public String Action { get; set; }
    }
    public class CouponProduct
    {
        public String ProductName { get; set; }
        public String ProductCode { get; set; }
        public String ProductType { get; set; }
        public String Status { get; set; }
        public Int16 Id { get; set; }
        public String Action { get; set; }

    }

    public class CouponBrand
    {
        public String BrandName { get; set; }
        public String BrandImage { get; set; }
        public String Status { get; set; }

        public Int16 Id { get; set; }
        public String Action { get; set; }

       
    }

    public class CouponProductType
    {
        public Int32 Id { get; set; }
        public String Action { get; set; }
	public String ProductCode { get; set; }
	public String ProductType{ get; set; }
	public String dbUser { get; set; }
	public String dbPwd{ get; set; }
	public String dbName { get; set; }
	public String dbTable { get; set; }
	public String dbProductCode { get; set; }
	public String dbProductName { get; set; }
	public String dbCountryCode { get; set; }
    public String dbStatusCode { get; set; }
    public String dbStatusValue{ get; set; }
    public String Status { get; set; }
	public DateTime DateCreated { get; set; }
	public String dbHotelName { get; set; }
	public String dbHotelChain { get; set; }
	public String dbFlightNumber { get; set; }
	public String dbAirlineName { get; set; }
	public String dbAirportCode { get; set; }
    }

}