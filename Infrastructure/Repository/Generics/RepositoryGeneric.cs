using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _options;
        public RepositoryGeneric()
        {
            _options = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T objeto)
        {
            using (var data = new ContextBase(_options))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using (var data = new ContextBase(_options))
            {
                data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new ContextBase(_options))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_options))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T objeto)
        {
            using (var data = new ContextBase(_options))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion

    }
}
