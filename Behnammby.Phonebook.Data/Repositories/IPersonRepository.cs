using System.Collections.Generic;
using System.Threading.Tasks;
using Behnammby.Phonebook.Data.Models;
using Behnammby.Uow.Repositories;

namespace Behnammby.Phonebook.Data.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetByIdAsync(int id);
        Task<IEnumerable<Person>> FindByNameAsyc(string firstName, string lastName = null);
    }
}