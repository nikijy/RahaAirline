using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DataLayer.ViewModels;

namespace DataLayer
{
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(int pageId);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        void Save();

        IEnumerable<Page> BlogsInSlider();
        IEnumerable<Page> ShowBlogByCategoryId(int categoryId);
        IEnumerable<Page> SearchBlog(string search);
        int PageCounts();
        IEnumerable<Page> BlogPagging();


    }
}
