using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBStrings
/// </summary>
public class DBStrings
{
	public DBStrings()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region Vouchers

    public static string EditVoucherData = @"UPDATE [dbo].[VoucherMaster]
   SET[FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[VoucherAmount] = @VoucherAmount
      ,[incProduct] = @incProduct
      ,[exclProduct] = @exclProduct
      ,[Expirydate] = @Expirydate
      ,[Status] = @Status
      ,[Updated] = getdate()
      ,[TypeId] = @TypeId
      ,[FundingId] = @FundingId
      ,[CategoryId] = @CategoryId
      ,[BrandId] = @BrandId
      ,[FullName] = @FirstName + ' ' + @LastName
 WHERE  Id = @Id";

    public static String ValidateVoucherData = @"UPDATE [dbo].[VoucherMaster]
				   SET 
					  [Status] = @Status,Updated = getdate()  where Id = @Id
                        Select 'Success' as Status,'1' as Success";

    public static string insertVoucherData = @"INSERT INTO [dbo].[VoucherMaster]
        (				                                    [TypeId]  ,
				                                    [FundingId]  ,
				                                    [CategoryId]  ,
				                                    [BrandId]  ,
        [CampaignId],
        [VoucherId]
        ,[FirstName]
        ,[LastName]
        ,[VoucherAmount]
        ,[incProduct]
        ,[exclProduct]
        ,[IssueDate]
        ,[Expirydate]
        ,[Status]
        ,[Created],VoucherValue, FullName)
        VALUES
        (@TypeId
	    ,@FundingId
	    ,@CategoryId
	    ,@BrandId
        ,@CampaignId
        ,@NewVoucherCode
        ,@FirstName
        ,@LastName
        ,@VoucherAmount
        ,@IncProduct
        ,@ExclProduct
        ,getdate()
        ,@Expirydate
        ,@Status
        ,getdate(),@VoucherAmount,@FirstName + ' ' +@LastName )";

    public static String GetVoucherCode = "Select 1 from voucherTable where VoucherCode =@NewVoucherCode";

    public static String GetVoucherGrid = @"
if exists(select 1 from vouchermaster where expirydate<getdate()-1 and status<>'INVALID')
begin
update vouchermaster set status ='Expired' where expirydate<getdate()-1 and status<>'INVALID'
end
Select VM.id as Id,VoucherId,FirstName,LastName,Email
,VM.Status,Vm.voucherAmount  from VoucherMaster VM where VM.Status <> 'INVALID'   order by id asc
";
     public static string GetVoucherCodeById = @"select [TypeId] as CouponTypeId  ,
                    CampaignId,
				[FundingId] as CouponFundingId,
				[CategoryId] as CouponCatId ,
				[BrandId] as CouponBrandId , Id,VoucherId,FirstName,LastName,VoucherAmount,incProduct,exclProduct,CONVERT(VARCHAR(8), IssueDate, 1) as IssueDate,CONVERT(VARCHAR(8), ExpiryDate, 1) as ExpiryDate ,CONVERT(VARCHAR(8), UseDate, 1) as UseDate,UseProduct,UseRezId,UseSaleAmount,UseTaxesIncluded,Status 
	from VoucherMaster where Id = @VoucherId";
    public static string DeleteVoucher = @"update VoucherMaster set Status = 'INVALID' where id = @VoucherId";

    public static String GetVoucherCampaignData = "SELECT Id,CampaignName from VoucherCampaign where status=1  order by id desc";


    public static String InsertVoucher = @"if not EXISTS(SELECT 1
                                        FROM VoucherTable
                                        WHERE VoucherCode = @NewVoucherCode)
                                        begin
                                        INSERT INTO VoucherTable (VoucherCode) VALUES (@NewVoucherCode)
                                 Select 'Success'
                                        end
                                        else
                                        begin
                                        Select 'Repeat'
                                        end";
    public static String GetCouponValueData = "SELECT Id,Value from CouponValue where status!=-1  order by id desc";

    

    #endregion

    #region Coupon Generation

    public static String EditGenerateCouponData = @"update CouponGeneration set FirstName = @FirstName,LastName=@LastName,Email  = @Email where Id = @Id";
    public static String GetVCouponsListing = @"SELECT [Id]
      ,[Email]
      ,[FirstName]
      ,[LastName]
      ,[Status]
      ,[Distribution]
  FROM [dbo].[CouponGeneration] where generation_id = @Id and Status!=-1";
    public static String DeleteCouponById = @"update CouponGeneration set Status = -1 where Id = @Id";

