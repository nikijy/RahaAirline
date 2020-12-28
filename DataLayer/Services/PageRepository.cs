using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository:IPageRepository
    {

        private RahaAirlineContext db;

        public PageRepository(RahaAirlineContext context)
        {
            db = context;
        }
        public IEnumerable<Page> GetAllPage()
        {
            return db.Pages;
        }

        public Page GetPageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(int pageId)
        {
            try
            {
                var page = GetPageById(pageId);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> BlogsInSlider()
        {
            return db.Pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<Page> ShowBlogByCategoryId(int categoryId)
        {
            return db.Pages.Where(p => p.CategoryID == categoryId);
        }

        public IEnumerable<Page> SearchBlog(string search)
        {
            return
                db.Pages.Where(
                    p =>
                        p.Name.Contains(search) || p.ShortDescription.Contains(search) || p.Tag.Contains(search) ||
                        p.Text.Contains(search)).Distinct();
        }

        public int PageCounts()
        {
            return db.Pages.Count();
        }

        public IEnumerable<Page> BlogPagging()
        {
            return db.Pages.OrderBy(p => p.PageID);
        }
    }
    }

