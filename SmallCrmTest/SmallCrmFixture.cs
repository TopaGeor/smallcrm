﻿using SmallCrm.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SmallCrm.Core;

namespace SmallCrmTest
{
    public class SmallCrmFixture : IDisposable
    {
        public SmallCrmDbContext DbContext { get; private set; }
        public Autofac.ILifetimeScope Container { get; private set; }

        public SmallCrmFixture()
        {
            Container = ServiceRegistrator.GetContainer().BeginLifetimeScope();
            DbContext = Container.Resolve<SmallCrmDbContext>();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            Container.Dispose();
        }
    }
}
