using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWMS.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DWMS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //����Ӧ�ó����н�ʹ�õķ���
        //��ConfigureServices�п���ʹ��DI����ע��ʹ���Զ���ķ���(Service��Component��ͬ)
        //ConfigureServices������������services(���ַ���, ����identity, ef, mvc�ȵȰ�����������, �����Լ�д��)
        //����(register)��container(asp.net core������)��ȥ, ��������Щservices.���container����������dependency injection��(����ע��). 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // ע����ط���: Context
            services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Program��Ŀ�е�Run()ִ�н������ִ��Configure����
        //Configure��ָ�����ǹܵ�pipeline�е����ú����̣�����ָ������δ���ÿ��HTTP����

       

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            //��鵱ǰ�����������Ƿ���Microsoft.Extensions.Hosting.EnvironmentName.Development�����򷵻�true
            //�ж��Ƿ��ǻ�������
            if (env.IsDevelopment())
            {
                // �ڿ��������У�ʹ���쳣ҳ�棬�������Ա�¶�����ջ��Ϣ�����Բ�Ҫ��������������
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // �ڷǿ��������У�ʹ��HTTP�ϸ�ȫ����(or HSTS) ���ڱ���web��ȫ�Ƿǳ���Ҫ�ġ�
                // ǿ��ʵʩ HTTPS �� ASP.NET Core����� app.UseHttpsRedirection
                //app.UseHsts();
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            #region CORS
            //����ڶ��ַ�����ʹ�ò��ԣ���ϸ������Ϣ��ConfigureService��
            app.UseCors("LimitRequests");//�� CORS �м����ӵ� web Ӧ�ó��������, �������������


            //�����һ�ְ汾����ҪConfigureService�����÷��� services.AddCors();
            //    app.UseCors(options => options.WithOrigins("http://localhost:8021").AllowAnyHeader()
            //.AllowAnyMethod()); 
            #endregion

            #region Authen
            //app.UseMiddleware<JwtTokenAuth>();//ע�����Ȩ�����Ѿ���������ʹ���±ߵĹٷ���֤��������������㻹�봫User��ȫ�ֱ��������ǿ��Լ���ʹ���м��
            app.UseAuthentication();
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
