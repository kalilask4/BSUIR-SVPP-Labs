using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WPF_Laba8_EF.Models
{
    class EntityContext:DbContext
    {
        public EntityContext(): base("DefaultConnection")
        {}
        public DbSet<Student> Students { get; set; }
    }

}
