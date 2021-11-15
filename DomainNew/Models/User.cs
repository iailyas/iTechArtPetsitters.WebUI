namespace DomainNew.Models
{
    //model of data
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Picture { get; set; }

    }
}
