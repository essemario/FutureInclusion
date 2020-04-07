using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Power
    {
        public Power()
        {
            Mandate = new HashSet<Mandate>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column("SPHERE_id", TypeName = "int(10) unsigned")]
        public uint SphereId { get; set; }

        [ForeignKey(nameof(SphereId))]
        [InverseProperty("Power")]
        public virtual Sphere Sphere { get; set; }
        [InverseProperty("Power")]
        public virtual ICollection<Mandate> Mandate { get; set; }
    }
}
