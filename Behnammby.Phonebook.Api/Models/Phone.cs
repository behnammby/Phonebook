using System;
using Behnammby.Phonebook.Data.Models;

namespace Behnammby.Phonebook.Api.Models
{
    public class Phone
    {
        public Phone()
        {
        }
        
        public Phone(PhoneNumber phoneNumber)
        {
            Id = phoneNumber.Id;
            Label = phoneNumber.Label;
            Number = phoneNumber.Number;
            CreatedOn = phoneNumber.CreatedOn;
            ModifiedOn = phoneNumber.UpdatedOn;
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}