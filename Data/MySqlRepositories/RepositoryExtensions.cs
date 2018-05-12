using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MySqlRepositories
{
    public static class RepositoryExtensions
    {
        public static void AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPatientUserRepository, PatientUserRepository>();
            services.AddTransient<IPhysicianRepository, PhysicianRepository>();

        }
    }
}
