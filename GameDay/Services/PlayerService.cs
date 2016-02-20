using Domain.Layer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain.Layer.Models;
using GameDay.Services.Interfaces;

namespace GameDay.Services
{
    public class PlayerService : IPlayer
    {
        GameDayContext db = new GameDayContext();

        public List<Player> GetPlayers()
        {
            return db.Players.ToList();
        }

        public Player FindPlayer(int? id)
        {
            return db.Players.Find(id);
        }

        public void AddPlayer(Player p)
        {
            db.Players.Add(p);
            SaveChanges();
        }

        public void EditPlayer(Player p)
        {
            db.Entry(p).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeletePlayer(Player p)
        {
            db.Players.Remove(p);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}