using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace RahaAirline.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        private IResidenceRepository residenceRepository;
        private IFlightRepository flightRepository;
        RahaAirlineContext db = new RahaAirlineContext();

        public SearchController()
        {
            pageRepository = new PageRepository(db);
            residenceRepository = new ResidenceRepository(db);
            flightRepository = new FlightRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.SearchBlog(q));
        }

        public ActionResult SearchResidence(string q)
        {
            if (q == "")
            {
                ViewBag.message = "موردی یافت نشد";
            }
            return View(residenceRepository.SearchResidence(q));
        }

        public ActionResult SearchFlight(string from, string destination, string departure)
        {
            if (from == "" || destination == "" || departure == "")
            {
                ViewBag.message = "موردی یافت نشد";
            }
            return View(flightRepository.SearchFlights(from, destination, departure));
        }
    }
}