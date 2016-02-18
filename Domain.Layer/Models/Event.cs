using System;
using System.Collections.Generic;

namespace Domain.Layer.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public GameType Game { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public AddressType Location { get; set; }
        

        public virtual ICollection<Player> Players { get; set; }
    }

    public enum GameType
    {
        Baseball, Basketball, Football, Poker, Soccer
    }
    
    public enum AddressType
    {
        
    }


}