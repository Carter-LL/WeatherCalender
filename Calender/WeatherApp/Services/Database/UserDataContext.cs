using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WeatherApp.Models.SQL.Tables;

namespace WeatherApp.Services.Database
{
    public class UserDataContext : DbContext
    {
        public DbSet<UserDataModel> Userdata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=150.136.90.68;Database=calenderdb;User=publicuser;Password=publicuser;Port=6548;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDataModel>()
                .ToTable("userdata").HasKey(u => u.Desktop);
        }
    }
}
