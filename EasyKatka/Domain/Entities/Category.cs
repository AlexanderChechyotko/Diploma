using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public Category()
        {
            Posts = new List<Post>();
        }

    }
}
