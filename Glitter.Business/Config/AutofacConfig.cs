using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Glitter.DataAccess.Concrete;
using System.Data.Entity;
using Glitter.DataAccess.Abstract;
using IContainer = Autofac.IContainer;
using Glitter.DataAccess.Services;
using Business.Concrete;
using Business.Abstract;

namespace Glitter.API.Config
{
    public class AutofacConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config,
            RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(
        HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver =
            new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(
            Assembly.GetExecutingAssembly())
            .PropertiesAutowired();


            //EF DbContext
            builder.RegisterType<EFDbContext>()
            .As<DbContext>().InstancePerLifetimeScope();

            //Repositories
            // Register repositories by using Autofac's OpenGenerics feature

            builder.RegisterGeneric(typeof(EntityRepository<>))
            .As(typeof(IEntityRepository<>))
            .InstancePerLifetimeScope();


            //Services

            builder.RegisterType<GlitterService>()
            .As<IGlitterService>()
            .InstancePerRequest();

            builder.RegisterType<MembershipService>()
            .As<IMembershipService>()
            .InstancePerRequest();

            builder.RegisterType<CryptoService>()
            .As<ICryptoService>()
            .InstancePerRequest();

            //Managers

            builder.RegisterType<TweetManager>()
          .As<ITweetManager>()
          .InstancePerRequest();

            builder.RegisterType<UserManager>()
          .As<IUserManager>()
          .InstancePerRequest();


            builder.RegisterType<FollowManager>()
         .As<IFollowManager>()
         .InstancePerRequest();

            builder.RegisterType<HashtagManager>()
       .As<IHashtagManager>()
       .InstancePerRequest();






            return builder.Build();

        }
    }
}
