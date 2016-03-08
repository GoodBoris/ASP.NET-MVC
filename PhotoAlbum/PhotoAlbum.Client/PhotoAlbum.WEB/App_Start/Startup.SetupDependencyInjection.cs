using System;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using Owin;
using PhotoAlbum.WEB.FileTransferService;
using PhotoAlbum.WEB.MembershipService;
using PhotoAlbum.WEB.PhotoService;

namespace PhotoAlbum.WEB
{
    public partial class Startup
    {
        private static void ConfigureDependencyInjection(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var executingAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(executingAssembly);
            RegisterChannels(builder);
            var container = builder.Build();
            RegisterMappings(container);
            app.UseAutofacMiddleware(container);
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
            app.UseAutofacMvc();
        }

        private static void RegisterChannels(ContainerBuilder builder)
        {
            builder.Register(c => new ChannelFactory<IMembershipService>(
                new BasicHttpBinding("MembershipService_binding"),
                new EndpointAddress(GetEndpointAddress("MembershipService")))).InstancePerLifetimeScope();
            builder
              .Register(c => c.Resolve<ChannelFactory<IMembershipService>>().CreateChannel())
              .As<IMembershipService>()
              .UseWcfSafeRelease();

            builder.Register(c => new ChannelFactory<IPhotoAlbumService>(
                new BasicHttpBinding("PhotoAlbumService_binding"),
                new EndpointAddress(GetEndpointAddress("PhotoService")))).InstancePerLifetimeScope();
            builder
              .Register(c => c.Resolve<ChannelFactory<IPhotoAlbumService>>().CreateChannel())
              .As<IPhotoAlbumService>()
              .UseWcfSafeRelease();

            builder
                .Register(c => new ChannelFactory<IFileTransferService>(
                    new BasicHttpBinding("FileTransferService_binding"),
                    new EndpointAddress(GetEndpointAddress("FileTransferService")))).InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<ChannelFactory<IFileTransferService>>().CreateChannel())
                .As<IFileTransferService>()
                .UseWcfSafeRelease();
        }
        #region helpers

        private static string GetEndpointAddress(string name)
        {
            var clientSection = WebConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            if (clientSection?.Endpoints != null)
                foreach (ChannelEndpointElement endpoint in clientSection.Endpoints.Cast<ChannelEndpointElement>()
                    .Where(endpoint => endpoint.Name == name))
                    return endpoint.Address.ToString();
            throw new NullReferenceException("There are no Endpoints in Web.config file");
        }

        #endregion
    }
}