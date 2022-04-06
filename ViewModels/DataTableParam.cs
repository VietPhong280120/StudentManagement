using System.Collections.Generic;

namespace StudentManagement.ViewModels
{
    public class DataTableParam
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public Search Search { get; set; }
        public IEnumerable<OrderViewModel> Order { get; set; }
        public IEnumerable<ColumnViewModel> Columns { get; set; }

    }
    public class Search
    {
        public string Value { get; set; }
        public bool Regex { get; set; }

    }
    public class OrderViewModel
    {
        public int Column { get; set; }
        public string Dir { get; set; }

    }
    public class ColumnViewModel
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public Search Search { get; set; }
    }

}
