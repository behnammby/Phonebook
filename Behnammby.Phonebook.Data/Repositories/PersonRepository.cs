using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behnammby.Phonebook.Data.Context;
using Behnammby.Phonebook.Data.Exceptions;
using Behnammby.Phonebook.Data.Models;
using Behnammby.Uow.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Behnammby.Phonebook.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PhonebookDbContext context) : base(context)
        {
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await GetAll().Where(person => person.Id == id && !person.IsDeleted)
                                 .Include(person => person.PhoneNumbers)
                                 .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> FindByNameAsyc(string lastName, int page, int limit, string firstName = null)
        {
            if (page <= 0 || limit <= 0)
            {
                throw new PaginationException();
            }

            var skipCount = (page - 1) * limit;

            var query = GetAll().Where(person => !person.IsDeleted);

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(person => person.FirsName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(person => person.LastName.Contains(lastName));
            }

            return await query.Skip(skipCount).Take(limit).ToListAsync();
        }
        
    }
}