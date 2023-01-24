using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Managment_System.Controllers
{
    public class VehicleInform : Controller
    {
        // GET: VehicleInform
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicleInform/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleInform/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleInform/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VehicleInform/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleInform/Edit/5
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

        // GET: VehicleInform/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleInform/Delete/5
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
