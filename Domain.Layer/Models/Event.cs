using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Layer.Models
{
    [TrackChanges]
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public GameType Game { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Address Location { get; set; }
        

        public virtual ICollection<Player> Players { get; set; }
    }

    public enum GameType
    {
        Baseball, Basketball, Football, Poker, Soccer
    }
    
}