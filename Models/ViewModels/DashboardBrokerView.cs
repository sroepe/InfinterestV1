using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class DashboardBrokerView
    {
        public Broker CurrentUser {get;set;}

        public List<Listing> UsersListings {get;set;}
        public List<Event> PendingEvents {get;set;}
        public List<Event> FinalizedEvents {get;set;}
        public List<Vendor> AvailableVendors {get;set;}
    }
}