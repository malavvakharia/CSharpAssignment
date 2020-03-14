using Autofac;
using CsharpAssginment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.Business.Handlers
{
    public class RegisterRepository
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType(typeof(CustomerRepository)).AsImplementedInterfaces();
            containerBuilder.RegisterType(typeof(CityRepository)).AsImplementedInterfaces();
        }
    }
}
