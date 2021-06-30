using System.Collections.Generic;
using System.Threading.Tasks;
using Behnammby.Phonebook.Data.Models;
using Behnammby.Phonebook.Data.Repositories;

namespace Behnammby.Phonebook.Service.Services
{
    /// <inheritdoc/>
    public class PersonService : IPersonService
    {
        private readonly IPhonebookWork _phonebookWork;

        public PersonService(IPhonebookWork phonebookWork)
        {
            _phonebookWork = phonebookWork;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            await _phonebookWork.PersonRepository.CreateAsync(person);
            _phonebookWork.Complete();

            return person;
        }

        public void DeletePerson(Person person)
        {
            _phonebookWork.PersonRepository.Delete(person);
            _phonebookWork.Complete();
        }

        public IEnumerable<Person> FindPerson(string lastName, int page, int limit, out int total, string firstName = null)
        {
            return _phonebookWork.PersonRepository.FindByName(lastName, page, limit, out total, firstName);
        }

        public async Task<Person> GetPersonAsync(int personId)
        {
            return await _phonebookWork.PersonRepository.GetByIdAsync(personId);
        }

        public void UpdatePerson(Person person)
        {
            _phonebookWork.PersonRepository.Update(person);
            _phonebookWork.Complete();
        }
    }
}