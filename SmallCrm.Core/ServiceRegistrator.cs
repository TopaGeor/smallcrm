using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SmallCrm.Core.Data;
using SmallCrm.Core.Services;

namespace SmallCrm.Core
{
    public class ServiceRegistrator
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<ProductService>()
                .InstancePerLifetimeScope()
                .As<IProductService>();

            builder
                .RegisterType<OrderService>()
                .InstancePerLifetimeScope()
                .As<IOrderService>();

            builder
                .RegisterType<CustomerService>()
                .InstancePerLifetimeScope()
                .As<ICustomerService>();

            builder
                .RegisterType<SmallCrmDbContext>()
                .InstancePerLifetimeScope()
                .AsSelf();

            return builder.Build();
        }
    }
}
