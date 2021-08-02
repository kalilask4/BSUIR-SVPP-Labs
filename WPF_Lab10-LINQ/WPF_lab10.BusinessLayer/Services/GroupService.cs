using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lab10.BusinessLayer.Interfaces;
using WPF_lab10.BusinessLayer.Model;
using WPF_lab10.DataLayer.Entities;
using WPF_lab10.DataLayer.Interfaces;
using WPF_lab10.DataLayer.Repositories;

namespace WPF_lab10.BusinessLayer.Services
{
    class GroupService : IGroupService
    {
        IUnitOfWork database;

        public GroupService(string nameStringConnection)
        {
            database = new EFUnitOfWorks(nameStringConnection);
        }
        public void AddStudentToGroup(int groupId, StudentViewModel studentViewModel)
        {
            var group = database.Groups.Get(groupId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentViewModel>());
            var mapper = new Mapper(config);
            var student = mapper.Map<StudentViewModel, Student>(studentViewModel);
            student.IndividualPrice = studentViewModel.HasDiscont
                ? group.BasePrice * (decimal)0.8
                : group.BasePrice;
            group.Students.Add(student);
            database.Save();
        }

        public void CreateGroup(GroupViewModel group)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public GroupViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<GroupViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudentFromGroup(int groupId, int studentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(GroupViewModel group)
        {
            throw new NotImplementedException();
        }
    }
}
