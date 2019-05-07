using System.Collections.Generic;

namespace Infinterest.Models
{
    public class DashboardVendorView
    {
        public Vendor currentUser {get;set;}
        public List<Event> allEvents {get;set;}
        public virtual List<Event> usersEvents {get;set;}
    }
}