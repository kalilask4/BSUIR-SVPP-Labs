using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lab10.BusinessLayer.Model;

namespace WPF_lab10.BusinessLayer.Interfaces
{
    public interface IGroupService
    {
        ObservableCollection<GroupViewModel> GetAll();
        GroupViewModel Get(int id);
        void AddStudentToGroup(int groupId, StudentViewModel student);
        void RemoveStudentFromGroup(int groupId, int studentId);
        void CreateGroup(GroupViewModel group);
        void DeleteGroup(int groupId);
        void UpdateGroup(GroupViewModel group);
        void UpdateStudent(StudentViewModel studentViewModel);
    }
}
