using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.PostModels
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }

        public static EditPostViewModel GetViewModel(Post domainModel)
        {
            return new EditPostViewModel
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                ShortDescription = domainModel.ShortDescription,
                Description = domainModel.Description,
                Category = domainModel.CategoryId
            };
        }

        public static Post GetDomainModel(EditPostViewModel model)
        {
            return new Post
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                AddedOn = DateTime.Today,
                CategoryId = model.Category
            };
        }
    }
}