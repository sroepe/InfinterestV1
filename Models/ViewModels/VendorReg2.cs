using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinterest.Models
{
    public class VendorReg2
    {
        public Vendor CurrentUser {get;set;}

        public List<Area> AllArea {get;set;}
        public List<Business> AllBusiness {get;set;}
        public List<Area> UserAreaInput {get;set;}
        public List<Business> UserBusinessInput {get;set;}
    }
}