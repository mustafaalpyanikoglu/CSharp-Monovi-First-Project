namespace Entities.Concrete
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public string Description { get; set; }

        public Role()
        {

        }

        public Role(int id, string roleName, string description) : this()
        {
            Id = id;
            RoleName = roleName;
            Description = description;
        }
    }
}
