using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Layer.Models;
using TrackerEnabledDbContext.Common.Models;

namespace GameDay.Models
{
    public class AddressVM
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


        public ICollection<int> EventId { get; set; }

        public List<AuditLog> Audit { get; set; }
    }
}