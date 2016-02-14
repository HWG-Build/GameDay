using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameDay.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}