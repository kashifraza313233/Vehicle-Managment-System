using Microsoft.EntityFrameworkCore;
using VM.Bussiness.DataServices;
using VM.Bussiness.DataServices.Interfaces;
using VM.Data;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework Configuration
builder.Services.AddDbContext<VehicleManagmentDbContext>(
options => options.UseSqlServer("Data Source=DESKTOP-EOP4ESH\\SQLEXPRESS01;Database=VehicleManagmentSystem; Integrated Security=SSPI;TrustServerCertificate=True;"));
// Add services to the container.
builder.Services.AddControllersWithViews();
//Custom Configuration
builder.Services.AddSingleton<IVehicleService,VehicleInfoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
