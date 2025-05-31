using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace collegeApp.Model
{
    public class StudentDTO
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
