using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WPF_Laba8_EF.Models
{
    class DataBaseInitializer: DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Students.AddRange(new Student[]
            {
                new Student{Fullname="Soyer", Age = 23, Payment = 344, GroupId=1},
                new Student{Fullname="Kate Ostin", Age = 22, Payment = 322, GroupId=2},
                new Student{Fullname="Lili Pirs", Age = 24, Payment = 422, GroupId=2},
            });
        }
    }
}
