using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.EmailSender;
using DataAccess.Model;
using DataAccess.Pattern.Interface;
using DataAccess.Pattern.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalMaggieCard.FileManager;
using PortalMaggieCard.Models;
using Stripe;

namespace PortalMaggieCard
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentity<User, UserRole>()
            .AddEntityFrameworkStores<Context>()
            .AddDefaultTokenProviders();

           


            services.AddScoped(typeof(IProductInterface), typeof(ProductRepository));
            services.AddScoped(typeof(IFileInterface), typeof(FileRepository));
            //services.AddScoped(typeof(IUserInterface), typeof(UserRepository));
            services.AddScoped(typeof(ICustomerInterface), typeof(CustomerRepository));
            services.AddScoped(typeof(IPostInterface), typeof(PostRepository));
            services.AddScoped(typeof(IOrderInterface), typeof(OrderRepository));
            services.AddScoped(typeof(Context), typeof(Context));
            services.AddTransient<IMessageService, MessageService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "MaggiemCard",
                 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "product",
                    template: "{controller=Product}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=PortalHome}/{action=Index}/{id?}");
            });
        }
    }
}