    public static String GetCouponById = @"SELECT [Id]
      ,[Email]
      ,[FirstName]
      ,[LastName]
  FROM [dbo].[CouponGeneration] where Id = @Id";
    
    #endregion


    #region Vouchers With campaign

    public static String SendVoucherWithCampaignbyId = @"update CouponGeneration  set Status = 1 where Generation_id = @GenerationId
                                                        update VoucherGeneration set [Distributed] = getdate() where Id = @GenerationId";

    public static String insertCouponGnerationData = @"INSERT INTO [dbo].[CouponGeneration]
           ([Generation_Id]
           ,[Campaign_Id]
           ,[Email]
           ,[FirstName]
           ,[LastName]
           ,[Status]
           ,distribution
           ,[Created]
         
           ,[VoucherId])
     VALUES
           (@Generation_Id
           ,@Campaign_Id
           ,@Email
           ,@FirstName
           ,@LastName
           ,@Status
           ,@distribution
           ,getdate()
          
           ,null)";

    public static String ValidateVoucherGen = @"Update VoucherGeneration set Status = 1 where Id = @Id";


    public static string GetCategoryPrefix = "select CC.CouponPrefix from CouponCategory CC inner join VoucherCampaign VC on VC.CategoryId = CC.Id where VC.Id = @CampaignId";




    public static String ReturnTypeandCat = @"
              select VT.Code as  TypeDesc,CategoryId,VC.TypeId,CC.CouponPrefix,FundingId,BrandId,incProduct,ExclProduct,cv.value from vouchercampaign VC
inner join CouponTypes VT on VT.Id = VC.TypeId 
inner join CouponCategory CC on VC.CategoryId = CC.Id Inner join CouponValue cv on cv.Id = vc.value where VC.Id = @CampaignId";

    public static string InsertVoucherWithCampaign = @"INSERT INTO [dbo].[VoucherMaster]
        (				                                    [TypeId]  ,
				                                    [FundingId]  ,
				                                    [CategoryId]  ,
				                                    [BrandId]  ,
       [CampaignId],
        [VoucherId]
        ,[FirstName]
        ,[LastName]
        ,[VoucherAmount]
        ,[incProduct]
        ,[exclProduct]
        ,[IssueDate]
      
        ,[Status]
        ,[Created],VoucherValue,Email,GenerationId)
        VALUES
        (@TypeId
	    ,@FundingId
	    ,@CategoryId
	    ,@BrandId
        ,@CampaignId
        ,@NewVoucherCode
        ,@FirstName
        ,@LastName
        ,@VoucherAmount
        ,@IncProduct
        ,@ExclProduct
        ,getdate()
       
        ,@Status
        ,getdate(),@VoucherAmount,@Email,@GenerationId)";

    public static string insertVoucherGenerationData = @"INSERT INTO [dbo].[VoucherGeneration]
           ([CampaignId]
           ,[Distribution]
           ,[Coupons]
           ,[Status]
           ,[Created]
           )
     VALUES
           (@CampaignId,
           @Distribution,
           @Coupons,
           @Status, 
           getdate()
           ) select Scope_identity()";






    public static String GetVoucherGenerationdata = @"SELECT VG.[Id]
      ,Vc.[CampaignName] as CampaignName
      ,VG.[Distribution]
      ,VG.[Coupons],VG.[Distributed]
      ,case when VG.[Status] = 0 Then 'PENDING' When VG.[Status] = 1 Then 'APPROVED' End as Status
      ,VG.[Created] as Date
      
  FROM [dbo].[VoucherGeneration] VG inner join VoucherCampaign VC on VC.Id = VG.CampaignId where VG.Status!=-1";

    public static String GetVoucherGenerationdataById = @"select CampaignId as CampaignName,Distribution,Case when status = 0 then 'PENDING' 
When  status =1 then 'APPROVED'
when status = -1 then 'CANCELLED' end as Status  from vouchergeneration where Id = @Id";

