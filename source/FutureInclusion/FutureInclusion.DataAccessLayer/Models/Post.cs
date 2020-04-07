using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Post
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("text", TypeName = "longtext")]
        public string Text { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("POLL_id", TypeName = "int(10) unsigned")]
        public uint PollId { get; set; }
        [Column("MANDATE_id", TypeName = "int(10) unsigned")]
        public uint MandateId { get; set; }

        [ForeignKey(nameof(MandateId))]
        [InverseProperty("Post")]
        public virtual Mandate Mandate { get; set; }
        [ForeignKey(nameof(PollId))]
        [InverseProperty("Post")]
        public virtual Poll Poll { get; set; }
    }
}
