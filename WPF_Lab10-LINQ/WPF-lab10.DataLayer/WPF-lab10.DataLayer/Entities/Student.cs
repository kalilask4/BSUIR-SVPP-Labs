﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_lab10.DataLayer.EFContext
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal IndividualPrice { get; set; }
        public string FileName { get; set; }
        public int GroupId { get; set; }
        public Group group { get; set; }
    }
}
