using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using IdentitySample.Models;

namespace RahaAirline.Controllers
{
    public class HotelDetailsController : Controller
    {
        // GET: HotelDetails
        private IResidenceRepository residenceRepository;
        private ICommentRepository commentRepository;
        private ICategoryRepository categoryRepository;
        private IPageRepository pageRepository;
        private IReserveRepository reserveRepository;
        //User user=new User();
        RahaAirlineContext db = new RahaAirlineContext();
        ApplicationUser application = new ApplicationUser();
        public HotelDetailsController()
        {
            residenceRepository = new ResidenceRepository(db);
            commentRepository = new CommentRepository(db);
            categoryRepository = new CategoryRepository(db);
            pageRepository = new PageRepository(db);
            reserveRepository = new ReserveRepository(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowResidenceDetail(int id)
        {

            var residenceDetails = residenceRepository.GetResidenceById(id);

            if (residenceDetails == null)
            {
                return HttpNotFound();
            }

            residenceDetails.Visit += 1;
            residenceRepository.UpdateResidence(residenceDetails);
            residenceRepository.Save();

            return View(residenceDetails);
        }

        public ActionResult ShowCategories()
        {
            return PartialView(categoryRepository.GetCategoriesForView());
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            Comment addcomment = new Comment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                CommentText = comment,
                Email = email,
                Name = name
            };
            commentRepository.AddComment(addcomment);

            return PartialView("ShowComments", commentRepository.GetCommentByPageId(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(commentRepository.GetCommentByPageId(id));
        }






        //public ActionResult ShowTags(int id)
        //{
        //    return PartialView(pageRepository.GetPageById(id));
        //}


        [Route("Category/{id}/{title}")]
        public ActionResult ShowBlogsByCategoryId(int id, string title)
        {
            ViewBag.title = title;
            return View(pageRepository.ShowBlogByCategoryId(id));
        }





        [Authorize]
        public ActionResult Payment(int id, string name, int? passenger, int? roomNumber, string Checkin, string Checkout)
        {
            var Hotels = residenceRepository.GetResidenceById(id);
            if (passenger == null || roomNumber == null || Checkin=="" || Checkout=="")
            {
                TempData["message"] = "لطفا اطلاعات خواسته شده را تکمیل کنید";
                //  ModelState.AddModelError("", "لطفا اطلاعات خواسته شده را تکمیل کنید");
                return RedirectToAction("ShowResidenceDetail", "HotelDetails", new { @id = id });
            }

            name = User.Identity.Name;
            DateTime chin = DateTime.ParseExact(Checkin, "dd/MM/yyyy", null);
            DateTime chout = DateTime.ParseExact(Checkout, "dd/MM/yyyy", null);
            int chinint = int.Parse(chin.ToString("yyyyMMdd"));
            int choutint = int.Parse(chout.ToString("yyyyMMdd"));
            int days = choutint - chinint;


            Reserve reserve = new Reserve();

            reserve.Passengers = passenger.Value;
            reserve.RoomNumber = roomNumber.Value;
            reserve.CheckIn = Checkin;
            reserve.CheckOut = Checkout;
            reserve.DateTime = DateTime.Now.ToString();
            reserve.IsFinally = false;
            if (days > 0 && passenger.Value > 0 && roomNumber.Value > 0)
            {
                reserve.Price = (((Hotels.Price) * passenger.Value) * roomNumber.Value) * days;
            }
            else
            {
                TempData["message"] = "لطفا اطلاعات خواسته شده را به طور صحیح تکمیل کنید";
                return RedirectToAction("ShowResidenceDetail", "HotelDetails", new { @id = id });
            }
            reserve.ResidenceID = Hotels.ResidenceID;
            reserve.UserID = name;

            reserveRepository.InsertReserve(reserve);
            reserveRepository.Save();



            System.Net.ServicePointManager.Expect100Continue = false;

            RahaAirline.ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new RahaAirline.ZarinPal.PaymentGatewayImplementationServicePortTypeClient();
            string Authority;

            int Status = zp.PaymentRequest("YOUR-ZARINPAL-MERCHANT-CODE", reserve.Price,
                " درگاه پرداخت زرین پال ", "nikitmb2@gmail.com", "09356821874",
                "http://localhost:58820/HotelDetails/Verify/" + reserve.ReserveID, out Authority);

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
            var reserve = reserveRepository.GetReserveById(id);

            var Hotels = residenceRepository.GetResidenceById(id);


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
                        //  Hotels.IsAvailable = false;
                        // residenceRepository.Save();
                        reserve.IsFinally = true;
                        reserveRepository.Save();
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

