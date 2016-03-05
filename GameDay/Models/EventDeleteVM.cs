using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Layer;
using Data.Layer.Models;
using TrackerEnabledDbContext.Common.Models;

namespace GameDay.Models
{
    public class EventDeleteVM
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

        public Address Location { get; set; }

    }
}