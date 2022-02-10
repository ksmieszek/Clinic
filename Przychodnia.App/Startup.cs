using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Przychodnia.Data;
using Przychodnia.Data.Images;
using Elmah.Io.AspNetCore;
using System;

namespace Przychodnia.App
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
            services.AddControllersWithViews();
            services.AddSession();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => 
                {
                    x.LoginPath = "/Uzytkownik/Login";
                    x.AccessDeniedPath = "/Errors/Error401";

                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("LekarzOnly",
                    policy => policy.RequireClaim("Lekarz"));

                options.AddPolicy("PacjentOnly",
                    policy => policy.RequireClaim("Pacjent"));
            });

            services.AddElmahIo(o =>
            {
                o.ApiKey = "4c3b46a12b6140b0bae8f3253c82a18c";
                o.LogId = new Guid("4c408b16-7113-41c8-a285-77ac4806d809");
            });

            services.AddHttpContextAccessor();
            services.AddPrzychodniaContext(Configuration);
            services.AddScoped<IImagesService, ImagesService>();
            services.AddAutoMapper(this.GetType().Assembly);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Errors/Error500");
            }
            else
            {
                app.UseExceptionHandler("/Errors/Error500");
            }
            var staticFilesPath = Configuration.GetValue<string>("StaticFilesPath");
            app.UseSession();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(staticFilesPath, "images")),
                RequestPath = "/images"
            });
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Errors/Error404";
                    await next();
                }
            });

            app.UseElmahIo();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
