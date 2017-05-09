using Domain.Entities;
using System.Collections.Generic;

namespace BLL.Intefaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
    }
}
