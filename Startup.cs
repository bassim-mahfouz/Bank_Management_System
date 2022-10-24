using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Bank_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Bank_Management_System.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;



namespace Bank_Management_System
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
            services.AddRazorPages();
            
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<CustomerRepository,CustomerRepository>();
            services.AddScoped<EmployeeRepository,EmployeeRepository>();
            services.AddScoped<AdminRepository,AdminRepository>();

            services.AddAuthentication()
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,options=>
                {
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath="/AccessDenied";
                    options.Cookie.HttpOnly = true;
                })
                .AddCookie("Admin",options=>
                {
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/AccessDenied";
                    options.Cookie.HttpOnly = true;
                });
            services.AddAuthorization(options => {

                options.AddPolicy(
                    "Admin",
                    policyBuilder => { 
                        policyBuilder.RequireRole("Admin");
                        policyBuilder.AddAuthenticationSchemes("Admin");
                    });

                options.AddPolicy(
                    "Employee",
                    policyBuilder=>
                    {
                        policyBuilder.RequireRole("Employee");
                    });
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
