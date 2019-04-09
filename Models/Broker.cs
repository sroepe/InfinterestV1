using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
public class Broker : User
    {
        public List<Listing> Listings {get; set;}
        public List<Event> Events {get; set;}
        


        public Broker()
        {
            UserType = "Broker";
            Listings = new List<Listing>();
            Events = new List<Event>();

            PasswordHasher<Broker> Hasher = new PasswordHasher<Broker>();
            Password = Hasher.HashPassword(this, Password);
        }

        public Broker(User input)
        {
            UserType = "Broker";
            FirstName = input.FirstName;
            LastName = input.LastName;
            Email = input.Email;
            PasswordHasher<Broker> Hasher = new PasswordHasher<Broker>();
            Password = Hasher.HashPassword(this, input.Password);
            ImgUrl = input.ImgUrl;
            Contact = input.Contact;
            Bio = input.Bio;
            Company = input.Company;
            Website = input.Website;
            Listings = new List<Listing>();
            Events = new List<Event>();
        }
    }   
}