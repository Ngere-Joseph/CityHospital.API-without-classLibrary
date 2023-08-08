using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CityInfo.API
{
    public class AppDbContext : DbContext
    {

        public DbSet<City> cities { get; set; } = null!;
        public DbSet<Hospital> hospitals { get; set; } = null!;

        //Create a constructor thats calls the overload of the constructor
        //This will provide this options at the moment we register our DBcontext, using a method overload
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

    }
}
