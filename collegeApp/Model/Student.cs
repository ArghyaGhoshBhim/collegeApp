using System.ComponentModel.DataAnnotations;

namespace collegeApp.Model
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set;}
        public string Address { get; set; }
    }
}
