using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lab10.DataLayer.Entities;

namespace WPF_lab10.DataLayer.EFContext
{
    
class CoursesContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public CoursesContext()
        {
            Database.SetInitializer(new CoursesInitializer());
        }


    }
}
