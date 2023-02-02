using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using VM.Bussiness.DataServices;
using VM.Bussiness.Interfaces;
using VM.Data;
using VM.Data.Interfaces;

namespace VM.DependencyInjection
{
    public static class AppInfrastructure
    {
        public static void AppDISetUp(this IServiceCollection services,IConfiguration configuration) 
        {
            // Entity Framework Configuration
            services.AddDbContext<VehicleManagmentDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Dbcon")));
            ///// repositories configuration
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            //Custom Configuration
           services.AddScoped<IVehicleService, VehicleInfoService>();
        }
    }
}