using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class Listing : BaseEntity
    {   
        public int ListingId {get; set;}
        public bool Availible {get;set;}
        public string MLSLink {get; set;}
        public int Price {get; set;}
        public int Zip {get; set;}  //do we need to have zip as well on the listing since it pulls postalCode from Address??
        public Address Address {get;set;}
        public int AddressId {get;set;}
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public int BrokerId {get; set;}
        public Broker Broker {get; set;}

        public List<Event> Events {get; set;}
        
        public Listing()
        {
            Availible = true;
            Events = new List<Event>();
        }

        public Listing(ListingForm UserInput)
        {
            Availible = true;
            Events = new List<Event>();
            MLSLink = UserInput.MLSLink;
            Price = UserInput.Price;
            if(Int32.TryParse(UserInput.postalCode, out int zip))
            {
                Zip = zip;
            }
            ImgUrl = UserInput.ImgUrl;
            Description = UserInput.Description;
            Address = new Address(UserInput);
        }
        public Listing(ListingForm UserInput, Address InputAddress)
        {
            Availible = true;
            Events = new List<Event>();
            MLSLink = UserInput.MLSLink;
            Price = UserInput.Price;
            if(Int32.TryParse(UserInput.postalCode, out int zip))
            {
                Zip = zip;
            }
            ImgUrl = UserInput.ImgUrl;
            Description = UserInput.Description;
            Address = InputAddress;
        }

    }   
}