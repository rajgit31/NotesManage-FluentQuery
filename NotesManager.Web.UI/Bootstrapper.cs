using System.Configuration;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NotesManager.Web.UI.BusinessServices;
using NotesManager.Web.UI.DataRepos;
using NotesManager.Web.UI.DomainModels;
using Unity.Mvc4;

namespace NotesManager.Web.UI
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }
        
    public static void RegisterTypes(IUnityContainer container)
    {
        string connectionStringName = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        container.RegisterType<IDbContext, EfDbContext>(new InjectionConstructor(connectionStringName));
        container.RegisterType<IUnitOfWork, UnitOfWork>();
        container.RegisterType<INotesQuery, EfNotesQuery>();
        container.RegisterType(typeof(IWriteRepository<>), typeof(EfWriteRepository<>));
        container.RegisterType<INotesService, NotesService>();
    }
  }
}