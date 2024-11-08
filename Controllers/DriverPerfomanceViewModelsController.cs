using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FleetManagementTut151.Models;

namespace FleetManagementTut151.Controllers
{
    public class DriverPerfomanceViewModelsController : Controller
    {
        private FleetContext db = new FleetContext();

        // GET: DriverPerfomanceViewModels
        public ActionResult Index()
        { 
            //  return View(db.driverPerfomances.ToList());
            List<DriverPerfomanceViewModel> driverPerfomances = new List<DriverPerfomanceViewModel>();
            var driver = (from dr in db.drivers
                          join deli in db.deliveries on dr.DriverId equals deli.DriverId
                          select new { dr.Name, dr.DriverPoints, dr.DriverEearnings, dr.LicenseType, deli.Ratings }).ToList();

            foreach(var drivers in driver)
            {
                DriverPerfomanceViewModel viewModel = new DriverPerfomanceViewModel();
                viewModel.DriverNAme = drivers.Name;
                viewModel.LicenseType = drivers.LicenseType;
                viewModel.PointsEarned = drivers.DriverPoints;
                viewModel.TotalEarnings = drivers.DriverEearnings;
                viewModel.DeliveryRating = drivers.Ratings;

                driverPerfomances.Add(viewModel);
            }

            return View(driverPerfomances);
        }

        // GET: DriverPerfomanceViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverPerfomanceViewModel driverPerfomanceViewModel = db.driverPerfomances.Find(id);
            if (driverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(driverPerfomanceViewModel);
        }

        // GET: DriverPerfomanceViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverPerfomanceViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverViewModelId,DriverNAme,LicenseType,PointsEarned,TotalEarnings,DeliveryRating")] DriverPerfomanceViewModel driverPerfomanceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.driverPerfomances.Add(driverPerfomanceViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverPerfomanceViewModel);
        }

        // GET: DriverPerfomanceViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverPerfomanceViewModel driverPerfomanceViewModel = db.driverPerfomances.Find(id);
            if (driverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(driverPerfomanceViewModel);
        }

        // POST: DriverPerfomanceViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverViewModelId,DriverNAme,LicenseType,PointsEarned,TotalEarnings,DeliveryRating")] DriverPerfomanceViewModel driverPerfomanceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverPerfomanceViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverPerfomanceViewModel);
        }

        // GET: DriverPerfomanceViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverPerfomanceViewModel driverPerfomanceViewModel = db.driverPerfomances.Find(id);
            if (driverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(driverPerfomanceViewModel);
        }

        // POST: DriverPerfomanceViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverPerfomanceViewModel driverPerfomanceViewModel = db.driverPerfomances.Find(id);
            db.driverPerfomances.Remove(driverPerfomanceViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
