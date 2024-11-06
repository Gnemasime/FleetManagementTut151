using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetManagementTut151.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public int TruckId { get; set; }
        //FK
        public virtual Truck Truck { get; set; }
        //FK
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal LoadWeight { get; set; }
        public bool IsCompleted { get; set; }
        public int Ratings { get; set; }

        //AddDeliveryPoints
        public void AddDeliveryPoints()
        {
            FleetContext db = new FleetContext();
            Driver driver = (from d in db.drivers
                             where d.DriverId == DriverId
                             select d).FirstOrDefault();

            //award 50 points for every completed delivery
            driver.DriverPoints += 50;
            db.SaveChanges();
        }

        FleetContext db = new FleetContext();
        //method to pull driver points
        public int PullDriverPoints()
        {
            var points = (from p in db.drivers
                          where p.DriverId == DriverId
                          select p.DriverPoints).FirstOrDefault();
            return points;
        }

        //method to calculate driver earnings
        public decimal CalcDriverEarnings()
        {
            if(PullDriverPoints() >=1000)
            {
                return (PullDriverPoints() / 1000) * 500;
            }
            else
            {
                return 0;
            }
        }

        //method to pull rate per load
        public decimal PullRatePerLoad()
        {
            var rate = (from r in db.trucks
                        where r.TruckId == TruckId
                        select r.RatePerLoad).FirstOrDefault();
            return rate;
        }

        //Method for calculating delivery earnings
        public decimal CalcDeliveryEarnings()
        {
            return LoadWeight * PullRatePerLoad();
        }

        public decimal ApplyRatingPenalty()
        {
            if(Ratings > 1 && Ratings < 3)
            {
                return CalcDriverEarnings() - (CalcDriverEarnings() * (5 / 100.0m));
            }
            else
            {
                return CalcDriverEarnings();
            }
        }

        //Apply Rating Rewards
        public void ApplyRatingReward()
        {
            FleetContext db = new FleetContext();
            Driver driver = (from d in db.drivers
                             where d.DriverId == DriverId
                             select d).FirstOrDefault();

            if(Ratings > 4 && Ratings < 5)
            {
                driver.DriverPoints += 50;
            }

            db.SaveChanges();
        }
    }
}