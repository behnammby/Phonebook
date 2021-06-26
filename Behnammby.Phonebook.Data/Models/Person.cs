using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Behnammby.Phonebook.Data.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirsName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}