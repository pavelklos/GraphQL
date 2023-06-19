namespace HotChocolateTutorial.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue(UserRole.Guest)]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Guest, // 0
        Default, // 1
        Admin, // 2

        [GraphQLIgnore]
        SuperAdmin, // 3
    }
}
