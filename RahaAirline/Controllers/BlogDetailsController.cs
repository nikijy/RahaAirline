using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace RahaAirline.Controllers
{
    public class BlogDetailsController : Controller
    {
        private IPageRepository pageRepository;

        private ICategoryRepository categoryRepository;
        private ICommentRepository commentRepository;
        RahaAirlineContext db=new RahaAirlineContext();
        public BlogDetailsController()
        {
            pageRepository=new PageRepository(db);
            categoryRepository=new CategoryRepository(db);
            commentRepository=new CommentRepository(db);
        }
        // GET: BlogDetails
        public ActionResult Index()
        {
            return View();
        }
        [Route("BlogDetails/{id}")]
        public ActionResult ShowBlogDetail(int id)
        {

            var blogDetails = pageRepository.GetPageById(id);

            if (blogDetails == null)
            {
                return HttpNotFound();
            }

            blogDetails.Visit += 1;
            pageRepository.UpdatePage(blogDetails);
            pageRepository.Save();

            return View(blogDetails);
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
    }
}