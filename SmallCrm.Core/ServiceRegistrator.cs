using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SmallCrm.Core.Data;
using SmallCrm.Core.Services;

namespace SmallCrm.Core
{
    public class ServiceRegistrator : Autofac.Module
    {
        public static void RegisterServices(ContainerBuilder builder)
        {

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

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
        }

        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            RegisterServices(builder);
            return builder.Build();   
        }


        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
            base.Load(builder);
        }
    }
}