    public static String GetVouchersWithCampaign = @"Select VM.id as Id,VoucherId,FirstName,LastName,VoucherAmount
,VM.Status from VoucherMaster VM  where VM.Status <> 'CANCELLED' and VM.VoucherId is not null  order by id desc";
    public static string GetVoucherWithCampaignById = @"select [TypeId] as CouponTypeId  ,
				[FundingId] as CouponFundingId,
				[CategoryId] as CouponCatId ,
				[BrandId] as CouponBrandId , Id,VoucherId,CampaignId as campaign,FirstName,LastName,VoucherAmount,incProduct,
exclProduct,CONVERT(VARCHAR(8), IssueDate, 1) as IssueDate,CONVERT(VARCHAR(8), ExpiryDate, 1) as ExpiryDate ,CONVERT(VARCHAR(8), UseDate, 1) as UseDate,UseProduct,UseRezId,UseSaleAmount,UseTaxesIncluded,Status 
	from VoucherMaster where Id = @VoucherId";
    public static string DeleteVoucherWithCampaignbyId = @"update CouponGeneration  set Status = -1 where Generation_id = @GenerationId
update VoucherGeneration set Status = -1 where Id = @GenerationId";







    #endregion

    #region Coupon Types
    public static String InsertCouponType = @"if not exists(select 1 from Coupontypes where Code=@Code and status!=-1)
					                            begin
						                            INSERT INTO [dbo].[CouponTypes]
							                            ([Code]
							                            ,[Description]
							                            ,[Status]
							                            ,[Created])
						                            VALUES
							                            (@Code
							                            ,@Description
							                            ,@Status
							                            ,GETDATE())
							                            Select 'Success' as Status,'1' as Success
					                            end
				                            else
					                            begin
					                            Select 'Exist' as Status,'2' as Success
					                            end";

    public static String GetCouponType = "Select Code,Description,Id,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponTypes where Status!=-1  order by id desc";
   
    public static String GetCouponTypeById = "select Code,Description,Status from  CouponTypes  where Id = @TypeId";
   
    public static String DeleteCouponTypeById =	"Update CouponTypes set Status = -1 where Id = @TypeId";
   
    public static String EditCouponType = @"Update CouponTypes set Code = @Code,Description=@Description,Status = 0 where Id = @Id
					                            Select 'Success' as Status,'1' as Success";
    public static String ValidateCouponType = @"Update CouponTypes set Status = @Status where Id = @Id
					                            Select 'Success' as Status,'1' as Success";
 
    #endregion

    #region Coupon Funding
    public static String GetCouponFundingData = "Select Id,GlCode,Department,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponFunding where status!=-1  order by id desc";

    public static String GetCouponFundingDataById = "Select Id,GlCode,Department,Status from CouponFunding where Id = @FundId  order by id desc";

    public static String DeleteCouponFundingDataById = @"update CouponFunding set Status = -1 where  Id = @FundId
	                        select 'Success' as Status,1 as Success";

    public static String InsertCouponFundingData = @"INSERT INTO [dbo].[CouponFunding]
							([GlCode]
							,[Department]
							,[Status]
							,[Created])
						VALUES
							(@GlCode
							,@Department
							,@Status
							,GETDATE())
							Select 'Success' as Status,'1' as Success";

    public static String EditCouponFundingData = @"Update CouponFunding set GlCode = @GlCode,Department=@Department,Status=0 where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String ValidateCouponFundingData = @"Update CouponFunding set Status = @Status where Id = @Id
						Select 'Success' as Status,'1' as Success";

    #endregion

    #region Coupon Category
    public static String GetAllCouponCategories = "Select Category,CouponPrefix,Id,Description,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponCategory where Status!=-1 order by id desc";

    public static String GetCouponCategoryById = "Select Category,CouponPrefix,Status,Description,PayCommission as PayC from  CouponCategory  where Id = @CatId";

    public static String EditCouponCategory = @"Update CouponCategory set PayCommission = @PayC, Category = @Category,CouponPrefix=@CouponPrefix,Description = @Description,Status = 0 where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String ValidateCouponCategory = @"Update CouponCategory set Status = @Status where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String InsertCouponCategory = @"if not exists(select 1 from CouponCategory where Category=@Category and Status!=-1)
					begin
                        INSERT INTO [dbo].[CouponCategory]
                        ([Category]
                        ,[CouponPrefix],
                        [Description]
                        ,[Status]
                        ,[Created],
PayCommission
                        )
                        VALUES
                        (@Category
                        ,@CouponPrefix,
                        @Description
                        ,@Status
                        ,GETDATE(),@PayC)
                        Select 'Success' as Status,'1' as Success
                    end
				    else
					begin
					    Select 'Exist' as Status,'2' as Success
					end";

