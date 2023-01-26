using VM.Bussiness.DataServices.Interfaces;
using VM.Bussiness.Models;
namespace VM.Bussiness.DataServices
{
    public class VehicleInfoService:IVehicleService
    {
        private List<VehicleInfoModel> vehicleInfo= new List<VehicleInfoModel>();
        public List<VehicleInfoModel> GetAll()
        {
            //vehicleInfo.Add(new VehicleInfoService {});
            return vehicleInfo;
        }
        public void Add( VehicleInfoModel vehicleInfoModel)
        {
            vehicleInfo.Add(vehicleInfoModel);
        }
        public void Delete(int id)
        {
            var deleteVehicleinfo= vehicleInfo.Where(x => x.VId == id).FirstOrDefault();
            if(deleteVehicleinfo != null)
            {
                vehicleInfo.Remove(deleteVehicleinfo);
            }
        }
    }
}