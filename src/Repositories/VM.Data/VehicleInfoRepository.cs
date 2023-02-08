
using VM.Data.Interfaces;
using VM.Data.Models;

namespace VM.Data
{
    public  class VehicleInfoRepository : Repository<VehicleInfo>,IVehicleInfoRepository
    {
        public VehicleInfoRepository(VehicleManagmentDbContext context):base(context)
        {

        }
    }
}
