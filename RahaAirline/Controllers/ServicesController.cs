using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Services;

namespace RahaAirline.Controllers
{
    public class ServicesPageController : Controller
    {
        private IServiceRepository serviceRepository;
        RahaAirlineContext db=new RahaAirlineContext();

        public ServicesPageController()
        {
            serviceRepository=new ServiceRepository(db);
        }
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Service()
        {
            return PartialView(serviceRepository.GetAllServices());
        }
    }
}