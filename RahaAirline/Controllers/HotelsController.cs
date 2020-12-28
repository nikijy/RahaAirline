using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RahaAirline.Controllers
{
    public class HotelsController : Controller
    {
        RahaAirlineContext db = new RahaAirlineContext();
        private ICategoryRepository categoryRepository;
        private IResidenceRepository residenceRepository;
        private IPageRepository pageRepository;
        public HotelsController()
        {
            categoryRepository = new CategoryRepository(db);
            residenceRepository=new ResidenceRepository(db);
            pageRepository=new PageRepository(db);
        }
        // GET: Hotels
        public ActionResult Index(int residenceid=1)
        {
            int skip = (residenceid - 1) * 8;

            int Count = residenceRepository.ResidenceCounts();
            ViewBag.ResidenceID = residenceid;
            ViewBag.ResidenceCount = Count / 8;

            var list = residenceRepository.ResidencePagging().Skip(skip).Take(8).ToList();
            return View(list);

            //return View();
        }

       
        public ActionResult ShowCategories() 
        {
            return PartialView(categoryRepository.GetCategoriesForView());
        }

        public ActionResult FindFlights()
        {
            return View();
        }
    }
}