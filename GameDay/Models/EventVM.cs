using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Layer.Models;
using Data.Layer;
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
        [Display(Name = Constant.ViewModels.DateTime)]
        //[StringLength(50)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-mm-dd hh:mm am}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Time { get; set; }

        
        [StringLength(50)]
        [Display(Name = Constant.ViewModels.Location)]
        public string AddressName { get; set; }

        public List<Address> Addresses { get; set; }

        public IEnumerable<SelectListItem> AddressList => new SelectList(Addresses, Constant.ViewModels.ID, Constant.ViewModels.Name, AddressId);

        public Address Location { get; set; }

        [Display(Name = Constant.ViewModels.Location)]
        public int AddressId { get; set; }

        //No stringlength is added because this string can become very long.
        public string PlayersAttending { get; set; }

        public List<string> PlayerAttendingList { get; set; } 

        public List<AuditLog> Audit { get; set; } 
    }
}

