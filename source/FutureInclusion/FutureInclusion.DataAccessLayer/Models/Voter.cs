using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Voter
    {
        public Voter()
        {
            MandateVoter = new HashSet<MandateVoter>();
            VoterChoice = new HashSet<VoterChoice>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("last_name", TypeName = "varchar(255)")]
        public string LastName { get; set; }
        [Column("email", TypeName = "varchar(255)")]
        public string Email { get; set; }
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }
        [Column("document", TypeName = "varchar(45)")]
        public string Document { get; set; }
        [Column("enabled")]
        public bool? Enabled { get; set; }

        [InverseProperty("Voters")]
        public virtual ICollection<MandateVoter> MandateVoter { get; set; }
        [InverseProperty("Voters")]
        public virtual ICollection<VoterChoice> VoterChoice { get; set; }
    }
}
