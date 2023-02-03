using VM.Bussiness.Interfaces;
using VM.Bussiness.Models;
using VM.Data;
using VM.Data.Interfaces;
using VM.Data.Models;

namespace VM.Bussiness.DataServices
{
    public class VehicleInfoService:IVehicleService
    {
        private readonly IRepository<VehicleInfo> _dbContext;
        public VehicleInfoService(IRepository<VehicleInfo> dbContext)
        {
            _dbContext = dbContext;
        }
        public List<VehicleInfoModel> GetAll()
        {

            var allVehicleInfo = _dbContext.GetAll();
            var allvehicleinformation = allVehicleInfo.Select(x => new VehicleInfoModel
            {
                VId = x.VId,
                Vehicle = x.Vehicle,
                VehicleModel = x.VehicleModel,
                VehicleNumber = x.VehicleNumber,
                OwnerName = x.OwnerName,
                ContactNo = x.ContactNo,
                EmailAddress = x.EmailAddress,
                Service_Type = x.Service_Type,
            }).ToList();
            
            return allvehicleinformation;
        }
        public void Add( VehicleInfoModel model)
        {
            _dbContext.Save(new Data.Models.VehicleInfo
            {
                VId = model.VId,
                Vehicle = model.Vehicle,
                VehicleModel = model.VehicleModel,
                VehicleNumber = model.VehicleNumber,
                OwnerName = model.OwnerName,
                ContactNo = model.ContactNo,
                EmailAddress = model.EmailAddress,
                Service_Type = model.Service_Type,
            });
           /// _dbContext.SaveChanges();
        }
        public void Update(VehicleInfoModel model)
        {
            _dbContext.Save(new VehicleInfo {
                VId = model.VId,
                Vehicle = model.Vehicle,
                VehicleModel = model.VehicleModel,
                VehicleNumber = model.VehicleNumber,
                OwnerName = model.OwnerName,
                ContactNo = model.ContactNo,
                EmailAddress = model.EmailAddress,
                Service_Type = model.Service_Type,
            });
        }
        public void Delete(int id)
        {
            var deleteVehicleinfo = _dbContext.Get(x=>x.VId==id).FirstOrDefault();
            if (deleteVehicleinfo != null)
            {
                _dbContext.Delete(deleteVehicleinfo);
                
            }
        }
    }
}