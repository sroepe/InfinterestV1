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
                .Include(List => List.Address)
                .Include(lis => lis.Events)
                .ThenInclude(eve => eve.EventVendors)
                // .ThenInclude(ev => ev.Vendor)
                // for posting venor img or name, for now we're just counting
                .ToList();

            DisplayModel.AvailableVendors = _context.users
            .OfType<Vendor>()
            .ToList();

            return View("DashboardBroker", DisplayModel);
        
        }

        //Events and Listings
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
                    NewEvent.EventVendors = new List<VendorToEvent>();
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
                    return Redirect ("/listing-detail/" + id);                
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
        public IActionResult CreateListing(ListingForm UserInput)
        {
            if (ModelState.IsValid)
            {
                int? ID = HttpContext.Session.GetInt32("userid");           
                Broker user = _context.users
                    .OfType<Broker>()
                    .Where(use => use.UserId == ID)
                    .FirstOrDefault();
                if(user == null)
                {
                    //fake code
                    return Redirect("/notsignedin");
                }

                //Add address to db
                Address NewAddress = new Address(UserInput);
                _context.address.Add(NewAddress);
                _context.SaveChanges();

                //Add listing to db
                Listing NewListing = new Listing(UserInput, NewAddress);
                NewListing.Broker = user;
                NewListing.BrokerId = user.UserId;
                _context.listings.Add(NewListing);

                // add to broker's listings
                user.Listings.Add(NewListing);
                _context.SaveChanges();

                return Redirect ("/listing-detail/" + NewListing.ListingId);
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
        [HttpGet("test/listing/{ListingId}")]
        public IActionResult TestListing (string ListingId)
        {
            if(Int32.TryParse(ListingId, out int id))
            {
                Listing listingToTest = _context.listings
                        .Include(lis => lis.Address)
                        .FirstOrDefault(listing => listing.ListingId == id);
                return Redirect("/address/" + listingToTest.Address.postalCode);
            }
            else
            {
                return Redirect("/");
            }
        }
        [HttpGet("test/Address/{ListingId}")]
        public IActionResult TestAddress (string ListingId)
        {
            if(Int32.TryParse(ListingId, out int id))
            {
                Address listingToTest = _context.address
                        .FirstOrDefault(listing => listing.AddressId == id);
                return Redirect("/address/" + listingToTest.postalCode);
            }
            else
            {
                return Redirect("/");
            }
        }

        
        // interact with vendors
    }
}
