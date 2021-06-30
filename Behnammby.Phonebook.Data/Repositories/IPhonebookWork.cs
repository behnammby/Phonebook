using Behnammby.Uow.Repositories;

namespace Behnammby.Phonebook.Data.Repositories
{
    public interface IPhonebookWork : IUnitOfWork
    {
        IPersonRepository PersonRepository { get; }
    }
}