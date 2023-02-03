using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VM.Data.Interfaces;
using VM.Data.Models;

namespace VM.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly VehicleManagmentDbContext _context;
        private readonly DbSet<TEntity> _dbset;
        public Repository(VehicleManagmentDbContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _dbset.ToList();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
           return _dbset.Where(predicate);
        }
        public void Delete(TEntity entity)
        {
            if (entity==null)
            {
                return;
            }
            var dbentity = _context.Entry(entity);
            if (dbentity.State!=EntityState.Deleted)
            {
                dbentity.State = EntityState.Deleted;
            }else
            {
                _dbset.Attach(entity);
                _dbset.Remove(entity);
                _context.SaveChanges();
            }
        }
        public void Save(TEntity entity)
        {
           if (entity.VId > 0)
           {
              _dbset.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
           }else
            { 
                _dbset.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
