using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Bussiness.Models;

namespace VM.Bussiness.DataServices.Interfaces
{
    public interface IVehicleInformation
    {
        public List<VehicleInfoModel> GetAll();
        public void Add(VehicleInfoModel vehicleInfoModel);
        public void Delete(int id);

    }
}
