using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FleetManagementTut151.Models
{
    public class FleetContext : DbContext
    {
        public FleetContext() : base("DefaultConnection") { }

        public DbSet<Driver> drivers { get; set; }
        public DbSet<Truck> trucks { get; set; }
        public DbSet<Delivery> deliveries { get; set; }
    }
}