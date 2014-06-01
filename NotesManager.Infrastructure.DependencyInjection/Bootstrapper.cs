using System;
using System.Configuration;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NotesManager.Business.Interfaces;
using NotesManager.Business.Services;
using NotesManager.Domain.Interfaces;
using NotesManager.Domain.Interfaces.Data;
using NotesManager.Infrastructure.Data;
using Unity.Mvc4;

namespace NotesManager.Infrastructure.DependencyInjection
{
    public class Bootstrapper
    {
        private static IUnityContainer _container;

        static Bootstrapper()
        {
            if (_container == null)
            {
                _container = BuildUnityContainer();    
            }
            
        }

        private static string ConnectionString { get; set; }

        public static void Initialise()
        {
            if (_container == null)
            {
                _container = BuildUnityContainer();
            }
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));
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
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            container.RegisterType<IDbContext, EfDbContext>(new InjectionConstructor(connectionString));
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IQueries, Queries>();
            container.RegisterType<INotesQuery, EfNotesQuery>();
            container.RegisterType(typeof(IWriteRepository<>), typeof(EfWriteRepository<>));

            container.RegisterType<INotesService, NotesService>();
        }

        public static void RegisterType(Type typeFrom, Type typeTo)
        {
            _container.RegisterType(typeFrom, typeTo);
        }

        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}