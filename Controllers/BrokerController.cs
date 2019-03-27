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
            DashboardBrokerView DisplayModel = new DashboardBrokerView();
// example only
            // DisplayModel.UsersListings = _context.brokers
            //                             .Where(broker => broker.BrokerId == 1)
            //                             .Include(broker => broker.listings)
            //                             .ToList();

            DisplayModel.AvailibleVendors = _context.vendors.ToList();

            
            return View(DisplayModel);
        }

        [Route("add-listings")]
        // will need to split into listings and events
        public IActionResult AddEvents()
        {
            return View();
        }
    }
}
