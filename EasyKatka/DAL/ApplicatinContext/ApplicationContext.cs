using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL.ApplicatinContext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new ApplicationInitializer());
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Auction> Auctions { get; set; }
    }
}
