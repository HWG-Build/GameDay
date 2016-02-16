using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameDay.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GameDay.DataAccessLayer
{
    public class GameDayContext : DbContext
    {
        public GameDayContext() : base("GameDayContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Address> Locations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static GameDayContext Create()
        {
            return new GameDayContext();
        }
    }
}

