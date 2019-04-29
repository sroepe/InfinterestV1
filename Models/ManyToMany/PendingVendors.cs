namespace Infinterest.Models
{
    public class VendorToEvent
    {
        public bool Confirmed {get;set;}
        public int VendorId {get;set;}
        public Vendor Vendor {get;set;}
        public int EventId {get;set;}
        public Event Event {get;set;}
    }
}