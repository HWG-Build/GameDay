﻿using Domain.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameDay.Models
{
    public class PlayerVM
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = Constant.ViewModels.FirstName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = Constant.ViewModels.LastName)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string Position { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        public List<int> EventId { get; set; }

    }
}