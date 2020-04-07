using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
            Mandate = new HashSet<Mandate>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "int(10) unsigned")]
        public uint CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("State")]
        public virtual Country Country { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<City> City { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<Mandate> Mandate { get; set; }
    }
}
