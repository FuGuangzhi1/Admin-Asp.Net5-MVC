using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface.DomainInterface;
using MvcStudyFu.Services.DomainServices;

namespace WebApplication.Utility
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFCoreContextFactory>().As<IDBContextFactory>().SingleInstance();
            builder.RegisterType<LoginDomain>().As<ILoginDomain>().SingleInstance();
            builder.RegisterType<Study>().As<IStudy>().SingleInstance();
            builder.RegisterType<HomePage>().As<IHomePage>().SingleInstance();
            builder.RegisterType<PersonalInfo>().As<IPersonalInfo>().SingleInstance();

        }
    }
}
