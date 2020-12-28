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
    public class CategoriesController : Controller
    {
        private ICategoryRepository CategoryRepository;
        RahaAirlineContext db = new RahaAirlineContext();
        public CategoriesController()
        {
            CategoryRepository = new CategoryRepository(db);
        }


        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(CategoryRepository.GetAllCategories());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = CategoryRepository.GetCategoryById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.InsertCategory(category);
                CategoryRepository.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category =CategoryRepository.GetCategoryById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.UpdateCategory(category);
                CategoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = CategoryRepository.GetCategoryById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryRepository.DeleteCategory(id);
            CategoryRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CategoryRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
