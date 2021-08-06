﻿using AutoMapper;
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
    public class GroupService : IGroupService
    {
        IUnitOfWork dataBase;

        public GroupService(string namebd)
        {
            dataBase = new EFUnitOfWorks(namebd);   //разобраться!! здесь не имя строки подключения, а имя бд
        }
        public void AddStudentToGroup(int groupId, StudentViewModel studentViewModel)
        {
            var group = dataBase.Groups.Get(groupId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, Student>());
            var mapper = new Mapper(config);
            var student = mapper.Map<StudentViewModel, Student>(studentViewModel);
            student.IndividualPrice = studentViewModel.HasDiscont
                ? group.BasePrice * 0.8M //(decimal)0.8 - the same
                : group.BasePrice;
            group.Students.Add(student);
            dataBase.Save();
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentViewModel>();
                cfg.CreateMap<Group, GroupViewModel>();
            });
            var mapper = new Mapper(config);
            var groups = mapper.Map<IEnumerable<Group>,
                ObservableCollection<GroupViewModel>>(dataBase.Groups.GetAll());
            return groups;
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
