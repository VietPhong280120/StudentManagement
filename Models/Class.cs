using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class Class
    {
       
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public IEnumerable<ClassStudent> ClassStudents { get; set; }
      
    }
}