    public static String DeleteCouponCategoryById = @"Update CouponCategory set Status = -1 where Id = @CatId
	                                                Select 'Success' as Status,'1' as Success";

    #endregion

    #region Coupon product
    public static String GetAllProducts = @"Select CP.ProductName,CP.ProductCode,CP.Id,CPT.ProductCode as ProductType, Case when CP.Status =0 then 'Pending' else case when CP.status = 1 then 'Approved' end end as Status  
from CouponProduct CP
left join CouponProductType CPT on CPT.Id = CP.ProductTypeId
where CP.Status!=-1  order by id desc";

    public static String GetCouponProductById = "select ProductName,ProductCode,Status,ProductTypeId as ProductType from  CouponProduct  where Id = @ProductId";

    public static String InsertCouponProduct = @"if not exists(select 1 from CouponProduct where ProductName = @ProductName and ProductCode=@ProductCode and Status!=-1)
					                        begin
						                        INSERT INTO [dbo].[CouponProduct]
						                        ([ProductName],
						                        [ProductCode],
                                                ProductTypeId
						                        ,[Status]
						                        ,[Created]
						                        )
						                        VALUES
						                        (@ProductName,
						                        @ProductCode,
                                                @ProductType,
						                        @Status
						                        ,GETDATE())
						                        Select 'Success' as Status,'1' as Success
					                        end
				                        else
					                        begin
					                        Select 'Exist' as Status,'2' as Success
					                        end";

    public static String ValidateCouponProduct = @"Update CouponProduct set Status = @Status where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String EditCouponProduct = @"Update CouponProduct set ProductName = @ProductName,Status = 0,ProductCode = @ProductCode,ProductTypeId = @ProductType where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String DeleteCouponProductDataById = @"Update CouponProduct set Status = -1 where Id = @ProductId
	                                                    Select 'Success' as Status,'1' as Success";

    #endregion

    #region Coupon product Type
    public static String GetAllProductType = @"Select Id,[ProductCode]
           ,[ProductType]
           ,[dbUser]
           ,[dbPwd]
           ,[dbName]
           ,[dbTable]
           ,[dbProductCode]
           ,[dbProductName]
           ,[dbCountryCode]
           ,[dbStatusCode]
           ,[Status]
           ,[DateCreated]
           ,[dbHotelName]
           ,[dbHotelChain]
           ,[dbFlightNumber]
           ,[dbAirlineName]
           ,[dbAirportCode],[dbStatusCode],Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponProductType where Status!=-1  order by id desc";

    public static String GetCouponProductTypeById = @"select Id,[ProductCode]
           ,[ProductType]
           ,[dbUser]
           ,[dbPwd]
           ,[dbName]
           ,[dbTable]
           ,[dbProductCode]
           ,[dbProductName]
           ,[dbCountryCode]
           ,[dbStatusCode]  ,[dbStatusValue]
           ,[Status]
           ,[DateCreated]
           ,[dbHotelName]
           ,[dbHotelChain]
           ,[dbFlightNumber]
           ,[dbAirlineName]
           ,[dbAirportCode] from  CouponProductType  where Id = @ProductId";

    public static String InsertCouponProductType = @"if not exists(select 1 from CouponProductType where ProductCode = @ProductCode and Status!=-1)
					                        begin
						                       INSERT INTO [dbo].[CouponProductType]
           ([ProductCode]
           ,[ProductType]
           ,[dbUser]
           ,[dbPwd]
           ,[dbName]
           ,[dbTable]
           ,[dbProductCode]
           ,[dbProductName]
           ,[dbCountryCode]
           ,[dbStatusCode],[dbStatusValue]
           ,[Status]
           ,[DateCreated]
           ,[dbHotelName]
           ,[dbHotelChain]
           ,[dbFlightNumber]
           ,[dbAirlineName]
           ,[dbAirportCode])
     VALUES
           (@ProductCode,
           @ProductType,
           @dbUser,
           @dbPwd,
           @dbName,
           @dbTable,
           @dbProductCode,
           @dbProductName,
           @dbCountryCode,
           @dbStatusCode,@dbStatusValue,
           @Status,
           getdate(),
           @dbHotelName,
           @dbHotelChain,
           @dbFlightNumber,
           @dbAirlineName,
           @dbAirportCode)
			Select 'Success' as Status,'1' as Success
		end
	else
		begin
		Select 'Exist' as Status,'2' as Success
		end";

