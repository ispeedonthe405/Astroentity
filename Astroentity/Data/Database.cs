using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Astroentity.Data
{
    internal class DataContext : DbContext
    {
        /////////////////////////////////////////////////////////
        #region Properties

        public string DbFolder { get; private set; } = string.Empty;
        public string DbPath { get; } = string.Empty;
        public DbSet<Record_Options> Options { get; set; }
        public DbSet<Record_Galaxy> Galaxies { get; set; }
        public DbSet<Record_Nebula> Nebulae { get; set; }
        public DbSet<Record_Star> Stars { get; set; }

        #endregion Properties
        /////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////
        #region Interface

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbFolder = System.IO.Path.Join(path, $"{App.AppTitle}");
            DbPath = System.IO.Path.Join(DbFolder, "database.db");

            sbdotnet.IO.EnsureFolder(DbFolder);

            Preload();
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

        private void Preload()
        {
            var x = Galaxies.Count();
            if(Galaxies.Count() == 0)
            {
                try
                {
                    string json = sbdotnet.AssemblyUtils.LoadResourceString("Astroentity.Data.Preload.galaxies.json");
                    var records = JsonSerializer.Deserialize<List<Record_Galaxy>>(json);
                    if (records is not null)
                    {
                        Galaxies.AddRange(records);
                        SaveChanges(true);
                    }
                }
                catch(Exception ex)
                {
                    sbdotnet.Logger.Error(ex);
                    if(ex.InnerException is not null)
                    {
                        sbdotnet.Logger.Error(ex.InnerException);
                    }
                }
            }

            if (Nebulae.Count() == 0)
            {
                try
                {
                    string json = sbdotnet.AssemblyUtils.LoadResourceString("Astroentity.Data.Preload.nebulae.json");
                    var records = JsonSerializer.Deserialize<List<Record_Nebula>>(json);
                    if (records is not null)
                    {
                        Nebulae.AddRange(records);
                        SaveChanges(true);
                    }
                }
                catch (Exception ex)
                {
                    sbdotnet.Logger.Error(ex);
                    if (ex.InnerException is not null)
                    {
                        sbdotnet.Logger.Error(ex.InnerException);
                    }
                }
            }

            if (Stars.Count() == 0)
            {
                try
                {
                    string json = sbdotnet.AssemblyUtils.LoadResourceString("Astroentity.Data.Preload.stars.json");
                    var records = JsonSerializer.Deserialize<List<Record_Star>>(json);
                    if (records is not null)
                    {
                        Stars.AddRange(records);
                        SaveChanges(true);
                    }
                }
                catch (Exception ex)
                {
                    sbdotnet.Logger.Error(ex);
                    if (ex.InnerException is not null)
                    {
                        sbdotnet.Logger.Error(ex.InnerException);
                    }
                }
            }
        }

        #endregion Internal
        /////////////////////////////////////////////////////////


    }
}
