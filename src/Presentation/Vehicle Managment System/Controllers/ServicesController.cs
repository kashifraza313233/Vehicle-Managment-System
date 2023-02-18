using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
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
        // GET: ServicesController-------- 
        public ActionResult Index()
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
        public async Task<ActionResult> Create(AddServicesModel model )
        {
            if (ModelState.IsValid)
            {
                string ImageName = Path.GetFileName(model.CoverImage.FileName);
               
                var Folderpath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images", ImageName);
                // model.CoverImage.FileName.ToString();
                //Path.Combine(environment.WebRootPath, "images");
                using (var filestream=new FileStream(Folderpath, FileMode.Create))
                {
                   await model.CoverImage.CopyToAsync(filestream);
                }
                var imagespath = @"~/images/" + ImageName;
                // Path.Combine(Folderpath, ImageName);
                // model.CoverImage.CopyTo(new FileStream(imagespath, FileMode.Create));
                //Services services = new Services();
                //services.CoverImage = ImageName;
                //services.ServiceName = model.ServiceName;
                //services.Description = model.Description;
                //dbContext.Services.Add(services);
                dbContext.Add(new VM.Data.Models.Services()
                {
                    SId = model.SId,
                    CoverImage = imagespath,
                    ServiceName = model.ServiceName,
                    Description = model.Description,
                });
                
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Services");
            }

            return View();
        }

        // GET: ServicesController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var allservices = await dbContext.Services.FindAsync(id);

            return View(new AddServicesModel()
            {
                SId = allservices.SId,
                ImagePath = allservices.CoverImage,
                ServiceName = allservices.ServiceName,
                Description = allservices.Description,
            });
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {

            return View();
        }
        
        public ActionResult Delete(int id)
        {
            var allservices = dbContext.Services.Find(id);
            if (allservices != null)
            {
                dbContext.Remove(allservices);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Services");
            //return View();
        }

        // POST: ServicesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
