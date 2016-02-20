using System.Collections.Generic;
using Domain.Layer.Models;

namespace GameDay.Services.Interfaces
{
    public interface IGame
    {
        List<Event> GetEvents();
        Event FindEvent(int? id);
        void AddEvent(Event e);
        void EditEvent(Event e);
        void DeleteEvent(Event e);
        void SaveChanges();
        void Dispose();
    }
}
