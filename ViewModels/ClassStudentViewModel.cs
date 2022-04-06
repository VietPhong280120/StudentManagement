using StudentManagement.Models;
using System.Collections.Generic;

namespace StudentManagement.ViewModels
{
    public class ClassStudentViewModel
    {
        public int Id { get; set; }

        public string [] StudentName { get; set; }
        public string[] ClassName { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
