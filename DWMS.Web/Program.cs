using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWMS.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DWMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 修改前
            // CreateHostBuilder(args).Build().Run();

            // 修改后, 将 build 和 run 过程拆分，添加 create db 的中间过程
            var host = CreateHostBuilder(args).Build();

         //   CreateDbIfNotExists(host);

            host.Run();
        }

        // 调用 初始化数据库 方法
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<DefaultContext>();

                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
