using System.Linq;
using System.Threading.Tasks;

namespace Behnammby.Uow.Repositories
{
    /// <summary>
    /// An interface for repository
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity">Entity to persist</param>
        /// <returns>The stored entity</returns>
        Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        /// Get a queryable of DbSet
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Updates an already stored entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes an existing entity in the repository
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}