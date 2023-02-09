using VM.Bussiness.Models;

namespace VM.Bussiness.Interfaces
{
    public interface IGenericService<TModel> 
    {
        public List<TModel> GetAll();
        //public List<VehicleInfoModel> Search(string searchinfo);
        public void Add(TModel vehicleInfoModel);
        public void Delete(int id);
        public void Update(TModel model);


    }
}
