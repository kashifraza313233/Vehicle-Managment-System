using System.Buffers.Text;
using System.Linq.Expressions;
using VM.Data.Models;

namespace VM.Data.Interfaces
{
    public interface IRepository<TEntity>where TEntity : BaseEntity
    { 
        List<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity,bool>> predicate); 
        void Save (TEntity entity);
        void Delete (TEntity entity);
        
    }
}