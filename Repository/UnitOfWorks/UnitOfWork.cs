

using Domain.Context;

namespace Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext Context { get; }

        public UnitOfWork(DataContext context)
        {
            Context = context;
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
