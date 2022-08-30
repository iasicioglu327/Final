using Autofac;
using BlogPage.Core.Repositories;
using BlogPage.Core.Services;
using BlogPage.Core.UnitofWorks;
using BlogPage.Repository;
using BlogPage.Repository.Repositories;
using BlogPage.Repository.UnitofWork;
using BlogPage.Service.Mapping;
using BlogPage.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace NLayer.Web.Modules
{
    public class RepoServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitofWork>().As<IUnitofWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();




        }
    }
}