using Autofac;
using Autofac.Integration.Mvc;
using CsharpAssignment.Business.Handlers;
using CsharpAssignment.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CsharpAssignment.App_Start
{
    public class AppStartConfig
    {
        public static IContainer RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            AddMvcRegistrations(builder);
            AddRegisterations(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void AddRegisterations(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //builder.RegisterModule<AutofacWebTypesModule>();
        }

        private static void AddMvcRegistrations(ContainerBuilder builder)
        {
            RegisterManager.Register(builder);
            RegisterRepository.Register(builder);
        }
    }
}