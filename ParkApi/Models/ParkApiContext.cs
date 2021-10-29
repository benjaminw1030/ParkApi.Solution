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
          new Park { ParkId = 1, Name = "Grand Canyon", Category = "National", State = "Arizona", Longitude = -112.14, Latitude = 36.06, Area = 4926.08, Visitors = 2897098, EstDate = DateTime.Parse("1919-02-26") }
        );
    }
  }
}