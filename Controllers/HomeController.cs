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
                Broker thisBroker = _context.brokers
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
                Vendor thisVendor = _context.vendors
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

        //temporary - just for viewing while working
        [HttpGet("event-detail")]
        public IActionResult EventDetailTemp(String eventId)
        {
            return View ("EventDetail");
        }



        

        //POST Register user  
        // [HttpPost("new-user")]
        // public IActionResult NewUser(UserValidator User)
        // {   
        //     if(ModelState.IsValid)  
        //     {   
        //         User OldUser =_context.users.SingleOrDefault(user => user.Email == User.Email);
        //         if(OldUser == null){
        //             User NewUser = new User();
        //             if(User.UserType == "Vendor"){
        //                 NewUser.UserType = "V";
        //             }
        //             else{
        //                 User.UserType = "B";
        //             }
        //             NewUser.FirstName = User.FirstName;
        //             NewUser.LastName = User.LastName;
        //             NewUser.Contact = User.Contact;
        //             NewUser.Bio = User.Bio;
        //             NewUser.Email = User.Email;
        //             // DateTime CurrentTime = DateTime.Now;
        //             // NewUser.CreatedAt = CurrentTime;
                    
        //             PasswordHasher<UserValidator> Hasher = new PasswordHasher<UserValidator>();
        //             NewUser.Password = Hasher.HashPassword(User, User.Password);
                    
        //             _context.users.Add(NewUser);
        //             _context.SaveChanges();
        //             HttpContext.Session.SetString("Login", "True");
        //             HttpContext.Session.SetInt32("UserId", NewUser.UserId);
        //             if(User.UserType == "Vendor"){
        //                 return RedirectToAction("Vendor");
        //             }
        //             else{
        //                 return RedirectToAction("Broker");
        //             }

        //         }
        //         //if user is found
        //         else{
        //             TempData["ErrorReg"] = "That email address already exists";
        //             return RedirectToAction("Registration");
        //         }
        //     }
        //     else
        //     {
        //         return View("Registration");
        //     }
        // }

        // POST Login user
        [HttpPost("existing-user")]
        public IActionResult ExistingUser(string PasswordLogin, string EmailLogin)
        {   
            if(EmailLogin != null && PasswordLogin != null)
            {   
                User User =_context.users.SingleOrDefault(user => user.Email == EmailLogin);
                if(User != null){
                    var Hasher = new PasswordHasher<User>();
                
                    if(0 != Hasher.VerifyHashedPassword(User, User.Password, PasswordLogin))
                    {
                        HttpContext.Session.SetString("Login", "True");
                        HttpContext.Session.SetInt32("UserId", User.UserId);
                        return RedirectToAction("Dashboard");
                    }
                }
                TempData["Error"] = "Your email or password are not correct";
                return RedirectToAction("Index");      
            }
            else 
            {   
                TempData["Error"] = "An email and password are required";
                return RedirectToAction("Index");
            }
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
            int? ID = HttpContext.Session.GetInt32("UserId");

            User CurrentUser = _context.users
            .Where(user => user.UserId == ID)
            .FirstOrDefault();

            if(CurrentUser != null)
            {
                if(CurrentUser.UserType == "Vendor")
                {
                    return View("dashboardvendor");
                }
                else if(CurrentUser.UserType == "Broker")
                {
                    return View("DashboardBroker");
                }
            }
                //fake code
                return Redirect("/");
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

        // add listings moved to broker

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
