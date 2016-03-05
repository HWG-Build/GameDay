using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Layer;
using Data.Layer.Models;
using TrackerEnabledDbContext.Common.Models;


namespace GameDay.Models
{
    public class EventDetailsPartialVM
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
        public DateTime DateTime { get; set; }

        [StringLength(50)]
        [Display(Name = Constant.ViewModels.Location)]
        public string AddressName { get; set; }

        [Display(Name = Constant.ViewModels.PlayerCount)]
        public int? PlayerCount { get; set; }

        public Address Location { get; set; }

        //No stringlength is added because this string can become very long.
        public string PlayersAttending { get; set; }

        public List<string> PlayerAttendingList { get; set; }

        public List<AuditLog> Audit { get; set; }
    }
}