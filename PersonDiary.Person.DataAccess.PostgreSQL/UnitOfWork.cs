using PersonDiary.Contexts;
using PersonDiary.Person.Domain;
using System;
using System.Threading.Tasks;

namespace PersonDiary.Person.Repositories
{

    public sealed class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly SqlContext sqlContext = new SqlContext();

        public UnitOfWork(IPersonRepository personRepository)
        {
            this.Persons = personRepository;
        }

        public IPersonRepository Persons { get; }

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
