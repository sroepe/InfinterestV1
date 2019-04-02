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
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<Broker> brokers { get; set; }
        public DbSet<Listing> listings { get; set; }
        public DbSet<Event> events { get; set; }


// create seeds
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConfimedVendors>()
                .HasKey(x => new { x.VendorId, x.EventId });

            modelBuilder.Entity<ConfimedVendors>()
                .HasOne<Event>(s => s.Event)
                .WithMany(c => c.ConfrimedVendors)
                .HasForeignKey(y => y.VendorId);
            
            modelBuilder.Entity<ConfimedVendors>()
                .HasOne<Vendor>(s => s.Vendor)
                .WithMany(c => c.ConfirmedEvents)
                .HasForeignKey(y => y.EventId);

            modelBuilder.Entity<PendingVendors>()
                .HasKey(x => new { x.VendorId, x.EventId });

            modelBuilder.Entity<PendingVendors>()
                .HasOne<Event>(s => s.Event)
                .WithMany(c => c.RequestedVendors)
                .HasForeignKey(y => y.VendorId);
            
            modelBuilder.Entity<PendingVendors>()
                .HasOne<Vendor>(s => s.Vendor)
                .WithMany(c => c.RequestedEvents)
                .HasForeignKey(y => y.EventId);
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
        