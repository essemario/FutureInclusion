using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    [Table("Mandate_Voter")]
    public partial class MandateVoter
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("VOTERS_id", TypeName = "int(10) unsigned")]
        public uint VotersId { get; set; }
        [Column("MANDATES_id", TypeName = "int(10) unsigned")]
        public uint MandatesId { get; set; }

        [ForeignKey(nameof(MandatesId))]
        [InverseProperty(nameof(Mandate.MandateVoter))]
        public virtual Mandate Mandates { get; set; }
        [ForeignKey(nameof(VotersId))]
        [InverseProperty(nameof(Voter.MandateVoter))]
        public virtual Voter Voters { get; set; }
    }
}
