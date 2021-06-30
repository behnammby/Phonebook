using System;
using System.Collections.Generic;
using System.Linq;
using Behnammby.Phonebook.Data.Models;

namespace Behnammby.Phonebook.Api.Models
{

    public class Contact
    {
        public Contact()
        {
        }
        
        public Contact(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            CreatedOn = person.CreatedOn;
            ModifiedOn = person.UpdatedOn;

            if (person.PhoneNumbers != null)
            {
                PhoneNumbers = person.PhoneNumbers.Select(number => new Phone(number));
            }
            else
            {
                PhoneNumbers = new List<Phone>();
            }
        }

        public int Id { get; set; } = default;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public IEnumerable<Phone> PhoneNumbers { get; set; }
    }
}