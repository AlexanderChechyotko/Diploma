using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.PostModels
{
    public class CreatePostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Category { get; set; } 
        [Required]
        [MinLength(10)]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }

        public static CreatePostViewModel GetViewModel(Post domainModel)
        {
            return new CreatePostViewModel
            {
                Title = domainModel.Title,
                ShortDescription = domainModel.ShortDescription,
                Description = domainModel.Description
            };
        }

        public static Post GetDomainModel(CreatePostViewModel model, string userId)
        {
            return new Post
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                Published = false,
                AddedOn = DateTime.Today,
                UserId = userId,
                CategoryId = model.Category
            };
        }
    }
}