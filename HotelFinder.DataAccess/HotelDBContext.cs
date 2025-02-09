using System;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess;

public class HotelDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-KJGMM4F; Database=HotelDb;uid=sa;pwd=./kerem123");
    }
    public DbSet<Hotel> Hotels { get; set; }
}
