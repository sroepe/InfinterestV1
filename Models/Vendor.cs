using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
public class Vendor : User
    {
        public List<Area> AreaOfHouse {get; set;}
        public List<Business> BusinessCategory {get; set;}
        public virtual List<PendingVendors> RequestedEvents {get; set;}
        public virtual List<ConfirmedVendors> ConfirmedEvents {get; set;}

    public Vendor()
        {

        }

        public Vendor(User input)
        {
            UserType = "Broker";
            FirstName = input.FirstName;
            LastName = input.LastName;
            Email = input.Email;
            PasswordHasher<Vendor> Hasher = new PasswordHasher<Vendor>();
            Password = Hasher.HashPassword(this, input.Password);
            ImgUrl = input.ImgUrl;
            Contact = input.Contact;
            Bio = input.Bio;
            Company = input.Company;
            Website = input.Website;

            //area of house and business catagory
            
            RequestedEvents = new List<PendingVendors>();
            ConfirmedEvents = new List<ConfirmedVendors>();
        }
    }
}