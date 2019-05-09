using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class EventDetailView
    {
        public User CurrentUser {get;set;}

        public Event CurrentEvent {get;set;}

        public EventDetailView(User userInput, Event eventInput)
        {
            CurrentUser = userInput;
            CurrentEvent = eventInput;
        }
    }
}