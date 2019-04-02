namespace Infinterest.Models
{
    public class ConfimedVendors
    {
        public int VendorId {get;set;}
        public Vendor Vendor {get;set;}
        public int EventId {get;set;}
        public Event Event {get;set;}
    }
}