------------------------                  Task 1   -----------------------------------------

-- Change Categories to Types
   update portal_functions set title='Types', target='CouponTypes.aspx' where title='Categories'
-- - Change Types to Venue  
  update portal_functions set title='Venue', target='CouponVenues.aspx' where title='Types' 

 -- Remove Funding
   delete from portal_functions where title='Funding'


-- Remove Values
   delete from portal_functions where title='Values'

-- Remove Product Types
  delete from portal_functions where title='Product Types'

--Remove Blackout Dates
  delete from portal_functions where title='Blackout Dates'

  ------------------------                  Task 2   -----------------------------------------
  delete from portal_functions where title in ('Sliders','Portal Pages')  
  delete from portal_modules where id=2

    ------------------------                  Task 3   -----------------------------------------
	 update [portal_modules]  set title='Gift Cards' where title='Gift Certificates'
	 update portal_functions set title='Gift Cards', target='GiftCards.aspx' where title='Gift Certificates' 

	 ------------------------                  Task 4   -----------------------------------------
	
    delete from portal_functions where title='Flight Interruption' 
    delete from portal_functions where title='Marketing Voucher'
