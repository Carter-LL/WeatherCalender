using Microsoft.EntityFrameworkCore;
using WeatherCalender.Models.SQL.Tables;

namespace WeatherCalender.Services.Database
{
    public class PlannedEventContext : DbContext
    {
        public DbSet<PlannedEventModel> PlannedEvent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=150.136.90.68;Database=calenderdb;User=publicuser;Password=publicuser;Port=6548;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlannedEventModel>()
                .ToTable("planned_events").HasKey(u => u.Id);
        }
    }
}
