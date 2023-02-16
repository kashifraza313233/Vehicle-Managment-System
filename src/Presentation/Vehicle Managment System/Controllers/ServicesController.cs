using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VM.Bussiness.Models;
using VM.Data;
using VM.Data.Migrations;
using VM.Data.Models;

namespace Vehicle_Managment_System.Controllers
{
    public class ServicesController : Controller
    {
        private readonly VehicleManagmentDbContext dbContext;
        private readonly IWebHostEnvironment environment;
        public ServicesController(VehicleManagmentDbContext _dbContext, IWebHostEnvironment _environment)
        {
            dbContext = _dbContext;
            environment = _environment;
        }
        // GET: ServicesController
        public ActionResult Index()
        {
            var allservices = new List<AddServicesModel>();
            var ser = dbContext.Services.ToList();
            foreach (var service in ser)
            {
                allservices.Add(new AddServicesModel()
                {
                    SId = service.SId,
                  //  CoverImage = Convert.ToBase64String(),
                    ServiceName = service.ServiceName,
                    Description = service.Description,
                 
                });
            }
            return View(allservices);
        }

        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddServicesModel model )
        {
            if (ModelState.IsValid)
            {
                string ImageName = model.CoverImage.FileName.ToString();
                var Folderpath = Path.Combine(environment.WebRootPath, "images");
                
                var imagespath = Path.Combine(Folderpath, ImageName);
                model.CoverImage.CopyTo(new FileStream(imagespath, FileMode.Create));
                //Services services = new Services();
                dbContext.Add(new VM.Data.Models.Services()
                {
                    SId = model.SId,
                    CoverImage = model.CoverImage.FileName,
                    ServiceName = model.ServiceName,
                    Description = model.Description,
                });
                //services.CoverImage = ImageName;
                //services.ServiceName = model.ServiceName;
                //services.Description = model.Description;
                //dbContext.Services.Add(services);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Services");
            }

            return View();
        }

        // GET: ServicesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
