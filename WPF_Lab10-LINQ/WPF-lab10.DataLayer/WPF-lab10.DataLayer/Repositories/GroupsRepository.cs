using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lab10.DataLayer.Entities;
using WPF_lab10.DataLayer.Interfaces;

namespace WPF_lab10.DataLayer.Repositories
{
    class GroupsRepository : IRepository<Group>
    {
        public void Create(Group t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Group Get(Group t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Group t)
        {
            throw new NotImplementedException();
        }
    }
}
