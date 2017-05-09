using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime? PostedOn { get; set; } 

        public bool Published { get; set; }

        [DefaultValue(0)]
        public int Likes { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
        }
    }
}
