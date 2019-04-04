using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
public class Vendor : User
    {
        // turn to lists
        // public List<String> AreaOfHouse {get; set;}
        // public List<String> BusinessCategory {get; set;}
        public virtual IEnumerable<PendingVendors> RequestedEvents {get; set;}
        public virtual IEnumerable<ConfirmedVendors> ConfirmedEvents {get; set;}

    }   
}