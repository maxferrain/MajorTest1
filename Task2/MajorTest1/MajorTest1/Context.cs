using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MajorTest1
{
    public class Context : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Data Source='/Users/maximilienk/MEPHI/appletv.db'");
        }
    }
}
