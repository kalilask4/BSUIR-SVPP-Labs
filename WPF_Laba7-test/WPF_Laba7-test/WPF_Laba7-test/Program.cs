using Microsoft.EntityFrameworkCore;
using System;
using WPF_Laba7_test.Data;
using WPF_Laba7_test.Entities;

namespace WPF_Laba7_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var connStr = "Server=(localdb)\\mssqllocaldb; Database = CoinDb; Trusted_Connection=True; MultipleActiveResultSets=true";             

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var options = builder.UseSqlServer(connStr).Options; 

            var context = new AppDbContext(options);

            //context.Database.EnsureCreated(); //check: db created

            //context.Departments.Add(new Department {
            //    Name = "Sales"
            //});


            var dept = context.Departments.Include(d => d.Persons)
                .FirstAsync(d => d.Name == "Sales")
                .Result;

            //dept.Persons.Add(new Person { Name = "Vova" }); //неявно, работает, если List<Person> и Department virtual
            //dept.Persons.Add(new Person { Name = "Vova" });
            dept.Persons.Add(new Person { Name = "Bob" });


            //var pers = new Person { Name = "Bob" };
            //pers.DepartmentId = dept.DepartmentId;



            context.SaveChanges();




        }
    } 
}
