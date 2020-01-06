using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement
{
    public class HospitalDB : DbContext
    {
        string connectionString = @"Server=(localdb)\Mahmut;Database=HospitalDB;Trusted_Connection=True;";
        public DbSet<Doctors> Doctors { get; set; }
        public HospitalDB() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
