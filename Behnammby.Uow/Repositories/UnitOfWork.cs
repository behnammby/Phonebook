using Microsoft.EntityFrameworkCore;

namespace Behnammby.Uow.Repositories
{
    /// <inheritdoc/>
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext _context)
        {
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}