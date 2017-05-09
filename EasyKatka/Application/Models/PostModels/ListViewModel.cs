using Domain.Entities;
using System.Collections.Generic;

namespace Application.Models.PostModels
{
    public class ListViewModel
    {
        public IList<Post> Posts { get; set; }
        public IList<Category> Category { get; set; }

        public ListViewModel()
        {
            Posts = new List<Post>();
        }

        public static ListViewModel GetViewModel(IList<Post> posts, IList<Category> category)
        {
            return new ListViewModel
            {

            };
        }
    }
}