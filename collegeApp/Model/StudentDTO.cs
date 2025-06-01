using collegeApp.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace collegeApp.Model
{
    public class StudentDTO
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required(ErrorMessage ="Student name is required")]
        [StringLength(50)]
        public string StudentName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }
        /*[Range(10, 30)]
        public int Age { get; set; }*/
        public string Address { get; set; }

        /* public string Password {  get; set; }

         [Compare(nameof(Password))]
         public string ConfirmPassword {  get; set; }*/

        [DateCheck]
        public DateTime AdmissionDate { get; set; }
    }
}
