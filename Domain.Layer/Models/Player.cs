using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Layer.Models
{
    [TrackChanges]
    public class Player
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string Position { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}