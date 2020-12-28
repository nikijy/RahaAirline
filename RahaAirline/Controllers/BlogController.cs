using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RahaAirline.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private IPageRepository pageRepository;
        private ICategoryRepository categoryRepository;
        RahaAirlineContext db = new RahaAirlineContext();
       

        public BlogController()
        {
            categoryRepository = new CategoryRepository(db);
            pageRepository=new PageRepository(db);
            
        }

        public ActionResult Index(int pageid = 1)
        {
            int skip = (pageid - 1) * 8;

            int Count = pageRepository.PageCounts();
            ViewBag.PageID = pageid;
            ViewBag.PageCount = Count / 8;

            var list = pageRepository.BlogPagging().Skip(skip).Take(8).ToList();
            return View(list);
         
        }

       
    }
}