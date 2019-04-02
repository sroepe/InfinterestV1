using System.Collections.Generic;

namespace Infinterest.Models
{
    public class DashboardVendorView
    {
        public List<Listing> allListings {get;set;}
        public virtual ICollection<Event> usersEvents {get;set;}
    }
}