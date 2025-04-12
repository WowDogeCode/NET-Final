using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // DALs
            builder.RegisterType<EfProductDal>()
                   .As<IProductDal>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<EfCategoryDal>()
                   .As<ICategoryDal>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<EfUserDal>()
                   .As<IUserDal>()
                   .InstancePerLifetimeScope();

            // Managers
            builder.RegisterType<ProductManager>()
                   .As<IProductService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<CategoryManager>()
                   .As<ICategoryService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserManager>()
                   .As<IUserService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<AuthManager>()
                   .As<IAuthService>()
                   .InstancePerLifetimeScope();

            // JWT
            builder.RegisterType<JwtHelper>()
                   .As<ITokenHelper>()
                   .SingleInstance();

            // Redis
            builder.RegisterType<RedisCacheService>()
                   .As<ICacheService>()
                   .SingleInstance();

            // Interceptors
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions
                   {
                       Selector = new AspectInterceptorSelector()
                   })
                   .InstancePerLifetimeScope();
        }
    }
}