    public static String ValidateCouponProductType = @"Update CouponProductType set Status = @Status where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String EditCouponProductType = @"UPDATE [dbo].[CouponProductType]
   SET [ProductCode] = @ProductCode,
      [ProductType] = @ProductType,
      [dbUser] = @dbUser,
      [dbPwd] = @dbPwd,
      [dbName] = @dbName,
      [dbTable] = @dbTable, 
      [dbProductCode] = @dbProductCode, 
      [dbProductName] = @dbProductName, 
      [dbCountryCode] = @dbCountryCode, 
      [dbStatusCode] = @dbStatusCode,  [dbStatusValue] = @dbStatusValue, 
      [Status] = 0,
      [dbHotelName] = @dbHotelName,
      [dbHotelChain] = @dbHotelChain, 
      [dbFlightNumber] = @dbFlightNumber,
      [dbAirlineName] = @dbAirlineName,
      [dbAirportCode] = @dbAirportCode where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String DeleteCouponProductTypeDataById = @"Update CouponProductType set Status = -1 where Id = @ProductId
	                                                    Select 'Success' as Status,'1' as Success";

    #endregion


    #region Coupon Brand


    public static String GetAllBrands = "Select BrandName,BrandImage,Id,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponBrand where Status!=-1  order by id desc";

    public static String GetCouponBrandById = "	select BrandName,BrandImage,Status from  CouponBrand  where Id = @BrandId";

    public static String InsertCouponBrand = @"if not exists(select 1 from CouponBrand where  BrandName = @BrandName and Status!=-1)
					                            begin
					                                INSERT INTO [dbo].[CouponBrand]
					                                ([BrandName]
					                                ,[BrandImage]
					                                ,[Status]
					                                ,[Created]
					                                )
					                                VALUES
					                                (@BrandName
					                                ,@BrandImage
					                                ,@Status
					                                ,GETDATE())
					                                Select 'Success' as Status,'1' as Success
					                            end
				                                else
					                                begin
					                                Select 'Exist' as Status,'2' as Success
					                                end";

    public static String ValidateCouponBrand = @"Update CouponBrand set Status = @Status where Id = @Id
					Select 'Success' as Status,'1' as Success";

    public static String EditCouponBrand = @"if (@BrandImage<>'')
                                            begin 
                                            Update CouponBrand set BrandName = @BrandName,Status = 0,BrandImage=@BrandImage where Id = @Id
                                            end
                                            else
                                            begin
                                            Update CouponBrand set BrandName =  @BrandName,Status = 0 where Id = @Id
                                            end

					Select 'Success' as Status,'1' as Success";

    public static String DeleteCouponBrandDataById = @"Update CouponBrand set Status = -1 where Id = @BrandId
	                                                    Select 'Success' as Status,'1' as Success";

    #endregion

    #region Coupon Value
    public static String InsertCouponValue = @"
						                            INSERT INTO [dbo].[CouponValue]
							                            ([Label]
							                            ,[Value]
							                            ,[Status]
							                            ,[Created])
						                            VALUES
							                            (@Label
							                            ,@Value
							                            ,@Status
							                            ,GETDATE())
							                            Select 'Success' as Status,'1' as Success";

    public static String GetCouponValue = "Select Label,Value,Id,Case when Status =0 then 'Pending' else case when status = 1 then 'Valid' end end as Status  from CouponValue where Status!=-1  order by id desc";

    public static String GetCouponValueById = "select Label,Value,Status from  CouponValue  where Id = @ValueId";

    public static String DeleteCouponValueById = "Update CouponValue set Status = -1 where Id = @ValueId";

    public static String EditCouponValue = @"Update CouponValue set Label = @Label,Value=@Value,Status = 0 where Id = @Id
					                            Select 'Success' as Status,'1' as Success";
    public static String ValidateCouponValue = @"Update CouponValue set Status = @Status where Id = @Id
					                            Select 'Success' as Status,'1' as Success";

