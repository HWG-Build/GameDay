using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Layer.DataAccessLayer;
using Domain.Layer.Models;
using GameDay.Services.Interfaces;

namespace GameDay.Services
{
    public class GameService : IGame
    {
        GameDayContext db = new GameDayContext();

        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }

        public Event FindEvent(int? id)
        {
            return db.Events.Find(id);
        }

        public void AddEvent(Event e)
        {
            db.Events.Add(e);
            SaveChanges();
        }

        public void EditEvent(Event e)
        {
            db.Entry(e).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteEvent(Event e)
        {
            db.Events.Remove(e);
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