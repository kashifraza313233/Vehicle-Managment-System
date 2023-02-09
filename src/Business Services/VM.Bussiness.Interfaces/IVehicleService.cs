using VM.Bussiness.Models;

namespace VM.Bussiness.Interfaces
{
    public interface IVehicleService : IGenericService<VehicleInfoModel>
    {
        public List<VehicleInfoModel> Search(string Searchinfo);
    }
}