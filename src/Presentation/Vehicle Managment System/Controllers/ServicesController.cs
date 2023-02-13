using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VM.Bussiness.DataServices;
using VM.Bussiness.Models;
using VM.Data;
using VM.Data.Models;

namespace Vehicle_Managment_System.Controllers
{
    public class ServicesController : Controller
    {
        VehicleManagmentDbContext dbContext;
        IWebHostEnvironment environment;
        public ServicesController(VehicleManagmentDbContext _dbContext, IWebHostEnvironment _environment)
        {
            dbContext = _dbContext;
            environment = _environment;
        }
        // GET: ServicesController
        public ActionResult Index()
        {
            var AllServices = dbContext.Services;
           
            return View(AllServices);
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
                string ImageName = model.Coverimage.FileName.ToString();
                var Folderpath = Path.Combine(environment.WebRootPath, "images");
                var imagespath = Path.Combine(Folderpath, ImageName);
                model.Coverimage.CopyTo(new FileStream(imagespath, FileMode.Create));
                Services services = new Services();
                services.CoverImage = ImageName;
                services.ServiceName = model.ServiceName;
                services.Description = model.Description;
                dbContext.Services.Add(services);
                dbContext.SaveChanges();
                return RedirectToAction("Create", "Services");
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
