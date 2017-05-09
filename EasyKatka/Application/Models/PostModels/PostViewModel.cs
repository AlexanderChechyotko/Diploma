using System;

namespace Application.Models.PostModels
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public string Author { get; set; }
        public int Likes { get; set; }
    }
}