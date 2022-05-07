

using Domain.Context;

namespace Repository.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        DataContext Context { get; }

        Task Commit();

    }
}
