using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerEnabledDbContext.Common.Models;


namespace Data.Layer.Models
{
    [TrackChanges]
    public class Event
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public GameType Game { get; set; }

        [Required]
        //[StringLength(50)]
        public DateTime DateTime { get; set; }

        [Required]
        public int AddressId { get; set; }

        public string PlayersAttending { get; set; }

        [ForeignKey(Constant.Model.AddressId)]
        public virtual Address Location { get; set; }

        public virtual ICollection<Player> Players { get; set; }


        [NotMapped]
        public virtual List<AuditLog> AuditLogs { get; set; }
    }

    public enum GameType
    {
        Baseball=0,
        Basketball=1,
        Football=2,
        Poker=3,
        Soccer=4
    }
    
}