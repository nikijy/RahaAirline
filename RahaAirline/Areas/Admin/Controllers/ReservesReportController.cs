using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace RahaAirline.Areas.Admin.Controllers
{
    public class ReservesReportController : Controller
    {
        RahaAirlineContext db=new RahaAirlineContext();

        private ReserveRepository reserve;
        private FlightReserveRepository flightReserve;


        public ReservesReportController()
        {
            reserve=new ReserveRepository(db);
            flightReserve=new FlightReserveRepository(db);
        }
        // GET: Admin/ReservesReport
        public ActionResult HotelReserveReport()
        {
            return View(reserve.GetAllReserves());
        }

        public ActionResult FlightReserveReport()
        {
            return View(flightReserve.GetAllFlightReserves());
        }
    }
}