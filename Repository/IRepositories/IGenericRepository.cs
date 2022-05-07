namespace  Repository.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> GetById(int id);

        Task<TEntity> Delete(int id);
        Task<TEntity> Update(TEntity entity);

    }
}
