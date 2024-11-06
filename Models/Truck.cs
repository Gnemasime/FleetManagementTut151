using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetManagementTut151.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        public string TruckType { get; set; }
        public int MaxCapacity { get; set; }
        public decimal CurrentMileage { get; set; }
        public decimal RatePerLoad { get; set; } = 200;
    }
}