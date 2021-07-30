using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_lab10.DataLayer.EFContext
{
    class Group
    {
        public int GroupId { get; set; }
        public string CourseName { get; set; }
        public DateTime Commence { get; set; }
        public decimal BasePrice { get; set; }
        public List<Student> students { get; set; }

        public Group()
        {
            students = new List<Student>();
        }
    }
}
