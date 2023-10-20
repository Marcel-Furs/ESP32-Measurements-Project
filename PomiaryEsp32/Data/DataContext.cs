using Microsoft.EntityFrameworkCore;
using PomiaryEsp32.Data.Models;

namespace PomiaryEsp32.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Measurement>().HasData(new Measurement
            {
                Id = 1,
                Date = new DateTime(2023, 5, 15),
                Humidity = 50,
                Temperature = 20
            }, new Measurement
            {
                Id=2,
                Date = new DateTime(2023, 5, 14),
                Humidity = 67,
                Temperature = 22
            },
            new Measurement
            {
                Id=3,
                Date = new DateTime(2023, 5, 13),
                Humidity = 45,
                Temperature = 19
            });
        }
    }
}
