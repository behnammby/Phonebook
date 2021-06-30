using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Behnammby.Phonebook.Api.Enumerations;
using Behnammby.Phonebook.Api.Models;
using Behnammby.Phonebook.Api.Utilities;
using Behnammby.Phonebook.Data.Models;
using Behnammby.Phonebook.Service.Services;

using static Behnammby.Phonebook.Api.Utilities.Utils;

namespace Behnammby.Phonebook.Api.Controllers
{
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IConfiguration _configuration;
        private IPersonService _personService;

        public ContactsController(IConfiguration configuration, IPersonService personService)
        {
            _configuration = configuration;
            _personService = personService;
        }

        [HttpGet]
        [Route("/api/v1/[controller]")]
        public IActionResult GetAllContacts([FromQuery] Search searchModel)
        {
            var defaultLimit = _configuration.GetValue<int>("Defaults:SearchLimit");
            NormalizeSearchModel(searchModel, defaultLimit);

            try
            {
                var people = _personService.FindPerson(searchModel.LastName, searchModel.Page, searchModel.Limit, out int total, searchModel.FirstName);

                var totalPages = Utils.ResolveTotalPages(total, searchModel.Limit);
                var links = ResolveContactsListLinks(searchModel, total, totalPages);

                return StatusCode(ResolveStatusCode(RestHttpStatusCodes.OK), new ContactsList
                {
                    Contacts = people.Select(person => new Contact(person)),
                    CurrentPage = searchModel.Page,
                    CurrentLimit = searchModel.Limit,
                    TotalContacts = total,
                    TotalPages = totalPages,
                    Links = links
                });
            }
            catch (Behnammby.Phonebook.Data.Exceptions.PaginationException)
            {
                return StatusCode(ResolveStatusCode(RestHttpStatusCodes.BadRequest), ContactExceptionCodes.InvalidPagination);
            }
        }

        [HttpPut]
        [Route("/api/v1/[controller]")]
        public async Task<IActionResult> CreateContactAsync(Contact contact)
        {
            var numbers = new List<PhoneNumber>();
            if (contact.PhoneNumbers != null)
            {
                foreach (var phone in contact.PhoneNumbers)
                {
                    numbers.Add(new PhoneNumber
                    {
                        Label = phone.Label,
                        Number = phone.Number
                    });
                }
            }

            var person = await _personService.CreatePersonAsync(new Person
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumbers = numbers
            });

            contact.Id = person.Id;

            return StatusCode((int)RestHttpStatusCodes.Created, contact);
        }

        [HttpGet]
        [Route("/api/v1/[controller]/{id}")]
        public async Task<IActionResult> GetContactAsync(int id)
        {
            var person = await _personService.GetPersonAsync(id);

            if (person != null)
            {
                return StatusCode(ResolveStatusCode(RestHttpStatusCodes.OK), person);
            }
            else
            {
                return StatusCode(ResolveStatusCode(RestHttpStatusCodes.BadRequest), ContactExceptionCodes.InvalidContactId);
            }
        }

        [HttpPost]
        [Route("/api/v1/[controller]/{id}")]
        public async Task<IActionResult> UpdateContactAsync(int id, Contact contact)
        {
            var person = await _personService.GetPersonAsync(id);

            if (person == null)
            {
                return StatusCode(ResolveStatusCode(RestHttpStatusCodes.BadRequest), ContactExceptionCodes.InvalidContactId);
            }

            person.FirstName = contact.FirstName;
            person.LastName = contact.LastName;

            _personService.UpdatePerson(person);
            return StatusCode(ResolveStatusCode(RestHttpStatusCodes.OK), contact);
        }

        [HttpDelete]
        [Route("/api/v1/[controller]/{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            var person = await _personService.GetPersonAsync(id);

            if (person == null)
            {
                return StatusCode(ResolveStatusCode(RestHttpStatusCodes.BadRequest), ContactExceptionCodes.InvalidContactId);
            }

            _personService.DeletePerson(person);
            return StatusCode(ResolveStatusCode(RestHttpStatusCodes.OK));
        }

        private IEnumerable<Link> ResolveContactsListLinks(Search searchModel, int total, int totalPages)
        {
            if (searchModel.Page > 1)
            {
                yield return new Link
                {
                    Rel = LinkRelations.Prev.ToString(),
                    Href = Url.Action(nameof(GetAllContacts), new
                    {
                        FirstName = searchModel.FirstName,
                        LastName = searchModel.LastName,
                        Page = searchModel.Page - 1,
                        Limit = searchModel.Limit
                    })
                };
            }

            if (searchModel.Page < totalPages)
            {
                yield return new Link
                {
                    Rel = LinkRelations.Next.ToString(),
                    Href = Url.Action(nameof(GetAllContacts), new
                    {
                        FirstName = searchModel.FirstName,
                        LastName = searchModel.LastName,
                        Page = searchModel.Page + 1,
                        Limit = searchModel.Limit
                    })
                };
            }
        }

        private void NormalizeSearchModel(Search model, int defaultLimit)
        {
            if (model.Page <= 0)
            {
                model.Page = 1;
            }

            if (model.Limit <= 0)
            {
                model.Limit = defaultLimit;
            }
        }
    }
}