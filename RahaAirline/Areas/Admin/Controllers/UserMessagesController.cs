using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace RahaAirline.Areas.Admin.Controllers
{
    [Authorize(Users = "admin@example.com")]
    public class UserMessagesController : Controller
    {
        private IUserMessageRepository userMessageRepository;
        RahaAirlineContext db=new RahaAirlineContext();

        public UserMessagesController()
        {
            userMessageRepository=new UserMessageRepository(db);
        }
       
        public ActionResult Index()
        {
            return View(userMessageRepository.GetAllUserMessages());
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMessage userMessage = userMessageRepository.GetUserMessageById(id.Value);
            if (userMessage == null)
            {
                return HttpNotFound();
            }
            return View(userMessage);
        }

        // POST: Admin/UserMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMessage userMessage = userMessageRepository.GetUserMessageById(id);
            userMessageRepository.DeleteUserMessage(userMessage);
            userMessageRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult ShowMessageInNav()
        {
            return PartialView(userMessageRepository.GetAllUserMessages());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userMessageRepository.Dispose();
                
            }
            base.Dispose(disposing);
        }


    }
}
