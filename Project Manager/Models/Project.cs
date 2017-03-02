using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

namespace Project_Manager.Models
{
    public class Project
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
    public class Tasking
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string User { get; set; }


    }
    public class  TestDbContext: DbContext
    { public DbSet<Project> Projects { get; set; }
      public DbSet<Tasking> Taskings { get; set; } 
    }

}