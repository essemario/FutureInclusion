using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class User
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        
        [Required(ErrorMessage = "Primeiro nome obrigatório")]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [Column("email", TypeName = "varchar(100)")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required]
        [Column("last_name", TypeName = "varchar(255)")]
        public string LastName { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }
        [Column("level", TypeName = "tinyint(1) unsigned")]
        public byte Level { get; set; }
        [Column("enabled")]
        public bool? Enabled { get; set; }
        [Column("MANDATE_id", TypeName = "int(10) unsigned")]
        public uint? MandateId { get; set; }

        [ForeignKey(nameof(MandateId))]
        [InverseProperty("User")]
        public virtual Mandate Mandate { get; set; }
    }
}
