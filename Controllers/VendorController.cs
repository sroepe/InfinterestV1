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
            
            // viewModel.allListings = _context.listings
            //                         .ToList();

            // // Vendor user = _context.vendors
            // //             .Where(vend => vend.UserId == ID)
            // //             .FirstOrDefault();

            // if(user.ConfirmedEvents != null)
            // {
            //     viewModel.usersEvents = user.ConfirmedEvents.Select(s => s.Event).ToList();
            // }

            return View ("DashboardVendor", viewModel);
        }

        [HttpGet("vendor-registration")]
        public IActionResult VendorRegistration()
        {

            return View("VendorRegistration2");
        }

        [HttpGet("Vendor/vendor-registration")]
        public IActionResult CreateVendor()
        {
            User NewVendor = new User();
            return View(NewVendor);
        }

        [HttpPost("Vendor/vendor-registration")]
        public IActionResult CreateVendor(User NewVendor)
        {
            if (ModelState.IsValid)
            {
                // System.Console.WriteLine("Model IS VALID");
                // if(_context.users.Any(u => u.Email == NewVendor.Email))
                // {
                //     ModelState.AddModelError("Email", "Email already in use!");
                // }
                // else
                // {
                    System.Console.WriteLine("Creating");
                    User ThisVendor = new User();
                    ThisVendor.FirstName = NewVendor.FirstName;
                    ThisVendor.LastName = NewVendor.LastName;
                    ThisVendor.ImgUrl = NewVendor.ImgUrl;
                    ThisVendor.UserType = "Vendor";
                    ThisVendor.Bio = NewVendor.Bio;
                    return RedirectToAction("DashboardVendor");
                // }
            } 
            System.Console.WriteLine("Not valid");
            return View("VendorRegistration2", NewVendor);
            
        }

        // [HttpGet("Vendor/vendor-registration")]
        // public IActionResult VendorVendorRegistration()
        // {
               
        //     return View("VendorRegistration2");
        // }

        // [HttpPost("Vendor/vendor-registration")]
        // public IActionResult CreateVendor(UserValidator NewVendor)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         System.Console.WriteLine("Model IS Valid");
        //         if(_context.vendors.Any(u => u.Email == NewVendor.Email))
        //         {
        //             ModelState.AddModelError("Email", "Email already in use!");
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("Creating");
        //             Vendor ThisVendor = new Vendor();
        //             ThisVendor.FirstName = NewVendor.FirstName;
        //             ThisVendor.LastName = NewVendor.LastName;
        //             ThisVendor.ImgUrl = NewVendor.ImgUrl;
        //             ThisVendor.UserType = "Vendor";
        //             ThisVendor.Bio = NewVendor.Bio;
        //             ThisVendor.RequestedEvents = new List<PendingVendors>();
        //             ThisVendor.ConfirmedEvents = new List<ConfimedVendors>();
        //             // and so on
        //             PasswordHasher<Vendor> Hasher = new PasswordHasher<Vendor>();
        //             ThisVendor.Password = Hasher.HashPassword(ThisVendor, NewVendor.Password);
        //             _context.vendors.Add(ThisVendor);
        //             _context.users.Add(ThisVendor);
        //             _context.SaveChanges();
        //             HttpContext.Session.SetInt32("userid", ThisVendor.UserId);
        //             return RedirectToAction("DashboardVendor");
        //         }
        //     }
        //     System.Console.WriteLine("Not valid");
        //     return View("VendorRegistration2", NewVendor);
        // }

        
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
