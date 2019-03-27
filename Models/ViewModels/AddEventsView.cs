using System.Collections.Generic;

namespace Infinterest.Models
{
    public class AddEventsView
    {
        public Event eventToCreate {get;set;}
        public List<Listing> usersListings {get;set;}
    }
}