using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Infinterest.Models
{
    public class Context : DbContext
    {
    // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Listing> listings { get; set; }
        public DbSet<Address> address { get; set; }
        public DbSet<Event> events { get; set; }

        public DbSet<Area> areas {get;set;}
        public DbSet<Business> business {get;set;}

        public DbSet<VendorToEvent> eventvendors {get;set;}


// create seeds
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
// many to many
// confimed vendors
            modelBuilder.Entity<VendorToEvent>()
                .HasKey(x => new { x.VendorId, x.EventId });

            modelBuilder.Entity<VendorToEvent>()
                .HasOne<Event>(s => s.Event)
                .WithMany(c => c.EventVendors)
                .HasForeignKey(y => y.VendorId);
            
            modelBuilder.Entity<VendorToEvent>()
                .HasOne<Vendor>(s => s.Vendor)
                .WithMany(c => c.Events)
                .HasForeignKey(y => y.EventId);


            modelBuilder.Entity<Area>().HasData(
                new Area() { AreaId = 1, area = "Basement" },
                new Area() { AreaId = 2, area = "Bathroom" },
                new Area() { AreaId = 3, area = "Bedroom" },
                new Area() { AreaId = 4, area = "Dining Room" },
                new Area() { AreaId = 5, area = "Family / Media Room" },
                new Area() { AreaId = 6, area = "Garage" },
                new Area() { AreaId = 7, area = "Kitchen" },
                new Area() { AreaId = 8, area = "Living Room" },
                new Area() { AreaId = 9, area = "Office" },
                new Area() { AreaId = 10, area = "Patio" },
                new Area() { AreaId = 11, area = "Yard" },
                new Area() { AreaId = 12, area = "Other" }
            );

            modelBuilder.Entity<Business>().HasData(
                new Business() { BusinessId = 1, business = "Art" },
                new Business() { BusinessId = 2, business = "Baby and Kids" },
                new Business() { BusinessId = 3, business = "Entertainment and Music" },
                new Business() { BusinessId = 4, business = "Fashion and Apparel" },
                new Business() { BusinessId = 5, business = "Food/Nutrition and Beverage" },
                new Business() { BusinessId = 6, business = "Furnishings" },
                new Business() { BusinessId = 7, business = "Health and Wellness" },
                new Business() { BusinessId = 8, business = "Home Based Business" },
                new Business() { BusinessId = 9, business = "Interior Design" },
                new Business() { BusinessId = 10, business = "Jewelery" },
                new Business() { BusinessId = 11, business = "Landscapers and Contractors" },
                new Business() { BusinessId = 12, business = "Pets and Animals" },
                new Business() { BusinessId = 13, business = "Photographers" },
                new Business() { BusinessId = 14, business = "Technology and Security" },
                new Business() { BusinessId = 15, business = "Wedding" },
                new Business() { BusinessId = 16, business = "Other" }
            );
        //     // Configure User, Broker, and Vendor entity
        //     modelBuilder.Entity<User>()
        //                 .HasOptional(u => u.Vendor) // Mark Vendor and Broker properties optional in User entity
        //                 .HasOptional(u => u.Broker)
        //                 .WithRequired(b => b.User)
        //                 .WithRequired(v => v.User); // mark Broker and Vendor properties as required in User entity. Cannot save Broker or Vendor without User
        
        // modelBuilder.Entity<Broker>().HasData(
        //         new Broker() 
        //         {
        //             UserId = 1,
        //             FirstName = "Josh",
        //             LastName = "McGee",
        //             ImgUrl = "../images/headshot2.jpg",
        //             Company = "Remax",
        //             Bio ="Working in Seattle and the Eastside for 20 years.",
        //             Contact = "(206)708-6836"
        //         }
        //     );
        // modelBuilder.Entity<Listing>().HasData(
        //         new Listing() 
        //         {
        //             ListingId = 1,
                    
        //         }
        //     );
        // modelBuilder.Entity<Event>().HasData(
        //         new Event() 
        //         {
                    
        //         }
        //     );
        }


    }
}
        