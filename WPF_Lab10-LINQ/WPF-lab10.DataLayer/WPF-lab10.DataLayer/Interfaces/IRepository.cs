using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_lab10.DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        T Get(T t);
        void Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