    #endregion


    #region Voucher Campaign


    public static String GetCouponApprValueData = "SELECT Id,Value from CouponValue where status=1  order by id desc";


    public static String GetCouponApprFundingData = "Select Id,GlCode,Department,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponFunding where status=1  order by id desc";


    public static String GetCouponApprCategories = "Select Category,CouponPrefix,Id,Description,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponCategory where Status =1  order by id desc";


    public static String GetCouponApprTypes = "Select Code,Description,Id,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponTypes where Status=1  order by id desc";

    public static String GetAllApprBrands = "Select BrandName,BrandImage,Id,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponBrand where Status=1  order by id desc";

    public static String GetApprProductData = "Select ProductName,ProductCode,Id,Case when Status =0 then 'Pending' else case when status = 1 then 'Approved' end end as Status  from CouponProduct where Status=1  order by id desc";

    public static String InsertVoucherCampaignData = @"if exists(Select 1 from VoucherCampaign where CampaignName = @CampaignName )
begin 
select 'Exists'  as Status,'0' as Success
end
else
begin
INSERT INTO [dbo].[VoucherCampaign]
				                                    ([TypeId]  ,
				                                    [FundingId]  ,
				                                    [CategoryId]  ,
				                                    [BrandId]  ,
				                                    [CampaignName]  ,
				                                    [incProduct]  ,
				                                    [exclProduct]  ,
				                                    [value] ,
				                                    [StartDate] ,
				                                    [EndDate] ,
                                                    [DepartDate] ,
				                                    [ReturnDate] ,
				                                    [Status]  ,
				                                    [Created],
Token,htmlEnglish,htmlFrench
				                                    )
				                                    VALUES
				                                    (@TypeId
				                                    ,@FundingId
				                                    ,@CategoryId
				                                    ,@BrandId
				                                    ,@CampaignName
				                                    ,@incProduct
				                                    ,@exclProduct
				                                    ,@CouponValue
				                                    ,@StartDate,
                                                    @EndDate,
                                                    @DepartDate ,
				                                    @ReturnDate ,

				                                    @Status
				                                    ,GETDATE(),@Token,@htmlEnglish,@htmlFrench)



				                                   
Declare @InsID as int ,@NToken as  varchar(max),@URLEnglish as varchar(max),@URLFrench as varchar(max)
select @InsID =  ID , @NToken= Token   from VoucherCampaign where ID = Scope_Identity()
set @URLEnglish = 'http://www.sunwingvouchers.com/api/SwG_generate?Token=' + @NToken +'&Campaign='+CONVERT(varchar(500), 2000000)+CONVERT(varchar(500), @InsID) + '&Lang=en&FName=&Lname=&Email='
set @URLFrench = 'http://www.sunwingvouchers.com/api/SwG_generate?Token=' + @NToken +'&Campaign='+CONVERT(varchar(500), 2000000)+CONVERT(varchar(500), @InsID) + '&Lang=fr&FName=&LName=&Email='


UPDATE VoucherCampaign set UrlEnglish =@URLEnglish, urlFrench=@URLFrench
where ID = @InsID
 Select 'Success' as Status,'1' as Success
											
end

";





    public static String GetVoucherCampaign = @"SELECT VC.Id,VC.CampaignName as CampName,CT.Code,CB.BrandName,CV.Value as CoupoNValue,
								(CONVERT(Date, StartDate, 104)) as StartDate,
				(CONVERT(Date, EndDate, 104)) as [EndDate] ,(CONVERT(Date, DepartDate, 104)) as [DepartDate] ,(CONVERT(Date, ReturnDate, 104)) as [Returndate], 
                Case when VC.Status= 0 then 'Pending' else case when Vc.Status=1 then 'Approved' end end as Status,VC.UrlEnglish,VC.UrlFrench,VC.htmlEnglish,VC.htmlFrench from VoucherCampaign VC 
                left join CouponTypes CT on CT.Id = VC.TypeId
                left join CouponFunding CF on CF.Id = VC.FundingId
                left join CouponCategory CC on CC.Id = VC.CategoryId
                left join CouponBrand CB on CB.Id = VC.BrandId
				left join CouponValue CV on CV.Id = VC.Value
				 where vc.status != -1  order by id desc";

