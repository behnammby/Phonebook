using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Behnammby.Phonebook.Data.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Number { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}