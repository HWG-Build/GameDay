using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameDay.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public float Zip { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }

    public enum State
    {
        CA
    }
}