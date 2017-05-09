using BLL.Intefaces;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace BLL.Servises
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _uow.Categories.GetAll().ToArray();
        }

        public Category GetCategoryById(int id)
        {
            Category category = _uow.Categories.Get(id);
            return category;
        }
    }
}
