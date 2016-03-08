using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerEnabledDbContext.Common.Models;

namespace Data.Layer.Models
{
    [TrackChanges]
    public class Address
    {
        [Key]
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

        public virtual ICollection<Event> Events { get; set; }

        [NotMapped]
        public virtual List<AuditLog> AuditLogs { get; set; }
    }


    public enum State
    {
        AK = 0,
        AL = 1,
        AR = 2,
        AZ = 3,
        CA = 4,
        CO = 5,
        CT = 6,
        DC = 7,
        DE = 8,
        FL = 9,
        GA = 10,
        HI = 11,
        IA = 12,
        ID = 13,
        IL = 14,
        IN = 15,
        KS = 16,
        KY = 17,
        LA = 18,
        MA = 19,
        MD = 20,
        ME = 21,
        MI = 22,
        MN = 23,
        MO = 24,
        MS = 25,
        MT = 26,
        NC = 27,
        ND = 28,
        NE = 29,
        NH = 30,
        NJ = 31,
        NM = 32,
        NV = 33,
        NY = 34,
        OH = 35,
        OK = 36,
        OR = 37,
        PA = 38,
        RI = 39,
        SC = 40,
        SD = 41,
        TN = 42,
        TX = 43,
        UT = 44,
        VA = 45,
        VT = 46,
        WA = 47,
        WI = 48,
        WV = 49,
        WY = 50
    }
}