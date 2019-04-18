using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class Event : BaseEntity
    {
        public int EventId {get; set;}
        public Boolean Confirmed {get;set;}
        public int ListingId {get; set;}
        public Listing Listing {get;set;}
        public string AreaOfHouseToFeature {get; set;}

        public DateTime OpenHouseDate {get; set;}
        public DateTime OpenHouseTime {get; set;}
        public virtual IEnumerable<PendingVendors> RequestedVendors {get;set;}
        public virtual IEnumerable<ConfirmedVendors> ConfirmedVendors {get;set;}
    }
}