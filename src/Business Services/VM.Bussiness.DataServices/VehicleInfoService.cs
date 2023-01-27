using VM.Bussiness.Interfaces;
using VM.Bussiness.Models;
using VM.Data;

namespace VM.Bussiness.DataServices
{
    public class VehicleInfoService:IVehicleService
    {
        private readonly VehicleManagmentDbContext _dbContext;
        public VehicleInfoService(VehicleManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<VehicleInfoModel> GetAll()
        {

            var allVehicleInfo = _dbContext.VehicleInfomations.ToList();
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
            _dbContext.VehicleInfomations.Add(new Data.Models.VehicleInfo
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
            _dbContext.SaveChanges();
        }
        public void Update(VehicleInfoModel vehicleInfoModel)
        {
            var updateVehicleinfo = _dbContext.VehicleInfomations.FirstOrDefault(x=>x.VId==vehicleInfoModel.VId);
            if(updateVehicleinfo != null)
            {
                updateVehicleinfo.Vehicle = vehicleInfoModel.Vehicle;
                updateVehicleinfo.VehicleModel = vehicleInfoModel.VehicleModel;
                updateVehicleinfo.VehicleNumber = vehicleInfoModel.VehicleNumber;
                updateVehicleinfo.OwnerName= vehicleInfoModel.OwnerName;
                updateVehicleinfo.ContactNo= vehicleInfoModel.ContactNo;
                updateVehicleinfo.EmailAddress= vehicleInfoModel.EmailAddress;
                //updateVehicleinfo.Service_Type= vehicleInfoModel.Service_Type;
                _dbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var deleteVehicleinfo= _dbContext.VehicleInfomations.Where(x => x.VId == id).FirstOrDefault();
            if (deleteVehicleinfo != null)
            {
                _dbContext.VehicleInfomations.Remove(deleteVehicleinfo);
                _dbContext.SaveChanges();
            }
        }
    }
}