using VM.Bussiness.Models;

namespace VM.Bussiness.Interfaces
{
    public interface IVehicleService
    {
        public List<VehicleInfoModel> GetAll();
        public void Add(VehicleInfoModel vehicleInfoModel);
        public void Update(VehicleInfoModel vehicleInfoModel);
        public void Delete(int id);

    }
}