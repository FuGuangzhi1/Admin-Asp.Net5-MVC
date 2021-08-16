using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddSession();
            services.AddScoped<IDbContextFactory, EFCoreContextFactory>();
            services.AddScoped<ILoginDomain, LoginDomain>();
            //Create();
            services.AddDbContext<StudyMVCDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Write"]);
            });
        }
        //private void Create() {
        //    IDbContextFactory dbContextFactory = new EFCoreContextFactory(Configuration);
        //    dbContextFactory.CreateDbContext( MvcStudyFu.Common.Enum.ReadWriteEnum.Write).Database.EnsureDeleted();
        //    dbContextFactory.CreateDbContext(MvcStudyFu.Common.Enum.ReadWriteEnum.Write).Database.EnsureCreated();
        //}
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
