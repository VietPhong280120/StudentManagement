using StudentManagement.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [DataType(DataType.Date)] 
        public string DateofBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }      
        public IEnumerable<ClassViewModel> Classes { get; set; }
        public IEnumerable<int> ClassIds { get; set; }
    }
}
