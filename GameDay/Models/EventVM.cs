using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Layer.Models;
using Domain.Layer;
using TrackerEnabledDbContext.Common.Models;

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
        //[DisplayFormat(DataFormatString = "{0:ddd, d MMM yyyy}")]
        [StringLength(50)]
        public string Date { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "hh:mm tt")]
        [StringLength(50)]
        public string Time { get; set; }

        
        [StringLength(50)]
        [Display(Name = Constant.ViewModels.Location)]
        public string AddressName { get; set; }

        public List<Address> Addresses { get; set; }

        public IEnumerable<SelectListItem> AddressList => new SelectList(Addresses, "ID", "Name", AddressId);

        public Address Location { get; set; }

        [Display(Name = Constant.ViewModels.Location)]
        public int AddressId { get; set; }

        public List<string> PlayerNames { get; set; }

        public List<int> PlayerId { get; set; }

        public List<AuditLog> Audit { get; set; } 
    }
}

//public IEnumerable<SelectListItem> AddressList => Addresses.Select(x => new SelectListItem { Value = ID.ToString(), Text = x.Name });