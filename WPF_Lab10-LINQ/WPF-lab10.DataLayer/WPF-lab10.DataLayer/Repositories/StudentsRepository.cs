using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lab10.DataLayer.EFContext;
using WPF_lab10.DataLayer.Entities;
using WPF_lab10.DataLayer.Interfaces;

namespace WPF_lab10.DataLayer.Repositories
{
    class StudentsRepository : IRepository<Student>
    {
        CoursesContext context;

        public StudentsRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Student t)
        {
            context.Students.Add(t);
        }

        public void Delete(int id)
        {
            var student = context.Students.Find(id);
            context.Students.Remove(student);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return context.Students.Where(predicate).ToList();
        }

        public Student Get(int id)
        {
            return context.Students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students;
        }

        public void Update(Student t)
        {
            //context.Entry<Student>(t).State = EntityState.Modified;
            var student = context.Students.Find(t.StudentId);
            student.FullName = t.FullName;
            student.DateOfBirth = t.DateOfBirth;
            student.IndividualPrice = t.IndividualPrice;
            student.FileName = t.FileName;
        }
    }
}
