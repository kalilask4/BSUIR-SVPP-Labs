using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Lab9.Entities;

namespace WPF_Lab9.EFContext
{
    class CoursesContext:DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Group> groups { get; set; }

        public CoursesContext()
        { }


    }
}
