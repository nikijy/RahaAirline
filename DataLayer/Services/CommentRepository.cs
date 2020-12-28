using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CommentRepository:ICommentRepository
    {
        private RahaAirlineContext db;

        public CommentRepository(RahaAirlineContext context)
        {
            db = context;
        }
        public IEnumerable<Comment> GetCommentByPageId(int pageId)
        {
            return db.Comments.Where(c => c.PageID == pageId);
        }



        public bool AddComment(Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Comment> CommentsInView(int take = 4)
        {
            return db.Comments.OrderByDescending(c => c.CommentID).Take(take);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return db.Comments;
        }
    }
}
