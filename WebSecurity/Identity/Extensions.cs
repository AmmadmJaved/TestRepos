using Data;
using Data.MySqlRepositories;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebSecurity.Identity
{
  public static class Extensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("WebApp")));
            services.AddTransient<IProfileService, ProfileService>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
       .AddDeveloperSigningCredential()
       .AddInMemoryPersistedGrants()
       .AddInMemoryIdentityResources(Config.GetIdentityResources())
       .AddInMemoryApiResources(Config.GetApiResources())
       .AddInMemoryClients(Config.GetClients())
       //.AddOperationalStore(builder=>builder.)
       //.AddOperationalStore(builder => builder.UseMySql(configuration.GetConnectionString("DefaultConnection"), options => options.MigrationsAssembly("ALBIE.Data")))
       .AddAspNetIdentity<ApplicationUser>()// enable Aspnet Identity install IdentityServer4.EntityFrameWork
       .AddProfileService<ProfileService>();

        }

        public static void UseIdentityServices(this IApplicationBuilder app)
        {
            app.UseIdentity();
            app.UseIdentityServer();

        }
    }
}
