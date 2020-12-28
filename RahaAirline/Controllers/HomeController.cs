using System.Web.Mvc;
using DataLayer;
using DataLayer.Services;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {

        private IPageRepository pageRepository;
        private IResidenceRepository residenceRepository;
        private IPlaceRepository placeRepository;
        private ICommentRepository commentRepository;
        private IServiceRepository serviceRepository;
    
        RahaAirlineContext db = new RahaAirlineContext();

        public HomeController()
        {
            pageRepository = new PageRepository(db);
            residenceRepository = new ResidenceRepository(db);
            placeRepository = new PlaceRepository(db);
            commentRepository = new CommentRepository(db);
            serviceRepository = new ServiceRepository(db);
           
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult Main()
        {
            return View();
        }


        public ActionResult SearchForFlight()
        {
            return View();
        }

        public ActionResult ShowBlog()
        {
            return PartialView(pageRepository.BlogsInSlider());
        }

        public ActionResult ShowPopularHotels()
        {
            return PartialView(residenceRepository.TopResidences());
        }

        public ActionResult ShowPopularPlaces()
        {
            return PartialView(placeRepository.TopPlaces());
        }

        public ActionResult AboutUs()
        {
            return PartialView();
        }

        public ActionResult Services()
        {
            return PartialView(serviceRepository.GetAllServices());
        }

        public ActionResult ShowComments()
        {
            return PartialView(commentRepository.CommentsInView());
        }


       
      
    }
}
