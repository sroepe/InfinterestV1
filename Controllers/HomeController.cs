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
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        // Signin and login page
        public IActionResult Index()
        {
            // if (string.IsNullOrEmpty(HttpContext.Session.GetString("Login")))
            // {
            //     HttpContext.Session.SetString("Login", "False");
            //     HttpContext.Session.SetInt32("UserId", 0);
            // }  
            ViewBag.Error = TempData["Error"];
            ViewBag.ErrorReg = TempData["ErrorReg"];
            return View("Index");
        }
        // vendor reg moved to vendor controller
        // broker reg moved to broker controller

        [HttpGet("broker-profile/{id}")]
        public IActionResult BrokerProfile(String id)
        {
            if(Int32.TryParse(id, out int userid))
            {
                Broker thisBroker = _context.users
                .OfType<Broker>()                
                    .Where(broker => broker.UserId == userid)
                    .FirstOrDefault();
                return View("BrokerProfile", thisBroker);
            }
            
            return RedirectToAction ("Dashboard");
        }
        [HttpGet("vendor-profile/{id}")]
        public IActionResult VendorProfile(String id)
        {
            if(Int32.TryParse(id, out int userid))
            {
                Vendor thisVendor = _context.users
                .OfType<Vendor>()
                    .Where(vendor => vendor.UserId == userid)
                    .FirstOrDefault();
                return View("VendorProfile", thisVendor);
            }
            
            return RedirectToAction ("Dashboard");

        }

        [HttpGet("event-detail/{eventId}")]
        public IActionResult EventDetail(String eventId)
        {
            if(Int32.TryParse(eventId, out int id))
            {
                Event thisEvent = _context.events
                    .Where(ev => ev.EventId == id)
                    .FirstOrDefault();
                return View(thisEvent);
            }
            return RedirectToAction ("Dashboard");
        }

        [HttpGet("Listing-detail/{listingId}")]
        public IActionResult ListingDetail(String listingId)
        {
            if(Int32.TryParse(listingId, out int id))
            {
                Listing thisListing = _context.listings
                    .Include(List => List.Address)
                    .Include(lis => lis.Events)
                    .ThenInclude(eve => eve.RequestedVendors)
                    .FirstOrDefault(lis => lis.ListingId == id);
                return View(thisListing);
            }
            return RedirectToAction ("Dashboard");
        }

        //temporary - just for viewing while working
        [HttpGet("event-detail")]
        public IActionResult EventDetailTemp(String eventId)
        {
            return View ("EventDetail");
        }

        // POST Login user
        [HttpPost("existing-user")]
        public IActionResult ExistingUser(User userInput)
        {   
            if(userInput.Email != null && userInput.Password != null)
            {   
                User ThisUser =_context.users.SingleOrDefault(user => user.Email == userInput.Email);
                if(ThisUser != null)
                {
                    var Hasher = new PasswordHasher<User>();
                
                    if(0 != Hasher.VerifyHashedPassword(ThisUser, ThisUser.Password, userInput.Password))
                    {
                        HttpContext.Session.SetString("Login", "True");
                        HttpContext.Session.SetInt32("userid", ThisUser.UserId);
                        return Redirect("/dashboard");
                    }
                }
                TempData["Error"] = "Your email or password are not correct";      
            }
            else 
            {   
                TempData["Error"] = "An email and password are required";
            }
            //temp while sorting out error return
            return Redirect("/fail");
            // return RedirectToAction("Index");
        }
        //GET Logoff
        [HttpGet("logoff")]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }  

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            int? ID = HttpContext.Session.GetInt32("userid");

            User CurrentUser = _context.users
            .Where(user => user.UserId == ID)
            .FirstOrDefault();

            if(CurrentUser != null)
            {
                if(CurrentUser.UserType == "Vendor")
                {
                    return RedirectToAction("DashboardVendor", "Vendor");
                }
                else if(CurrentUser.UserType == "Broker")
                {
                    return RedirectToAction("DashboardBroker", "Broker");
                }
            }
                //fake code
                return Redirect("/dashboardfail");
        }
        
        // [HttpGet("messaging")]
        // public IActionResult Messaging()
        // {
        //     return View();
        // }

        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return View();
        }
        [HttpGet("profile-changes")]
        public IActionResult ProfileChanges()
        {
            return View();
        }

        [HttpGet("search")]
        public IActionResult AfterSearch()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
