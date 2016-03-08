using Data.Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameDay.Models
{
    public class AddressListVM
    {
        public class AddressBucket
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
        }

        public Address AddressSingle { get; set; }
        public IEnumerable<AddressBucket> AddressList { get; set; }
    }
}
