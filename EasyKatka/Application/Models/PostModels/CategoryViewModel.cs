using Domain.Entities;

namespace Application.Models.PostModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static CategoryViewModel GetViewModel(Category domainModel)
        {
            return new CategoryViewModel
            {
                Id = domainModel.Id,
                Name = domainModel.Name
            };
        }

        public static Category GetDomainModel(CategoryViewModel model)
        {
            return new Category
            {
                Name = model.Name
            };
        }
    }
}