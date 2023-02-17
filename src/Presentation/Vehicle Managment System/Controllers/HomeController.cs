using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vehicle_Managment_System.Models;
using VM.Bussiness.Models;
using VM.Data;

namespace Vehicle_Managment_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VehicleManagmentDbContext dbContext;
        private readonly IWebHostEnvironment environment;
        public HomeController(ILogger<HomeController> logger, VehicleManagmentDbContext _dbContext, IWebHostEnvironment _environment)
        {
            _logger = logger;
            dbContext = _dbContext;
            environment = _environment;
        }
       
        public IActionResult Index()
        {
            var allservices = new List<AddServicesModel>();
            var ser = dbContext.Services.ToList();
            foreach (var service in ser)
            {
                allservices.Add(new AddServicesModel()
                {
                    SId = service.SId,
                    ImagePath = service.CoverImage,
                    ServiceName = service.ServiceName,
                    Description = service.Description,

                });
            }
            return View(allservices);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}