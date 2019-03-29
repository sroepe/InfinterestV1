using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infinterest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Infinterest.Controllers
{
    public class VendorController : Controller
    {
        private Context _context;
        public VendorController(Context context)
        {
            _context = context;
        }

        [HttpGet("vendor-registration")]
        public IActionResult VendorRegistration()
        {
            return View();
        }

        
        // what exactly is this doing???
        // [HttpPost("vendor")]
        // public IActionResult NewVendor(Vendor NewVendor)
        // {
        //     if(ModelState.IsValid)  
        //     {   
        //         int UserId = (int)HttpContext.Session.GetInt32("UserId");
        //         User User =_context.users.SingleOrDefault(user => user.UserId == UserId);
                
        //         HttpContext.Session.SetInt32("UserId", UserId);
        //         @ViewBag.User = User;

        //         NewVendor.UserId = UserId;
        //         _context.vendors.Add(NewVendor);
        //         _context.SaveChanges();
        //         return RedirectToAction("Dashboard");
        //     }
        //     else
        //     {
        //         return View("Vendor");
        //     }
        // }
        
    }
}
