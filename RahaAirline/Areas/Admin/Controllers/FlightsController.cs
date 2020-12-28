using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace RahaAirline.Areas.Admin.Controllers
{
    [Authorize(Users = "admin@example.com")]
    public class FlightsController : Controller
    {
        private RahaAirlineContext db = new RahaAirlineContext();

        // GET: Admin/Flights
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.FlightClass);
            return View(flights.ToList());
        }

        // GET: Admin/Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Admin/Flights/Create
        public ActionResult Create()
        {
            ViewBag.FlightClassID = new SelectList(db.FlightClasses, "FlightClassID", "FlightClassKind");
            return View();
        }

        // POST: Admin/Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightID,FlightClassID,From,Destination" +
                                                   ",CompanyName,Departure,Price,DepartureTime,Capacity")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightClassID = new SelectList(db.FlightClasses, "FlightClassID",
                "FlightClassKind", flight.FlightClassID);
            return View(flight);
        }

        // GET: Admin/Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightClassID = new SelectList(db.FlightClasses, "FlightClassID", "FlightClassKind", flight.FlightClassID);
            return View(flight);
        }

        // POST: Admin/Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightID,FlightClassID,From,Destination,CompanyName,Departure,Price,DepartureTime,Capacity")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightClassID = new SelectList(db.FlightClasses, "FlightClassID", "FlightClassKind", flight.FlightClassID);
            return View(flight);
        }

        // GET: Admin/Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Admin/Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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
