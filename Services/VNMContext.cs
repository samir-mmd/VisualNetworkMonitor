using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VNM2020.Models;
using Action = VNM2020.Models.Action;

namespace VNM2020.Services
{
    public class VNMContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<GlobalSettings> Globals { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=vnm.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
