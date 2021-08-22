using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface.DomainInterface;
using MvcStudyFu.Services.DomainServices;

namespace WebApplication.Utility
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFCoreContextFactory>().As<IDbContextFactory>().SingleInstance();
            builder.RegisterType<LoginDomain>().As<ILoginDomain>().SingleInstance();
        }
    }
}
