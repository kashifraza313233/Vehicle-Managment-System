using AutoMapper;
using VM.Bussiness.Models;
using VM.Data.Models;

namespace VM.Bussiness.DataServices
{
    public class BussinessEntityMappings : Profile
    {
        public BussinessEntityMappings() 
        {
            CreateMap<VehicleInfoModel, VehicleInfo>().ReverseMap();
        }
    }
}
