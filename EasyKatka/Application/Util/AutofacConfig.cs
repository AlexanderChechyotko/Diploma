using Autofac;
using Autofac.Integration.Mvc;
using BLL.Intefaces;
using BLL.Security;
using BLL.Servises;
using DAL.ApplicatinContext;
using DAL.Repositories;
using DAL.UnitOfWork;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Mvc;

namespace Application.Util
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterDbContext(builder);
            RegisterRepositories(builder);
            RegisterUnitOfWork(builder);
            RegisterServices(builder);
            RegisterManagers(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterDbContext(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).SingleInstance();
        }

        private static void RegisterUnitOfWork(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<ProfileService>().As<IProfileService>().SingleInstance();
            builder.RegisterType<PostService>().As<IPostService>().SingleInstance();
            builder.RegisterType<CommentService>().As<ICommentService>().SingleInstance();
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<TagService>().As<ITagService>().SingleInstance();
            builder.RegisterType<AuctionService>().As<IAuctionService>().SingleInstance();
        }

        private static void RegisterManagers(ContainerBuilder builder)
        {
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>().SingleInstance();
            builder.RegisterType<RoleStore<ApplicationRole>>().AsSelf().SingleInstance();

            builder.RegisterType<ApplicationUserManager>().AsSelf().SingleInstance();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().SingleInstance();
        }
    }
}