using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infinterest.Models
{
public class User : BaseEntity
    {   
        // Database info
        public int UserId {get; set;}
        public string UserType {get; set;}
        public int AffiliateCode {get; set;}

        // User-input
            // required
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
            // optional
        public string ImgUrl { get; set; }
        public string Contact {get; set;}
        public string Bio {get; set;}
        public string Company { get; set; }
        public string Website { get; set; }

    }   
}