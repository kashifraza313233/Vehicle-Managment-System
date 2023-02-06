using AutoMapper;
using VM.Bussiness.Interfaces;
using VM.Data.Interfaces;
using VM.Data.Models;

namespace VM.Bussiness.DataServices
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<TModel> GetAll()
        {
            var allentity = _repository.GetAll();
            var allmodels = _mapper.Map<List<TModel>>(allentity);
            return allmodels;
        }
        public void Add(TModel model) 
        {
            var entity = _mapper.Map<TEntity>(model);
            _repository.Save(entity);
        }

        public void Delete(int id)
        {
            var entity = _repository.Get(x => x.VId == id).FirstOrDefault();
            if (entity != null)
            {
                _repository.Delete(entity);
            }
        }
        public void Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _repository.Save(entity);
        }
    }
   
 
}
