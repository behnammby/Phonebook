namespace Behnammby.Uow.Repositories
{
    /// <summary>
    /// An interface for unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves changes to the storage
        /// </summary>
        /// <returns>Inserted or modified count</returns>
        int Complete();
    }
}