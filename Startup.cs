using System;
using App.Services;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
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
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IJsonEncoder, JsonEncoder>();
            services.AddAuth0WebAppAuthentication(configureOptions =>
            {
                configureOptions.Domain = Configuration.GetValue<string>("AUTH0_DOMAIN", "");
                configureOptions.ClientId = Configuration.GetValue<string>("AUTH0_CLIENT_ID", "");
                configureOptions.ClientSecret = Configuration.GetValue<string>("AUTH0_CLIENT_SECRET", "");
                configureOptions.CallbackPath = Configuration.GetValue<string>("AUTH0_CALLBACK_PATH", "");
                configureOptions.Scope = "openid profile email";
                configureOptions.SkipCookieMiddleware = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var requiredVars =
                new string[] {
                    "PORT",
                    "AUTH0_DOMAIN",
                    "AUTH0_CLIENT_ID",
                    "AUTH0_CLIENT_SECRET",
                    "AUTH0_CALLBACK_PATH",
                };

            foreach (var key in requiredVars)
            {
                var value = Configuration.GetValue<string>(key);

                if (value == "" || value == null)
                {
                    throw new Exception($"Config variable missing: {key}.");
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseExceptionHandler("/error");
            app.UseStatusCodePagesWithReExecute("/error");

            app.UseRouting();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
