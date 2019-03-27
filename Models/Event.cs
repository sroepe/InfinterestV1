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
        public Boolean Confimed {get;set;}
        public int ListingId {get; set;}
        public Listing Listing {get;set;}
        public DateTime OpenHouseDate {get; set;}
        public List<Vendor> RequestedVendors {get;set;}
        public List<Vendor> ConfrimedVendors {get;set;}
    }
}