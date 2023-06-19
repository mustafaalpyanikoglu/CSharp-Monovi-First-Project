namespace Entities.Concrete
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public User()
        {

        }

        public User(int id, string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt, int roleId) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            RoleId = roleId;
        }
    }
}
