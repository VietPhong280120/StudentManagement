using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public IEnumerable<int> StudentIds { get; set; }
    }
}
