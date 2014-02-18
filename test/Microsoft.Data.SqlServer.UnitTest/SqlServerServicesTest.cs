﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.AspNet.DependencyInjection;
using Microsoft.Data.Entity.Identity;
using Xunit;

namespace Microsoft.Data.SqlServer
{
    public class SqlServerServicesTest
    {
        [Fact]
        public void CanGetDefaultServices()
        {
            var services = SqlServerServices.GetDefaultServices().ToList();

            Assert.True(services.Any(sd => sd.ServiceType == typeof(IIdentityGenerator<Guid>)));
            Assert.True(services.Any(sd => sd.ServiceType == typeof(IIdentityGenerator<long>)));
        }

        [Fact]
        public void ServicesWireUpCorrectly()
        {
            var serviceProvider = new ServiceProvider().Add(SqlServerServices.GetDefaultServices());

            Assert.NotNull(serviceProvider.GetService<IIdentityGenerator<long>>());
            Assert.NotNull(serviceProvider.GetService<IIdentityGenerator<Guid>>());
        }
    }
}
