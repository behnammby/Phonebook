namespace Behnammby.Phonebook.Api.Models
{
    public class Search
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}