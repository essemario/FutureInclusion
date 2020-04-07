using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    [Table("Voter_Choice")]
    public partial class VoterChoice
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("time", TypeName = "timestamp")]
        public DateTime Time { get; set; }
        [Column("CHOICES_id", TypeName = "int(10) unsigned")]
        public uint ChoicesId { get; set; }
        [Column("VOTERS_id", TypeName = "int(10) unsigned")]
        public uint VotersId { get; set; }

        [ForeignKey(nameof(ChoicesId))]
        [InverseProperty(nameof(Choice.VoterChoice))]
        public virtual Choice Choices { get; set; }
        [ForeignKey(nameof(VotersId))]
        [InverseProperty(nameof(Voter.VoterChoice))]
        public virtual Voter Voters { get; set; }
    }
}
