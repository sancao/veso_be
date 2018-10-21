namespace veso_be.Entities
{
    public class User
    {
        public int Id { get; set; }
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}