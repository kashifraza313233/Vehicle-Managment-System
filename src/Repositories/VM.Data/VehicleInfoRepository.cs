using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
