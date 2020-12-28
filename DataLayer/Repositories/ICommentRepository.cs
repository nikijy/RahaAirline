using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentByPageId(int pageId);
        bool AddComment(Comment comment);


        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> CommentsInView(int take = 4);
    }
}
