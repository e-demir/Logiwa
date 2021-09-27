using LogiwaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaAPI.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();

        Category GetCategory(int id);

        Category AddCategory(Category category);

        void DeleteCategory(Category category);

        Category EditCategory(Category category);
    }
}
