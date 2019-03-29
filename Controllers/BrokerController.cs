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

        [HttpGet("brokerdashboard")]
        public IActionResult DashboardBroker()
        {
            return View ("DashboardBroker");
        }
//         {
             
//             DashboardBrokerView DisplayModel = new DashboardBrokerView();
// // example only

//             Broker user = _context.brokers
//                 .Where(broker => broker.UserId == 1)
//                 .FirstOrDefault();


//             DisplayModel.UsersListings = user.Listings;

//             DisplayModel.PendingEvents = user.Events
//                 .Where(thisEvent => thisEvent.Confimed == false)
//                 .ToList();

//             DisplayModel.FinalizedEvents = user.Events
//                 .Where(thisEvent => thisEvent.Confimed == true)
//                 .ToList();

//             DisplayModel.AvailibleVendors = _context.vendors.ToList();

//             // probably needs to account for being in a different controlelr
//             return View("DashboardBroker", DisplayModel);
            
//         }

        //temporary to show add event page
        [HttpGet("add-event")]
        public IActionResult AddEventTemp(String eventId)
        {
            return View ("AddEvents");
        }

        [Route("add-listings")]
        // will need to split into listings and events
        public IActionResult AddListing(Listing newListing)
        {
            // create listing
            return RedirectToAction("Dashboard");
        }
    }
}
