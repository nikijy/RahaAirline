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
    public class ResidenceTypesController : Controller
    {
        private IResidenceTypeRepository residenceTypeRepository;
        RahaAirlineContext db = new RahaAirlineContext();
        public ResidenceTypesController()
        {
            residenceTypeRepository = new ResidenceTypeRepository(db);
        }
        // GET: Admin/ResidenceTypes
        public ActionResult Index()
        {
            return View(residenceTypeRepository.GetAllResidenceTypes());
        }

        // GET: Admin/ResidenceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidenceType residenceType = residenceTypeRepository.GetResidenceTypeById(id.Value);
            if (residenceType == null)
            {
                return HttpNotFound();
            }
            return View(residenceType);
        }

        // GET: Admin/ResidenceTypes/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/ResidenceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResidenceTypeID,ResidenceKind")] ResidenceType residenceType)
        {
            if (ModelState.IsValid)
            {
                residenceTypeRepository.InsertResidenceType(residenceType);
                residenceTypeRepository.Save();
                return RedirectToAction("Index");
            }

            return View(residenceType);
        }

        // GET: Admin/ResidenceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidenceType residenceType = residenceTypeRepository.GetResidenceTypeById(id.Value);
            if (residenceType == null)
            {
                return HttpNotFound();
            }
            return PartialView(residenceType);
        }

        // POST: Admin/ResidenceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResidenceTypeID,ResidenceKind")] ResidenceType residenceType)
        {
            if (ModelState.IsValid)
            {
                residenceTypeRepository.UpdateResidenceType(residenceType);
                residenceTypeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(residenceType);
        }

        // GET: Admin/ResidenceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidenceType residenceType = residenceTypeRepository.GetResidenceTypeById(id.Value);
            if (residenceType == null)
            {
                return HttpNotFound();
            }
            return PartialView(residenceType);
        }

        // POST: Admin/ResidenceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            residenceTypeRepository.DeleteResidenceType(id);
            residenceTypeRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                residenceTypeRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
