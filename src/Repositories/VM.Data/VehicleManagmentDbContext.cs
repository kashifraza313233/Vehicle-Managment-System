using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VM.Data.Models;

namespace VM.Data
{
    public class VehicleManagmentDbContext:IdentityDbContext
    {
        public VehicleManagmentDbContext(DbContextOptions<VehicleManagmentDbContext>options) : base(options)
        { 

        }
        public DbSet<VehicleInfo> VehicleInfomations { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}