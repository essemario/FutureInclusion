using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Mandate
    {
        public Mandate()
        {
            MandateVoter = new HashSet<MandateVoter>();
            Poll = new HashSet<Poll>();
            Post = new HashSet<Post>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("start_date", TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column("end_date", TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("validated")]
        public bool? Validated { get; set; }
        [Column("validated_date", TypeName = "date")]
        public DateTime? ValidatedDate { get; set; }
        [Column("POWER_id", TypeName = "int(10) unsigned")]
        public uint PowerId { get; set; }
        [Column("CITY_id", TypeName = "int(10) unsigned")]
        public uint CityId { get; set; }
        [Column("STATE_id", TypeName = "int(10) unsigned")]
        public uint StateId { get; set; }
        [Column("COUNTRY_id", TypeName = "int(10) unsigned")]
        public uint CountryId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Mandate")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Mandate")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(PowerId))]
        [InverseProperty("Mandate")]
        public virtual Power Power { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Mandate")]
        public virtual State State { get; set; }
        [InverseProperty("Mandates")]
        public virtual ICollection<MandateVoter> MandateVoter { get; set; }
        [InverseProperty("Mandate")]
        public virtual ICollection<Poll> Poll { get; set; }
        [InverseProperty("Mandate")]
        public virtual ICollection<Post> Post { get; set; }
        [InverseProperty("Mandate")]
        public virtual ICollection<User> User { get; set; }
    }
}
