using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_lab10.DataLayer.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string CourseName { get; set; }
        public DateTime Commence { get; set; }
        public decimal BasePrice { get; set; }
        public List<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
