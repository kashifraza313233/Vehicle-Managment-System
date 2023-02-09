using AutoMapper;
using VM.Bussiness.Interfaces;
using VM.Bussiness.Models;
using VM.Data;
using VM.Data.Interfaces;
using VM.Data.Models;

namespace VM.Bussiness.DataServices
{
    public class VehicleInfoService: GenericService<VehicleInfoModel,VehicleInfo>,IVehicleService
    {
        private readonly IRepository<VehicleInfo>  _repository;

        public VehicleInfoService(IRepository<VehicleInfo> repository,IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
        public List<VehicleInfoModel> GetAll()
        {

            var allVehicleInfo = _repository.GetAll();
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
        public List<VehicleInfoModel> Search(string Searchinfo)
        {
            Searchinfo = Searchinfo.Trim().ToLower();
            var allvehicleinformation = _repository.Get(x => x.VehicleNumber.ToLower()
            .Contains(Searchinfo) || x.OwnerName.ToLower().Contains(Searchinfo)).ToList();
            var infomation = allvehicleinformation.Select(x => new VehicleInfoModel
            {
                VId = x.VId,
                Vehicle = x.Vehicle,
                VehicleModel= x.VehicleModel,
                VehicleNumber = x.VehicleNumber,
                OwnerName = x.OwnerName,
                ContactNo = x.ContactNo,
                EmailAddress = x.EmailAddress,
                Service_Type = x.Service_Type
            }).ToList();
            return infomation;
        }
        public void Add(VehicleInfoModel model)
        {
            _repository.Save(new Data.Models.VehicleInfo
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
            _repository.Save(new VehicleInfo
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
        }
        public void Delete(int id)
        {
            var deleteVehicleinfo = _repository.Get(x => x.VId == id).FirstOrDefault();
            if (deleteVehicleinfo != null)
            {
                _repository.Delete(deleteVehicleinfo);

                /*_dbContext.SaveChanges();*/

            }
        }


    }
}