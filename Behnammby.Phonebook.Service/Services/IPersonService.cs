using System.Collections.Generic;
using System.Threading.Tasks;
using Behnammby.Phonebook.Data.Models;

namespace Behnammby.Phonebook.Service.Services
{
    /// <summary>
    /// A service to work on person
    /// </summary>
    public interface IPersonService
    {
        Task<Person> CreatePersonAsync(Person person);

        /// <summary>
        /// Get a person by its id
        /// </summary>
        /// <param name="personId">The person id</param>
        /// <returns>The person or null of id is invalid</returns>
        Task<Person> GetPersonAsync(int personId);

        /// <summary>
        /// Searches for people
        /// </summary>
        /// <param name="lastName">The last name to search for</param>
        /// <param name="page">The page of result</param>
        /// <param name="limit">The limit od items in a page</param>
        /// <param name="total">Total number of results</param>
        /// <param name="firstName">The first name to search for</param>
        /// <returns>A list of people found</returns>
        /// <exception cref="Behnammby.Phonebook.Data.Exceptions.PaginationException">Thrown when page number or limit is less than 1</exception>
        IEnumerable<Person> FindPerson(string lastName, int page, int limit, out int total, string firstName = null);

        /// <summary>
        /// Updates a person info
        /// </summary>
        /// <param name="person">The person to update</param>
        void UpdatePerson(Person person);

        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="person">The person to delete</param>
        void DeletePerson(Person person);
    }
}