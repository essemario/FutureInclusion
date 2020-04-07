using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Poll
    {
        public Poll()
        {
            Choice = new HashSet<Choice>();
            Post = new HashSet<Post>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("start", TypeName = "datetime")]
        public DateTime Start { get; set; }
        [Column("end", TypeName = "datetime")]
        public DateTime End { get; set; }
        [Column("description", TypeName = "longtext")]
        public string Description { get; set; }
        [Column("tag", TypeName = "varchar(255)")]
        public string Tag { get; set; }
        [Column("MANDATE_id", TypeName = "int(10) unsigned")]
        public uint MandateId { get; set; }

        [ForeignKey(nameof(MandateId))]
        [InverseProperty("Poll")]
        public virtual Mandate Mandate { get; set; }
        [InverseProperty("Poll")]
        public virtual ICollection<Choice> Choice { get; set; }
        [InverseProperty("Poll")]
        public virtual ICollection<Post> Post { get; set; }
    }
}
