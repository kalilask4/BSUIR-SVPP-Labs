using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Laba7_test.Entities
{
    class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        //навигационные свойства
        public virtual List<Person> Persons { get; set; } //virtual - сущности будут добавляться автоматически, иначе их необходимо добавлять явно
    }
}
