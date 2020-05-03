using PersonDiary.Contexts;
using System;
using System.Threading.Tasks;
using PersonDiary.LifeEvent.Infrastructure.Domain;

namespace PersonDiary.LifeEvent.Repositories
{

    public sealed class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly SqlContext sqlContext = new SqlContext();

        public UnitOfWork(ILifeEventRepository lifeEventRepository)
        {
            this.LifeEvents = lifeEventRepository;
        }

        public ILifeEventRepository LifeEvents { get; }

        public Task<int> SaveAsync() => sqlContext.SaveChangesAsync();

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (this.disposed) return;
            if (disposing)
            {
                sqlContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
