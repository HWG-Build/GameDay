using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Layer.Models;
using Domain.Layer;

namespace GameDay.Models
{
    public class EventVM
    {
        [Required]
        public int ID { get; set; }

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

        
        [StringLength(50)]
        [Display(Name = Constant.ViewModels.Location)]
        public string AddressName { get; set; }

        public List<Address> AddressList { get; set; }

        public int AddressId { get; set; }

        public List<string> PlayerNames { get; set; }

        public List<int> PlayerId { get; set; }
    }
}