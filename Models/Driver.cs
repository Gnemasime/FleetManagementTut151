using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetManagementTut151.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string LicenseType { get; set; }
        public int AssignedTruckId { get; set; }
        public int DriverPoints { get; set; }
        public decimal DriverEearnings { get; set; }
    }
}