using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Layer.Models;

namespace Domain.Layer.DataAccessLayer
{
    public class GameDayContext : DbContext
    {
        public GameDayContext() : base("GameDay")
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

