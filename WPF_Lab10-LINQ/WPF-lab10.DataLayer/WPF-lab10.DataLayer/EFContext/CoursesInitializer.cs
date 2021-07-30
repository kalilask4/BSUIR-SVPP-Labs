using WPF_lab10.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPF_lab10.DataLayer.EFContext
{
    class CoursesInitializer : CreateDatabaseIfNotExists<CoursesContext>
    {
        protected override void Seed(CoursesContext context)
        {
            context.groups.AddRange(new Group[]
            {
                new Group
                {
                    BasePrice = 100,
                    Commence = new DateTime(2021,01,21),
                    CourseName = "Знакомство с Adobe Photoshop",
                    students = new List<Student>
                    {
                        new Student
                        {
                            FullName = "Margo Roby",
                            DateOfBirth = new DateTime(1999,10,23),
                            IndividualPrice = 100,
                            FileName = "1.jpg"
                        },
                         new Student
                        {
                            FullName = "Inn K",
                            DateOfBirth = new DateTime(1990,10,23),
                            IndividualPrice = 300,
                            FileName = "2.jpg"
                        },
                    }
                },

                                new Group
                {
                    BasePrice = 100, Commence = new DateTime(2020,05,29),
                    CourseName = "Python. Professional lvl",
                    students = new List<Student>
                    {
                        new Student
                        {
                            FullName = "Mary",
                            DateOfBirth = new DateTime(1999,09,05),
                            IndividualPrice = 180,
                            FileName = "3.jpg"
                        },
                         new Student
                        {
                            FullName = "A.S.",
                            DateOfBirth = new DateTime(1990,12,25),
                            IndividualPrice = 200,
                            FileName = "4.jpg"
                        },
                    }
                }
            });

            context.SaveChanges();
        }

    }
}
