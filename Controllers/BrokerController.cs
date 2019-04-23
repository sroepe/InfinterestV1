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
    public class BrokerController : Controller
    {
        private Context _context;
        public BrokerController(Context context)
        {
            _context = context;
        }

        [HttpGet("broker-registration")]
        public IActionResult BrokerRegistration()
        {
            return View("BrokerRegistration");
        }

        [HttpPost("broker-registration")]
        public IActionResult DoesBrokerRegistration(User UserInput)
        {
            if(ModelState.IsValid)
            {
                if(_context.users.Any(u => u.Email == UserInput.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return View("BrokerRegistration");
                }
                else
                {
                    Broker NewBroker = new Broker(UserInput);
                    
                    _context.users.Add(NewBroker);
                    
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("userid", NewBroker.UserId);

                    return RedirectToAction("DashboardBroker");
                }
            }
            else
            {
                return View("BrokerRegistration");
            }
        }

        

        [HttpGet("brokerdashboard")]
        public IActionResult DashboardBroker()
        {
            
            
            int? ID = HttpContext.Session.GetInt32("userid");           
            Broker user = _context.users
                .OfType<Broker>()
                .Where(broker => broker.UserId == ID)
                .FirstOrDefault();

            if (user == null)
            {
                return Redirect("/");
            }

            DashboardBrokerView DisplayModel = new DashboardBrokerView();
            DisplayModel.CurrentUser = user;

            DisplayModel.UsersListings = _context.listings
                .Where(lis => lis.BrokerId == user.UserId)
                .Include(lis => lis.Events)
                .ThenInclude(eve => eve.RequestedVendors)
                .ToList();

            DisplayModel.AvailableVendors = _context.users
            .OfType<Vendor>()
            .ToList();

            return View("DashboardBroker", DisplayModel);
        
        }

        //temporary to show add event page
        [HttpGet("add-event/{ListingId}")]
        public IActionResult AddEventTemp(String ListingId)
        {
            ViewBag.listingId = ListingId;
                return View ("AddEvents");

        }

        [HttpPost("add-event/{ListingId}")]
        public IActionResult CreateEvent(Event NewEvent, String ListingId)
        {
            if (ModelState.IsValid)
            {
                if(Int32.TryParse(ListingId, out int id))
                {
                    NewEvent.RequestedVendors = new List<PendingVendors>();
                    NewEvent.ConfirmedVendors = new List<ConfirmedVendors>();
                    NewEvent.ListingId = id;
                    Listing thisListing = _context.listings
                    .FirstOrDefault(l => l.ListingId == id);
                    NewEvent.Listing = thisListing;

                    
                    int? ID = HttpContext.Session.GetInt32("userid");           
                    Broker user = _context.users
                        .OfType<Broker>()
                        .Where(broker => broker.UserId == ID)
                        .FirstOrDefault();

                    NewEvent.Broker = user;
                    NewEvent.BrokerId = user.UserId;
                    user.Events.Add(NewEvent);

                    _context.events.Add(NewEvent);
                    thisListing.Events.Add(NewEvent);

                    _context.SaveChanges();
                    return Redirect ("/dashboard");                
                }
            }
            return View ("AddEvents");
        }

        [HttpGet("add-listings")]
        public IActionResult AddListingTemp()
        {
            return View ("AddListing");
        }

        [HttpPost("add-listings")]
        public IActionResult CreateListing(Listing NewListing)
        {
            if (ModelState.IsValid)
            {
                int? ID = HttpContext.Session.GetInt32("userid");           

                Broker user = _context.users
                    .OfType<Broker>()
                    .Where(broker => broker.UserId == ID)
                    .FirstOrDefault();
                
                //Add listing to db
                NewListing.Broker = user;
                NewListing.BrokerId = user.UserId;
                NewListing.Events = new List<Event>();
                _context.listings.Add(NewListing);

                // add to broker's listings
                user.Listings.Add(NewListing);
                _context.SaveChanges();

                return Redirect ("/dashboard");
            }
            else
            {
                return View ("AddListing");
            }
        }
        
        [HttpGet("remove/listing/{ListingId}")]
        public IActionResult RemoveListing (string ListingId)
        {
            if(Int32.TryParse(ListingId, out int id))
            {
                Listing listingToDelete = _context.listings
                    .FirstOrDefault(listing => listing.ListingId == id);

                if(listingToDelete.BrokerId == HttpContext.Session.GetInt32("userid"))
                {
                    _context.listings.Remove(listingToDelete);
                }
            }
            return Redirect("/dashboard");
        }
        [HttpGet("remove/event/{EventId}")]
        public IActionResult RemoveEvent (string EventId)
        {
            if(Int32.TryParse(EventId, out int id))
            {
                Event eventToDelete = _context.events
                    .FirstOrDefault(eve => eve.EventId == id);

                if(eventToDelete.BrokerId == HttpContext.Session.GetInt32("userid"))
                {
                    _context.events.Remove(eventToDelete);
                }
            }
            return Redirect("/dashboard");
        }
    }
}
