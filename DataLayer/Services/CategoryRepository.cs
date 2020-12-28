using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoryRepository:ICategoryRepository
    {
        private RahaAirlineContext db;

        public CategoryRepository(RahaAirlineContext context)
        {
            db = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public bool InsertCategory(Category category)
        {
            try
            {
                db.Categories.Add(category);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                var category = GetCategoryById(categoryId);
                DeleteCategory(category);
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

        public IEnumerable<ShowCategoriesInViews> GetCategoriesForView()
        {
            return db.Categories.Select(C => new ShowCategoriesInViews()
            {
                CategoryID = C.CategoryID,
                Title = C.Title,
                PageCount = C.Pages.Count
            });
        }
    }
}
