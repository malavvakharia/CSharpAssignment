using Autofac;
using CsharpAssignment.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsharpAssignment.Handlers
{
    public class RegisterManager
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType(typeof(CustomerManager)).AsImplementedInterfaces();
        }
    }
}