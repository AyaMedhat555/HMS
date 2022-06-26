
using Repository.IRepositories;
using Repository.UnitOfWorks;

namespace Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private IUnitOfWork _unitOfWork { get; }
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity entity = await GetById(id);
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.Context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            TEntity entity =  await _unitOfWork.Context.Set<TEntity>().FindAsync(id);
            if(entity is not null)
            {
                return entity;
            }
            return null;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _unitOfWork.Context.Update(entity);
            await _unitOfWork.Commit();
            return entity;
        }
    }
}
