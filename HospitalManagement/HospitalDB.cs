using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement
{
    public class HospitalDB : DbContext
    {
        string connectionString = @"Server=(localdb)\Mahmut;Database=HospitalDB;Trusted_Connection=True;";
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Appointments> Appointments { get; set; }

        public HospitalDB() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
