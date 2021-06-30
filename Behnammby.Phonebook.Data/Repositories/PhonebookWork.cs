using Behnammby.Phonebook.Data.Context;
using Behnammby.Uow.Repositories;

namespace Behnammby.Phonebook.Data.Repositories
{
    /// <inheritdoc/>
    public class PhonebookWork : UnitOfWork, IPhonebookWork
    {
        public PhonebookWork(PhonebookDbContext context) : base(context)
        {
            PersonRepository = new PersonRepository(context);
        }

        public IPersonRepository PersonRepository { get; private set; }
    }
}