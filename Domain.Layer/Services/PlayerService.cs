using Domain.Layer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain.Layer.Models;
using Domain.Layer.Interfaces;

namespace Domain.Layer.Services
{
    public class PlayerService : IService<Player>
    {
        GameDayContext db = new GameDayContext();

        public List<Player> GetRecords()
        {
            return db.Players.ToList();
        }

        public Player FindRecord(int? id)
        {
            return db.Players.Find(id);
        }

        public void AddRecord(Player p)
        {
            db.Players.Add(p);
            SaveChanges();
        }

        public void EditRecord(Player p)
        {
            db.Entry(p).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteRecord(Player p)
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