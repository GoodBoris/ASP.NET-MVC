using System.Configuration;
using Autofac;
using Autofac.Integration.Wcf;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.EF;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Identity;
using PhotoAlbum.DAL.Interfaces;
using PhotoAlbum.DAL.Repositories;

namespace Service
{
    public class AutofacConfig
    {
        public static void RegisterDependencys()
        {
            var builder = new ContainerBuilder();

            //Services instance
            builder.RegisterType<MembershipService>().InstancePerLifetimeScope();
            builder.RegisterType<PhotoAlbumService>().InstancePerLifetimeScope();
            builder.RegisterType<FileTransferService>().InstancePerLifetimeScope();

            //DAL dependencys
            builder.Register(c => new ApplicationContext(ConfigurationManager.ConnectionStrings["PhotoAlbum"].ConnectionString))
                .As<IdentityDbContext<ApplicationUser>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ClientManager>().As<IClientManager>().InstancePerLifetimeScope();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Entity<>)).As(typeof(IEntity<>)).InstancePerLifetimeScope();
            builder.RegisterType<IdentityUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<IdentityUnitOfWork>().As<IUserRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserManager<ApplicationUser>>().As<UserManager<ApplicationUser>>()
                .InstancePerLifetimeScope();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<IdentityDbContext<ApplicationUser>>()))
                .As<IUserStore<ApplicationUser>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApplicationRoleManager<ApplicationRole>>().As<RoleManager<ApplicationRole>>()
                .InstancePerLifetimeScope();
            builder.Register(c => new RoleStore<ApplicationRole>(c.Resolve<IdentityDbContext<ApplicationUser>>()))
                .As<IRoleStore<ApplicationRole, string>>()
                .InstancePerLifetimeScope();


            AutofacHostFactory.Container = builder.Build();
        }
    }
}