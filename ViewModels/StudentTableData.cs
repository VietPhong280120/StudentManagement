using StudentManagement.Models;
using System.Collections.Generic;

namespace StudentManagement.ViewModels
{
    public class StudentTableData
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int Draw { get; set; }
        public IEnumerable<StudentViewModel> Data { get; set; }
    }
}
