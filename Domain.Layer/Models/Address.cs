using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Layer.Models
{
    [TrackChanges]
    public class Address
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Line1 { get; set; }

        [StringLength(50)]
        public string Line2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public float Zip { get; set; }


        public virtual ICollection<Event> Events { get; set; }


    }


    public enum State
    {
        CA
    }
}