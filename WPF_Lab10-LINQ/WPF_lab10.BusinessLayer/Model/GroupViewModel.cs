﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_lab10.BusinessLayer.Model
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public string CourseName { get; set; }
        public DateTime Commence { get; set; }
        public decimal BasePrice { get; set; }
        public ObservableCollection<StudentViewModel> Students { get; set; }
                
    }
}
