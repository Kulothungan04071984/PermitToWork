namespace Permit_to_work.Models
{
    public enum UserRole
    {
        Admin = 1,
        Safety = 2,
        Electrical = 3
    }

    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public string Department { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
