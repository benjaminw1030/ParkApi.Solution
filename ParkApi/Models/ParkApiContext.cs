using Microsoft.EntityFrameworkCore;
using System;

namespace ParkApi.Models
{
  public class ParkApiContext : DbContext
  {
    public ParkApiContext(DbContextOptions<ParkApiContext> options) : base(options)
    {
    }

    public DbSet<Park> Parks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Grand Canyon", Category = "National", State = "Arizona", Longitude = -112.14, Latitude = 36.06, Area = 4926, Visitors = 2897098, EstDate = DateTime.Parse("1919-02-26") },
          new Park { ParkId = 2, Name = "Silver Falls", Category = "State", State = "Oregon", Longitude = -122.36, Latitude = 44.86, Area = 36, Visitors = 1100000, EstDate = DateTime.Parse("1933-07-23") },
          new Park { ParkId = 3, Name = "Everglades", Category = "National", State = "Florida", Longitude = -80.93, Latitude = 25.32, Area = 6106, Visitors = 702319, EstDate = DateTime.Parse("1934-05-30") },
          new Park { ParkId = 4, Name = "Painted Hills", Category = "State", State = "Oregon", Longitude = -120.27, Latitude = 44.66, Area = 13, Visitors = 74873, EstDate = DateTime.Parse("1919-02-26") },
          new Park { ParkId = 5, Name = "Yosemite", Category = "National", State = "California", Longitude = -119.50, Latitude = 37.83, Area = 3083, Visitors = 2268313, EstDate = DateTime.Parse("1975-10-08") }
        );
    }
  }
}