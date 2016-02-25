using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Layer.Models;

namespace GameDay.Models
{
    public class EventVM
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public GameType Game { get; set; }

        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Time { get; set; }

        [Required]
        public int AddressId { get; set; }

        public List<int> PlayerId { get; set; }
    }
}