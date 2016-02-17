using System.Collections.Generic;

namespace Domain.Layer.Models
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