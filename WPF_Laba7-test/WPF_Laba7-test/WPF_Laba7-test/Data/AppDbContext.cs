﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Laba7_test.Entities;

namespace WPF_Laba7_test.Data
{
    class AppDbContext: DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            DbSet<Person> Persons { get; set; }
            DbSet<Department> Departments { get; set; }

    }
}
