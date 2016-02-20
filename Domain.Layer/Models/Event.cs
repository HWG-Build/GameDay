using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Layer.Models
{
    [TrackChanges]
    public class Event
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public GameType Game { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        public Address Location { get; set; }
        

        public virtual ICollection<Player> Players { get; set; }
    }

    public enum GameType
    {
        Baseball, Basketball, Football, Poker, Soccer
    }
    
}