<Query Kind="Program">
  <Connection>
    <ID>cf2ca8f7-5cc6-4a36-880f-82b83de5ac97</ID>
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
	
	var results4 = from x in Jobs
					where x.JobID.Equals(1)
					select new
					{
						Name = x.Customer.LastName + ", " + x.Customer.FirstName,
						Contact = x.Customer.ContactPhone
					};
	results4.Dump();
	
	var results5 = from x in ServiceDetails
					where x.JobID.Equals(3)
					select x;
	results5.Dump();
	
	var exists = from x in ServiceDetails
				where x.JobID.Equals(2) && x.ServiceDetailID.Equals(2)
				select x;
	exists.Dump();
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