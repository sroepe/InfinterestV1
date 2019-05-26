namespace Infinterest.Models
{
    public class VendorToEvent
    {
        public string RequestStatus {get;set;} //Requested, Accepted, Or Denied
        public int VendorId {get;set;}
        public Vendor Vendor {get;set;}
        public int EventId {get;set;}
        public Event Event {get;set;}

        public VendorToEvent ()
        {
            RequestStatus = "Requested";
        }
        public VendorToEvent (Vendor userInput, Event eventInput)
        {
            RequestStatus = "Requested";
            Vendor = userInput;
            VendorId = userInput.UserId;
            Event = eventInput;
            EventId = eventInput.EventId;
        }
    }
}