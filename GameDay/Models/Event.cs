using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameDay.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public Address Location { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }


}