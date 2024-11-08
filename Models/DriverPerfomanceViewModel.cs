using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetManagementTut151.Models
{
    public class DriverPerfomanceViewModel
    {
        [Key]
        public int DriverViewModelId { get; set; }
        public string DriverNAme { get; set; }
        public string LicenseType { get; set; }
        public int PointsEarned { get; set; }
        public decimal TotalEarnings { get; set; }
        public int DeliveryRating { get; set; }
    }
}