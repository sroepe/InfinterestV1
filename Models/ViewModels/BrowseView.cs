using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class BrowseView
    {
        List<Event> UpcomingEvents {get;set;}
        List<Event> PastEvents {get;set;}
    }
}