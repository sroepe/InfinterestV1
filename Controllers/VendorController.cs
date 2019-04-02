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

        //temporary for front-end work to be replaced by next get method for "dashboardvendor"
        // [HttpGet("dashboardvendor")]
        // public IActionResult DashboardVendor()
        // {

        //     return View();
        // }


        [HttpGet("dashboardvendor")]
        public IActionResult DashboardVendor()
        {

            int? ID = HttpContext.Session.GetInt32("userid");            

            DashboardVendorView viewModel = new DashboardVendorView();
            
            viewModel.allListings = _context.listings
                                    .ToList();

            Vendor user = _context.vendors
                        .Where(vend => vend.UserId == ID)
                        .FirstOrDefault();

            // viewModel.usersEvents = user.ConfirmedEvents;

            return View ("DashboardVendor", viewModel);
        }

        [HttpGet("vendor-registration")]
        public IActionResult VendorRegistration()
        {

            return View();
        }
        [HttpPost("vendor-registration")]
        public IActionResult CreateVendor(UserValidator NewVendor)
        {
            if (ModelState.IsValid)
            {
                if(_context.vendors.Any(u => u.Email == NewVendor.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
                return View("vendor-registation");
            }
            else
            {
                Vendor ThisVendor = new Vendor();
                ThisVendor.FirstName = NewVendor.FirstName;
                ThisVendor.LastName = NewVendor.LastName;
                ThisVendor.ImgUrl = NewVendor.ImgUrl;
                ThisVendor.UserType = "Vendor";
                ThisVendor.Bio = NewVendor.Bio;
                // ThisVendor.RequestedEvents = new List<Event>();
                // ThisVendor.ConfirmedEvents = new List<Event>();
                // and so on
                PasswordHasher<Vendor> Hasher = new PasswordHasher<Vendor>();
                ThisVendor.Password = Hasher.HashPassword(ThisVendor, NewVendor.Password);
                _context.Add(ThisVendor);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("userid", ThisVendor.UserId);
                return Redirect("/dashboard"); //This doesn't exist yet
            }
            }
            else
            {
                return View("vendor-registration");
            }
        }

        
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
