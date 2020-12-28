using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace RahaAirline.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        private ICommentRepository commentRepository;
        private IResidenceRepository residenceRepository;
        RahaAirlineContext db=new RahaAirlineContext();

        public AboutUsController()
        {
            commentRepository=new CommentRepository(db);
            residenceRepository=new ResidenceRepository(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return PartialView();
        }

        public ActionResult ShowCommentsInAbout()
        {
            return PartialView(commentRepository.CommentsInView());
        }

        public ActionResult ShowPopularHotelsInAbout()
        {
            return PartialView(residenceRepository.TopResidences());
        }
    }
}