    public static String GetVoucherCampaignById = @"select [TypeId] as CouponTypeId  ,
				[FundingId] as CouponFundingId,
				[CategoryId] as CouponCatId ,
				[BrandId] as CouponBrandId ,
				[CampaignName] as CampName ,
				[incProduct] as InclProduct ,
				[exclProduct] as ExclProduct ,
				[value] as CouponValue,
				(TRY_CONVERT(smalldatetime, CONVERT(datetime, [StartDate]))) as StartDate,
				(TRY_CONVERT(smalldatetime, CONVERT(datetime, [EndDate]))) as [EndDate] ,
				(TRY_CONVERT(smalldatetime, CONVERT(datetime, [DepartDate]))) as DepartDate,
				(TRY_CONVERT(smalldatetime, CONVERT(datetime, [ReturnDate]))) as [ReturnDate] ,

				[Status],isnull(UrlEnglish,'') as UrlEnglish,isnull(UrlFrench,'') as UrlFrench,htmlEnglish,htmlFrench   from  VoucherCampaign  where Id = @CampId";

    public static String DeleteVoucherCampaignById = @"Update VoucherCampaign set Status = -1 where Id = @CampId
	Select 'Success' as Status,'1' as Success";

    public static String EditVoucherCampaignById = @"if exists(Select 1 from VoucherCampaign where CampaignName = @CampaignName )
begin 
select 'Exists'  as Status,'0' as Success
end
else
begin
UPDATE [dbo].[VoucherCampaign]
				   SET [TypeId] = @TypeId
					  ,[FundingId] = @FundingId
					  ,[CategoryId] = @CategoryId
					  ,[BrandId] = @BrandId
					  ,[CampaignName] = @CampaignName
					  ,[incProduct] = @incProduct
					  ,[exclProduct] = @exclProduct
					  ,[value] = @CouponValue
					  ,[StartDate] = @StartDate
					  ,[EndDate] = @EndDate,
                        [DepartDate] = @DepartDate
					  ,[ReturnDate] = @ReturnDate,
htmlEnglish = @htmlEnglish,htmlFrench = @htmlFrench,
Status = 0
					  where Id = @Id
					Select 'Success' as Status,'1' as Success end";

//    public static String ValidateVoucherCampaignById = @"UPDATE [dbo].[VoucherCampaign]
//				   SET 
//[TypeId] = @TypeId
//					  ,[FundingId] = @FundingId
//					  ,[CategoryId] = @CategoryId
//					  ,[BrandId] = @BrandId
//					  ,[CampaignName] = @CampaignName
//					  ,[incProduct] = @incProduct
//					  ,[exclProduct] = @exclProduct
//					  ,[value] = @value
//					  ,[StartDate] = @StartDate
//					  ,[EndDate] = @EndDate
//					  ,[Status] = @Status  where Id = @Id
//                        Select 'Success' as Status,'1' as Success";


    public static String ValidateVoucherCampaignById = @"UPDATE [dbo].[VoucherCampaign]
				   SET 
					  [Status] = @Status  where Id = @Id
                        Select 'Success' as Status,'1' as Success";


    #endregion


    #region Gift Certificates
    public static string InsertCertificateData = @"INSERT INTO [dbo].[CertificateMaster]
  
        ([TypeId]  ,
[CategoryId] 
        ,[CertificateId]
        ,[FirstName]
        ,[LastName]
        ,[CertificateAmount]
        ,[CertificateValue]
       
        ,[IssueDate]
        ,[Expirydate]
        ,[Status]
        ,[Created], [BrandId] )
        VALUES
        (@TypeId
	    ,@CategoryId
        ,@NewCertificateCode
        ,@FirstName
        ,@LastName
        ,@CertificateAmount
        ,@CertificateAmount
        
        ,getdate()
        ,@Expirydate
        ,@Status
        ,getdate(),@CampaignBrandId)";
    public static String GetCertificateCode = "Select 1 from CertificateTable where CertificateCode =@NewCertificateCode";

    public static String InsertCertificate = @"if not EXISTS(SELECT 1
                                        FROM CertificateTable
                                        WHERE CertificateCode = @NewCertificateCode )
                                        begin
                                        INSERT INTO CertificateTable (CertificateCode) VALUES (@NewCertificateCode)
                                 Select 'Success'
                                        end
                                        else
                                        begin
                                        Select 'Repeat'
                                        end";

    public static String GetCertificateGrid = @"if exists(select 1 from certificatemaster where expirydate>getdate()-1  and status<>'INVALID')
