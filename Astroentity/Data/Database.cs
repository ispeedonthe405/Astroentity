using Microsoft.EntityFrameworkCore;
using System;

namespace Astroentity.Data
{
    internal class Database : DbContext
    {
        /////////////////////////////////////////////////////////
        #region Properties

        public string DbPath { get; } = string.Empty;
        public DbSet<Record_Options> Options { get; set; }
        public DbSet<Record_Galaxy> Galaxies { get; set; }
        public DbSet<Record_Nebula> Nebulae { get; set; }
        public DbSet<Record_Star> Stars { get; set; }

        #endregion Properties
        /////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////
        #region Interface

        public Database()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, $"{App.AppTitle}", "database.db");
        }

        #endregion Interface
        /////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////
        #region Internal

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion Internal
        /////////////////////////////////////////////////////////


    }
}
