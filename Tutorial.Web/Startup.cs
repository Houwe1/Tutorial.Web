using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Tutorial.Web.Data;
using Tutorial.Web.Model;
using Tutorial.Web.Services;

namespace Tutorial.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IServices<Student>, EFCoreServices>();
            //AddSingleton：单例模式
            //AddScoped：每次请求生产一次实例，不重复
            //AddTransient：每次请求都生成一次实例，重复


            //中间件：实现某一领域功能
            // POST/Prodcut -> POST/Product  -> POST/Product
            // Logger       -> Authorization -> Route
            // Json/Html    <- Json/Html     <- Json/Html

            //管道和中间件的执行方式
            //Logger >> 授权         >> 路由中间件：响应请求
            //       <<（授权失败）
            //       << json或者HTML << json或者HTML
            services.AddMvc();
            

            //var connectionString = _configuration[ConnectionStrings:DefaultConnection];
            //services.AddDbContext<DataContext>(options =>
            //{
            //    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            //});
            //services.AddScoped<IRepository<Student>, EFCoreRepository>();

            //services.AddDbContext<IdentityDbContext>(options =>
            //{
            //    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Tutorial.Web"));
            //});

            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<IdentityDbContext>();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings.
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 1;
            //    options.Password.RequiredUniqueChars = 1;

            //    // Lockout settings.
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings.
            //    options.User.AllowedUserNameCharacters =
            //        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = false;
            //});
        }


        //IConfiguration接口
        //1.appsettings.json > appsettings.Development.json > environment variables > command line
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// 配置中间件（管道）
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="welcomeService"></param>
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILogger<Startup> logger)
        {
            #region 04.中间件
            //app.UseWelcomePage();
            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/Welcome"
            //});

            //next:Request Delegate
            //app.Use(next =>
            //{
            //    logger.LogInformation("app.use()......");
            //    return async httpContext =>
            //    {
            //        logger.LogInformation("---async HttpContext");
            //        if (httpContext.Request.Path.StartsWithSegments("/first"))
            //        {
            //            logger.LogInformation("----first!!!");
            //            await httpContext.Response.WriteAsync("first!!!");
            //        }
            //        else
            //        {
            //            logger.LogInformation("----next(HttpContext)");
            //            await next(httpContext);
            //        }
            //    };
            //});

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //尝试使用Welcome中间件
            //app.UseWelcomePage(new WelcomePageOptions()
            //{
            //    Path = "/welcome"
            //});

            //app.Use(next =>
            //{
            //    return async HttpContext =>
            //    {
            //        if (HttpContext.Request.Path.StartsWithSegments("/first"))
            //        {
            //            await HttpContext.Response.WriteAsync("This is a First!");
            //        }
            //        else
            //        {
            //            await next(HttpContext);
            //        }
            //    };
            //});

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            #endregion

            #region 05.Controller 路由
            //路由

            app.UseStaticFiles();
            
            //app.UseMvcWithDefaultRoute();
            //lambda表达式：匿名函数 可以直接赋值给委托
            app.UseMvc(builder =>
            {

                // /Home/Index -> HomeController/Index() 
                builder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion


            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules"))
            });
            //app.UseAuthentication();

            //app.UseMvc(builder =>
            //{
            //    builder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            //});

            //app.Run(async (context) =>
            //{
            //    //var welcome = configuration["Welcome"];
            //    //throw new Exception("Error!");
            //    var welcome = welcomeService.GetWelcome();
            //    await context.Response.WriteAsync(welcome);
            //});
        }
    }
}
