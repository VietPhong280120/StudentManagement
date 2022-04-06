using System.Collections.Generic;

namespace StudentManagement.ViewModels
{
    public class ClassTableData
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int Draw { get; set; }
        public IEnumerable<ClassViewModel> Data { get; set; }
    }
}
