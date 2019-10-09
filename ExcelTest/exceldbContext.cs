using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExcelTest
{
    public class exceldbContext : DbContext
    {
        public virtual DbSet<University> University { get; set; }
        public exceldbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=exceldb;Trusted_Connection=True;");
            }
        }
    }
}
