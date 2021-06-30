using System.Collections.Generic;

namespace Behnammby.Phonebook.Api.Models
{
    public class ContactsList
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentLimit { get; set; }
        public int TotalContacts { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}