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
    public class FlightClassesController : Controller
    {
        private IFlightClassRepository flightClassRepository;
        RahaAirlineContext db = new RahaAirlineContext();
        public FlightClassesController()
        {
            flightClassRepository = new FlightClassRepository(db);
        }

        // GET: Admin/FlightClasses
        public ActionResult Index()
        {
            return View(flightClassRepository.GetAllFlightClasses());
        }

        // GET: Admin/FlightClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightClass flightClass = flightClassRepository.GetFlightClassById(id.Value);
            if (flightClass == null)
            {
                return HttpNotFound();
            }
            return View(flightClass);
        }

        // GET: Admin/FlightClasses/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/FlightClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightClassID,FlightClassKind")] FlightClass flightClass)
        {
            if (ModelState.IsValid)
            {
                flightClassRepository.InsertFlightClass(flightClass);
                flightClassRepository.Save();
                return RedirectToAction("Index");
            }

            return View(flightClass);
        }

        // GET: Admin/FlightClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightClass flightClass = flightClassRepository.GetFlightClassById(id.Value);
            if (flightClass == null)
            {
                return HttpNotFound();
            }
            return PartialView(flightClass);
        }

        // POST: Admin/FlightClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightClassID,FlightClassKind")] FlightClass flightClass)
        {
            if (ModelState.IsValid)
            {
                flightClassRepository.UpdateFlightClass(flightClass);
                flightClassRepository.Save();
                return RedirectToAction("Index");
            }
            return View(flightClass);
        }

        // GET: Admin/FlightClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightClass flightClass = flightClassRepository.GetFlightClassById(id.Value);
            if (flightClass == null)
            {
                return HttpNotFound();
            }
            return PartialView(flightClass);
        }

        // POST: Admin/FlightClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            flightClassRepository.DeleteFlightClass(id);
            flightClassRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                flightClassRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
