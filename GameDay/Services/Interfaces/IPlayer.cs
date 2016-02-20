using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models;

namespace GameDay.Services.Interfaces
{
    public interface IPlayer
    {
        List<Player> GetPlayers();
        Player FindPlayer(int? id);
        void AddPlayer(Player a);
        void EditPlayer(Player a);
        void DeletePlayer(Player a);
        void SaveChanges();
        void Dispose();
    }
}
