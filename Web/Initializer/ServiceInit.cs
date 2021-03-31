using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Initializer
{
    public class ServiceInit
    {
        public static void InitializeServices(IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICrudCompanyService, CrudCompanyService>();
            services.AddTransient<ICrudUserService, CrudUserService>();
        }

    }
}
