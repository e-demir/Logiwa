using LogiwaAPI.Context;
using LogiwaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category EditCategory(Category category)
        {
            var existingcategory = _context.Categories.Find(category.CategoryId);
            if (existingcategory != null)
            {
                existingcategory.CategoryTitle = category.CategoryTitle;
                existingcategory.CategoryQuantity = category.CategoryQuantity;
                existingcategory.CategoryId = category.CategoryId;
                _context.Categories.Update(existingcategory);
                _context.SaveChanges();
            }

            return category;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }
    }
}
