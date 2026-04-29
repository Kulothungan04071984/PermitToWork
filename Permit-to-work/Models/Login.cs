using System.ComponentModel.DataAnnotations;

namespace Permit_to_work.Models
{
    public class Login
    {
        [Key]
        public int loginId { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool isActive { get; set; }
    }

}
