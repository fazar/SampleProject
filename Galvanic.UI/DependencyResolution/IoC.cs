using StructureMap;
using Galvanic.Data;
using Galvanic.Data.Repositories;
using Galvanic.Service;

using Galvanic.Service.Interface;
using Galvanic.Infrastructure.SimpleMembership;
using Omu.ValueInjecter;
namespace Galvanic.UI {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
            //                x.For<IExample>().Use<Example>();

                            x.For<IOrderService>().Use<OrderService>();
                            x.For<IUserService>().Use<UserService>();

                            x.For<IOrderRepository>().Use<OrderRepository>();
                            x.For<IUserRepository>().Use<UserRepository>();
                            
                            //simple membership
                            x.For<IWebSecurityService>().Use<WebSecurityService>();

                            //value injecter
                            x.For<IValueInjecter>().Use<ValueInjecter>();

                        });
            return ObjectFactory.Container;
        }
    }
}