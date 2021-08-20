using Autofac;
using Autofac.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcStudyFu.Common;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface;
using MvcStudyFu.Interface.DomainInterface;
using MvcStudyFu.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Utility;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddMvc(options =>
            // {
            //     options.Filters.Add(typeof(ActionLoginFilterAttribute));
            // });
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionAttribute));
            });
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddSession();
            //services.AddScoped<IDbContextFactory, EFCoreContextFactory>();
            //services.AddScoped<ILoginDomain, LoginDomain>();
            services.AddDbContext<StudyMVCDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Write"]);
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region 手动注册
            builder.RegisterType<EFCoreContextFactory>().As<IDbContextFactory>();
            builder.RegisterType<LoginDomain>().As<ILoginDomain>();
            #endregion

            //#region 配置文件注册
            //IConfigurationBuilder config = new ConfigurationBuilder();
            //IConfigurationSource autoJsonconfigSource = new JsonConfigurationSource() 
            //{
            //Path="",
            //Optional=false,
            //ReloadOnChange=false
            //};
            //config.Add(autoJsonconfigSource);
            //var module = new ConfigurationModule(config.Build());
            //builder.RegisterModule(module);
            //#endregion
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AccountControllers}/{action=Login}");
            });
        }
    }
}
