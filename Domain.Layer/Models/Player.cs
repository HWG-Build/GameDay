using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Layer.Models
{
    [TrackChanges]
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