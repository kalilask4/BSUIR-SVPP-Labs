using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lab10.DataLayer.EFContext;
using WPF_lab10.DataLayer.Entities;
using WPF_lab10.DataLayer.Interfaces;

namespace WPF_lab10.DataLayer.Repositories
{

    public class EFUnitOfWorks : IUnitOfWork
    {
        CoursesContext context;
        GroupsRepository groupsRepository;
        StudentsRepository studentsRepository;

        public EFUnitOfWorks(string nameStringConnection)
        {
            context = new CoursesContext(nameStringConnection);
        }

        //
        public IRepository<Group> Groups
        {
            get
            {
                if (groupsRepository == null)
                    groupsRepository = new GroupsRepository(context);
                return groupsRepository;
            }
        }
            

        public IRepository<Student> Students
        {
            get
            {
                if (studentsRepository == null)
                    studentsRepository = new StudentsRepository(context);
                return studentsRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
                disposed = true;

            }
        }

        public  void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
