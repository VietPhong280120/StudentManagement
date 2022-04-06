using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set;}
        public string ReturnUrl { get; set; }
    }
}
