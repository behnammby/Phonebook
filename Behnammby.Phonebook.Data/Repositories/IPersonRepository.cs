using System.Collections.Generic;
using System.Threading.Tasks;
using Behnammby.Phonebook.Data.Models;
using Behnammby.Uow.Repositories;

namespace Behnammby.Phonebook.Data.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        /// <summary>
        /// Get a person by its id
        /// </summary>
        /// <param name="id">The id of person</param>
        /// <returns>The person found or null if not found</returns>
        Task<Person> GetByIdAsync(int id);

        /// <summary>
        /// Finds a list of people by their first name and last name
        /// </summary>
        /// <param name="lastName">The last name of person</param>
        /// <param name="page">The page of result</param>
        /// <param name="limit">How many people to limit on a page</param>
        /// <param name="total">Total number of people in search result</param>
        /// <param name="firstName">The first name of person</param>
        /// <returns>A list of people</returns>
        /// <exception cref="Behnammby.Phonebook.Data.Exceptions.PaginationException">Thrown when page number or limit is not valid</exception>
        IEnumerable<Person> FindByName(string lastName, int page, int limit, out int total, string firstName = null);
    }
}