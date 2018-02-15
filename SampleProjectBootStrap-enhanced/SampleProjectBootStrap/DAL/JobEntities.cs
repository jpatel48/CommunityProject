using ProjectPlanning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SampleProjectBootStrap.DAL
{
    public class JobEntities : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Posting> Postings { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //This option keeps table names in singular form, my personal preference.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<SampleProjectBootStrap.Models.FileStore> FileStores { get; set; }

        public System.Data.Entity.DbSet<SampleProjectBootStrap.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<SampleProjectBootStrap.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<SampleProjectBootStrap.Models.Province> Provinces { get; set; }
        public System.Data.Entity.DbSet<SampleProjectBootStrap.Models.FTE> FTEs { get; set; }
        public System.Data.Entity.DbSet<SampleProjectBootStrap.Models.JobCode> JobCodes { get; set; }

    }
}