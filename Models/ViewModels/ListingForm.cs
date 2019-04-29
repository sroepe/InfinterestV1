using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class ListingForm : BaseEntity
    {   
        public string MLSLink {get; set;}
        public int Price {get; set;}
        public string addressLine1 {get;set;}
        public string addressLine2 {get;set;}
        public string city {get;set;}
        public string postalCode {get;set;}
        public string state {get;set;}
        public string ImgUrl { get; set; }
        
        

    }   
}