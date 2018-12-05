<Query Kind="Program">
  <Connection>
    <ID>c6f3faac-ca0f-4cc2-96fe-8806d1f46f86</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eBikes</Database>
  </Connection>
</Query>

void Main()
{
	var results = from x in Jobs
					select new CurrentJobs
					{
						JobID = x.JobID,
                        JobDateIn = x.JobDateIn,
                        JobDateStarted = x.JobDateStarted,
                        JobDateDone = x.JobDateDone,
                        JobDateOut = x.JobDateOut,
						FullName = x.Customer.LastName + ", " + x.Customer.FirstName,
						Phone = x.Customer.ContactPhone
					};
	results.Dump();
	
	var results2 = from x in ServiceDetails
					select new
					{
						CouponID = x.CouponID,
						CouponName = x.Coupon.CouponIDValue
					};
	results2.Dump();
	
	var results3 = from x in Coupons
					select x;
	results3.Dump();
}

// Define other methods and classes here
public class CurrentJobs
    {
        public int JobID { get; set; }
        public DateTime JobDateIn { get; set; }
        public DateTime? JobDateStarted { get; set; }
        public DateTime? JobDateDone { get; set; }
        public DateTime? JobDateOut { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }