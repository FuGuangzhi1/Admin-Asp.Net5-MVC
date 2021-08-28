﻿using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MvcStudyFu.EFCore.SQLSever;
using System.IO;
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
        private bool CreatDatabase = true;  //标记数据库是否创建了

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ActionLoginFilterAttribute));
                options.Filters.Add(typeof(CustomExceptionAttribute));
            });
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddSession();
            services.AddDbContext<StudyMVCDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Write"]);
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());

            #region 配置文件注册
            //IConfigurationBuilder config = new ConfigurationBuilder();
            //IConfigurationSource autoJsonconfigSource = new JsonConfigurationSource() 
            //{
            //Path="autofac.json",
            //Optional=false,
            //ReloadOnChange=false
            //};
            //config.Add(autoJsonconfigSource);
            //var module = new ConfigurationModule(config.Build());
            //builder.RegisterModule(module);
            #endregion
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //数据库创建
            if (CreatDatabase)
                using (var StudyMVCDBContext = new EFCoreContextFactory(Configuration).CreateDbContext())
                {
                    StudyMVCDBContext.Database.EnsureCreated();
                    CreatDatabase = false;
                }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider
                (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            });

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
