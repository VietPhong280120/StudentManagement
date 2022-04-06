using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class Student 
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateofBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public IEnumerable<ClassStudent> ClassStudents { get; set; }
      
    }
}
