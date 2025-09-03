using System.ComponentModel.DataAnnotations;

namespace collegeApp.Model
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
