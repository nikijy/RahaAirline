using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace RahaAirline.Areas.Admin.Controllers
{
    [Authorize(Users = "admin@example.com")]
    public class ResidencesController : Controller
    {
        private IResidenceRepository residenceRepository;
        private IResidenceTypeRepository residenceTypeRepository;
        private RahaAirlineContext db = new RahaAirlineContext();

        public ResidencesController()
        {
            residenceRepository=new ResidenceRepository(db);
            residenceTypeRepository=new ResidenceTypeRepository(db);
        }
        // GET: Admin/Residences
        public ActionResult Index()
        {
           
            return View(residenceRepository.GetAllResidences());
        }

        // GET: Admin/Residences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = db.Residences.Find(id);
            if (residence == null)
            {
                return HttpNotFound();
            }
            return View(residence);
        }

        // GET: Admin/Residences/Create
        public ActionResult Create()
        {
            ViewBag.ResidenceTypeID = new SelectList(residenceTypeRepository.GetAllResidenceTypes(), "ResidenceTypeID", "ResidenceKind");
            return View();
        }

        // POST: Admin/Residences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResidenceID,ResidenceTypeID,Location,Image,CheckIn,CheckOut,Price,Visit,ShortDescription,Text,CreateDate,Tag")] Residence residence,HttpPostedFileBase imgResidence)
        {
            if (ModelState.IsValid)
            {
                residence.Visit = 0;
                residence.CreateDate = DateTime.Now;
                residence.CheckIn = DateTime.Now.ToString();
                residence.CheckOut = DateTime.Now.ToString();
                if (imgResidence != null)
                {
                    residence.Image = Guid.NewGuid() + Path.GetExtension(imgResidence.FileName);
                    imgResidence.SaveAs(Server.MapPath("/ResidenceImages/" + residence.Image));
                }
                residenceRepository.InsertResidence(residence);
                residenceRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ResidenceTypeID = new SelectList(residenceTypeRepository.GetAllResidenceTypes(), "ResidenceTypeID", "ResidenceKind", residence.ResidenceTypeID);
            return View(residence);
        }

        // GET: Admin/Residences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = residenceRepository.GetResidenceById(id.Value);
            if (residence == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResidenceTypeID = new SelectList(residenceTypeRepository.GetAllResidenceTypes(), "ResidenceTypeID", "ResidenceKind", residence.ResidenceTypeID);
            return View(residence);
        }

        // POST: Admin/Residences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResidenceID,ResidenceTypeID,Location,Image,CheckIn,CheckOut,Price,Visit,ShortDescription,Text,CreateDate,Tag")] Residence residence,HttpPostedFileBase imgResidence)
        {
            if (ModelState.IsValid)
            {
                if (imgResidence != null)
                {
                    if (residence.Image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/ResidenceImages/" + residence.Image));
                    }


                    residence.Image = Guid.NewGuid() + Path.GetExtension(imgResidence.FileName);
                    imgResidence.SaveAs(Server.MapPath("/ResidenceImages/" + residence.Image));
                }

                residenceRepository.UpdateResidence(residence);
                residenceRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ResidenceTypeID = new SelectList(residenceTypeRepository.GetAllResidenceTypes(), "ResidenceTypeID", "ResidenceKind", residence.ResidenceTypeID);
            return View(residence);
        }

        // GET: Admin/Residences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = residenceRepository.GetResidenceById(id.Value);
            if (residence == null)
            {
                return HttpNotFound();
            }
            return View(residence);
        }

        // POST: Admin/Residences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Residence residence =residenceRepository.GetResidenceById(id);
            if (residence.Image != null)
            {
                System.IO.File.Delete(Server.MapPath("/ResidenceImages/" + residence.Image));
            }
            residenceRepository.DeleteResidence(residence);
            residenceRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                residenceRepository.Dispose();
                residenceTypeRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
