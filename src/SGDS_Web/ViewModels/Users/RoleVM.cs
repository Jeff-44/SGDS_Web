namespace SGDS_Web.ViewModels.Users
{
    public class RoleVM
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<UserVM> Members { get; set; } = new List<UserVM>();
        public IEnumerable<UserVM> NonMembers { get; set; } = new List<UserVM>();
    }
}
