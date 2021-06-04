using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Laba7_test.Entities
{
    class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        //навигационные свойства
        public int DepartmentId { get; set; }
        public Department Department { get; set; } 
    }
}
