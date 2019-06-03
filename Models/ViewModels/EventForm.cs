using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class EventForm : BaseEntity
    {
        public List<Area> AreaOfHouse {get; set;}

        public DateTime OpenHouseDate {get; set;}
        public DateTime OpenHouseTime {get; set;}
    }
}