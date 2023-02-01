using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VM.Bussiness.DataServices;
using VM.Bussiness.Interfaces;
using VM.Bussiness.Models;

namespace Vehicle_Managment_System.Controllers
{
    public class VehicleInformation : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehicleInformation(IVehicleService vehicleService)
        {
            _vehicleService= vehicleService;
        }
        // GET: VehicleInform
        public ActionResult Index()
        {
            // var vehicleinfo = new List<VehicleInfoModel>();

            return View(_vehicleService.GetAll());
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
        public ActionResult Create(VehicleInfoModel vehicleInfoModel)
        {
            try
            {
                _vehicleService.Add(vehicleInfoModel);
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
            var VehicleInformation = _vehicleService.GetAll().Where(x => x.VId == id).FirstOrDefault();
            return View(VehicleInformation);
        }

        // POST: VehicleInform/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleInfoModel vi)
        {
            try
            {
                var VehicleInformation = _vehicleService.GetAll().Where(x => x.VId == vi.VId).FirstOrDefault();
                if(VehicleInformation!= null)
                {
                    VehicleInformation.Vehicle=vi.Vehicle;
                    VehicleInformation.Vehicle=vi.VehicleModel;
                    VehicleInformation.Vehicle=vi.VehicleNumber;
                    VehicleInformation.Vehicle=vi.OwnerName;
                    VehicleInformation.Vehicle=vi.ContactNo;
                    VehicleInformation.Vehicle=vi.EmailAddress;
                }
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
            _vehicleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
