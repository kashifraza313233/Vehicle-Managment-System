using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Bussiness.Interfaces;
using VM.Data.Models;

namespace VM.Bussiness.DataServices
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel> where TEntity : BaseEntity
    {
        public void Add(TModel vehicleInfoModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TModel model)
        {
            throw new NotImplementedException();
        }
    }
   
 
}
