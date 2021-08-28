using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using System.IO;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
           // .ConfigureAppConfiguration((context,config)=> {
           //     config.AddJsonFile("database.json");
           //     string env = context.HostingEnvironment.EnvironmentName;
           //     config.AddJsonFile($"database.{env}.json");
           // })
           .ConfigureLogging(loggingBuilder =>
           {
               //这种注册方式有问题，采用下面的放方式
               //loggingBuilder.AddLog4Net("log4net.config");
               //一定要注意文件的路径
               loggingBuilder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));
           }).ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
           }).UseServiceProviderFactory(new AutofacServiceProviderFactory());  //启用Autofac依赖注入
    }
}