begin
update certificatemaster set status = 'EXPIRED' where expirydate<getdate()-1 and status<>'INVALID'
end
Select VM.id as Id,VM.TypeId,VM.BrandId as CampaignBrandId,VM.CategoryId,CertificateId,FirstName,
LastName,CertificateAmount,CertificateValue,VM.Status 
from CertificateMaster VM  where VM.Status <> 'INVALID'  order by id desc";
    public static string GetCertificateCodeById = @"select  Id,TypeId as CouponTypeId,CategoryId as CouponCatId,BrandId as CampaignBrandId,CertificateId,FirstName,LastName,CertificateAmount,CertificateValue,incProduct as inclproduct,exclProduct,CONVERT(VARCHAR(8), IssueDate, 1) as IssueDate,CONVERT(VARCHAR(8), ExpiryDate, 1) as ExpiryDate, Status 
	from CertificateMaster where Id = @CertificateId";
    public static string DeleteCertificate = @"update CertificateMaster set Status = 'INVALID' where id = @CertificateId";

    public static String GetCertificateCampaignData = "SELECT Id,CampaignName from VoucherCampaign where status!=-1  order by id desc";


    public static string EditCertificateData = @"UPDATE [dbo].[CertificateMaster]
   SET [CampaignId] = @CampaignId,
   [Status] = @Status 
      ,[FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[CertificateAmount] = @CertificateAmount
      ,[IncProduct] = @IncProduct
      ,[ExclProduct] = @ExclProduct
      ,[ExpiryDate] = @ExpiryDate
      ,[Updated] = getdate()
      ,[TypeId] = @TypeId
      ,[CategoryId] = @CategoryId
      ,[BrandId] = @BrandId
 WHERE Id = @Id";

         public static string ValidateCertificateData =@"UPDATE [dbo].[CertificateMaster]
				   SET 
					  [Status] = @Status  where Id = @Id
                        Select 'Success' as Status,'1' as Success";

    #endregion


    #region GetCat Prefix
    public static string GetCategoryPrefixByCategoryId = "select CouponPrefix from CouponCategory   where Id = @CategoryId";
    
    #endregion

    #region Global Audit String
    public static String InsertAudit = @"INSERT INTO [dbo].[audit]
           ([timestamp]
           ,[user]
           ,[function]
           ,[text]
           ,[Status])
     VALUES
	 (@TimeStamp
           ,@User
           ,@Function
           ,@Text
           ,@Status)";

    #endregion

    #region User
    public static String DeleteUser = "update portal_userpanel_admin set Status = -1 where id = @UserId";
    #endregion


    #region BlackOutdates

    public static string EditBlackOutData = @"UPDATE [dbo].[BlackOutDates]
   SET [Name] = @Name
        ,[EndDate] = @Enddate
      ,[StartDate] = @Startdate
      ,[Active] = @Active
      

 WHERE  Id = @Id";

    public static String ValidateBlackOutDatesData = @"UPDATE [dbo].[BlackOutDates]
				   SET 
					  [Active] = @Active where Id = @Id
                        Select 'Success' as Status,'1' as Success";

    public static string InsertBlackOutDatesData = @"INSERT INTO [dbo].[BlackOutDates]
        (				                                    [Name]  ,
				                                    [StartDate]  ,
				                                    [EndDate]  ,
				                                    [Active]  ,
        [Created])
        VALUES
        (@Name
	    ,@StartDate
	    ,@EndDate
	    ,@Active
        ,getdate())";



    public static string GetBDatesById = @"select [Name],
				CONVERT(VARCHAR(10), StartDate, 126) as StartDate ,
				CONVERT(VARCHAR(10), EndDate, 126) as EndDate ,
				Active 
	from BlackOutDates where Id = @Id";

    public static string DeleteBDatesbyId = @"update BlackOutDates set Active = -1 where id = @Id";

    public static String GetBlackOutdates = @"select Id,Name,CONVERT(VARCHAR(10), StartDate, 126) as StartDate ,
				CONVERT(VARCHAR(10), EndDate, 126) as EndDate ,case when Active=1 then 'Yes' else 'No' end as Active from BlackOutDates where Active <>-1";


    #endregion

}