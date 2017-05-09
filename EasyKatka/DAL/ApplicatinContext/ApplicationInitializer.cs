using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL.ApplicatinContext
{
    class ApplicationInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            ApplicationInitializer.InitializeRoles(context);
            ApplicationInitializer.InitializeCategories(context);
            ApplicationInitializer.InitializeTags(context);

            base.Seed(context);
        }

        private static void InitializeAuctions(ApplicationContext context)
        {
            Auction auction = new Auction
            {

            };
        }

        private static void InitializeRoles(ApplicationContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole() { Name = "admin" };
            var userRole = new IdentityRole() { Name = "user" };

            roleManager.Create(adminRole);
            roleManager.Create(userRole);
        }

        private static void InitializeCategories(ApplicationContext context)
        {
            Category c1 = new Category() { Name = "Автомобили" };
            Category c2 = new Category() { Name = "Путешествия" };
            Category c3 = new Category() { Name = "Информационные технологии" };

            context.Categories.Add(c1);
            context.Categories.Add(c2);
            context.Categories.Add(c3);
            context.SaveChanges();
        }

        private static void InitializeTags(ApplicationContext context)
        {
            Tag t1 = new Tag() { Name = "Tag1" };
            Tag t2 = new Tag() { Name = "Tag2" };
            Tag t3 = new Tag() { Name = "Tag3" };
            Tag t4 = new Tag() { Name = "Tag4" };
            Tag t5 = new Tag() { Name = "Tag5" };

            context.Tags.Add(t1);
            context.Tags.Add(t2);
            context.Tags.Add(t3);
            context.Tags.Add(t4);
            context.Tags.Add(t5);
            context.SaveChanges();
        }
    }
}
