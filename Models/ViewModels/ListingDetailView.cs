using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class ListingDetailView
    {
        public User CurrentUser {get;set;}

        public Listing CurrentListing {get;set;}

        public ListingDetailView(User userInput, Listing listingInput)
        {
            CurrentUser = userInput;
            CurrentListing = listingInput;
        }
    }
}