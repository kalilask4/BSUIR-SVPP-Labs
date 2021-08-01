using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lab10.DataLayer.EFContext;
using WPF_lab10.DataLayer.Entities;
using WPF_lab10.DataLayer.Interfaces;

namespace WPF_lab10.DataLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Group> Groups { get; }
        IRepository<Student> Students { get; }

        void Save();
    }
}
