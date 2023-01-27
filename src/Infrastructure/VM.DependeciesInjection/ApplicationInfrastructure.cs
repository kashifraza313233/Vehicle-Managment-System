using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using VM.Bussiness.DataServices;
using VM.Bussiness.Interfaces;
using VM.Data;

namespace VM.DependeciesInjection
{
    public static class ApplicationInfrastructure
    {
        public static void AppDISetup(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
         
            // Entity Framework Configuration
            serviceCollection.AddDbContext<VehicleManagmentDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));
            
            //Custom Configuration
            serviceCollection.AddScoped<IVehicleService, VehicleInfoService>();
        }
    }
}