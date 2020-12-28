using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RahaAirline.Controllers
{
    public class FlightController : Controller
    {
        private IFlightRepository flightRepository;
        private IFlightReserveRepository flightReserveRepository;
    
        RahaAirlineContext db = new RahaAirlineContext();
        ApplicationUser application = new ApplicationUser();
        IdentityDbContext context = new IdentityDbContext();
        public FlightController()
        {
            flightRepository = new FlightRepository(db);
            flightReserveRepository = new FlightReserveRepository(db);
           
        }
        // GET: Flight
        public ActionResult Index()
        {
            return View(flightRepository.GetAllFlights());
        }





        [Authorize]
        public ActionResult Payment(int id,string q, string name,int? passenger)
        {
            if (passenger == null)
            {
                TempData["message"] = "لطفا اطلاعات خواسته شده را تکمیل کنید";
                //return RedirectToAction("SearchFlight", "Search", new { @id = id });
                return RedirectToAction("SearchFlight", "Search",new {@q = UrlParameter.Optional.Equals(q)});
            }


            name = User.Identity.Name;
            var flight = flightRepository.GetFlightById(id);

            FlightReserve flightReserve = new FlightReserve();
            flightReserve.DateTime = DateTime.Now.ToString();
            flightReserve.IsFinally = false;
            flightReserve.Price = (flight.Price)*passenger.Value;
            flightReserve.FlightID = flight.FlightID;
            flightReserve.UserID = name;
            flightReserve.Passengers = passenger.Value;

            flightReserveRepository.InsertFlightReserve(flightReserve);
            flightReserveRepository.Save();
            flight.Capacity -= passenger.Value;
            flightRepository.UpdateFlight(flight);
            flightRepository.Save();

            System.Net.ServicePointManager.Expect100Continue = false;

            RahaAirline.ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp =
                new RahaAirline.ZarinPal.PaymentGatewayImplementationServicePortTypeClient();
            string Authority;

            int Status = zp.PaymentRequest("YOUR-ZARINPAL-MERCHANT-CODE", flightReserve.Price,
                " درگاه پرداخت زرین پال ", "nikitmb2@gmail.com", "09356821874",
                "http://localhost:58820/Flight/Verify/" + flightReserve.ReserveID, out Authority);

            if (Status == 100)
            {
                // Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
               Response.Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
              
            } 
            else
            {
                ViewBag.Error = "Error : " + Status;
            }

            return View();
        }




        public ActionResult Verify(int id)
        {
            
            var reserve = flightReserveRepository.GetFlightReserveById(id);

            if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
            {
                if (Request.QueryString["Status"].ToString().Equals("OK"))
                {

                    int Amount = reserve.Price;
                    long RefID;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    RahaAirline.ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new RahaAirline.ZarinPal.PaymentGatewayImplementationServicePortTypeClient();

                    int Status = zp.PaymentVerification("YOUR-ZARINPAL-MERCHANT-CODE", Request.QueryString["Authority"].ToString(), Amount, out RefID);

                    if (Status == 100)
                    {
                        reserve.IsFinally = true;
                        flightReserveRepository.Save();
                        ViewBag.IsSuccess = true;
                        ViewBag.RefId = RefID;
                        // Response.Write("Success!! RefId: " + RefID);
                    }
                    else
                    {
                        ViewBag.Status = Status;
                    }

                }
                else
                {
                    Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
                }
            }
            else
            {
                Response.Write("Invalid Input");
            }
            return View();
        }
    }
}