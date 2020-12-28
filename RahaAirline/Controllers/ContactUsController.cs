using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Message = System.ServiceModel.Channels.Message;

namespace RahaAirline.Controllers
{
    public class ContactUsController : Controller
    {
        private IUserMessageRepository userMessageRepository;
        RahaAirlineContext db = new RahaAirlineContext();

        public ContactUsController()
        {
            userMessageRepository = new UserMessageRepository(db);
        }
        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return PartialView();
        }




        public ActionResult Messages([Bind(Include = "MessageID,Name,Email,Subject,Text")] UserMessage userMessage)
        {
            if (ModelState.IsValid)
            {
                userMessageRepository.InsertUserMessage(userMessage);
                userMessageRepository.Save();
                return RedirectToAction("Messages");
            }
            return View(userMessage);
        }

    }
}