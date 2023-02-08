using Microsoft.EntityFrameworkCore;
using VM.Data.Models;

namespace VM.Data
{
    public class VehicleManagmentDbContext:DbContext
    {
        public VehicleManagmentDbContext(DbContextOptions<VehicleManagmentDbContext>options) : base(options)
        { 

        }
        public DbSet<VehicleInfo> VehicleInfomations { get; set; }
      
       
    }
}