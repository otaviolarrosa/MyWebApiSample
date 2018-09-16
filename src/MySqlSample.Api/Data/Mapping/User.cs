namespace MySqlSample.Api.Data.Mapping
{
    public class User : Entity
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User() { }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}