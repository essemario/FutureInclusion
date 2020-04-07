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
        
        [Required(ErrorMessage ="Informe uma data de inicio")]
        [Display(Name = "Data de inicio")]
        [DataType(DataType.Date)]
        [Column("start_date", TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Informe uma data de termino")]
        [Display(Name = "Data de termino")]
        [DataType(DataType.Date)]
        [Column("end_date", TypeName = "date")]
        public DateTime EndDate { get; set; }
        
        [Required(ErrorMessage = "Informe o titulo do mandato")]
        [Display(Name = "Titulo")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("title", TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Informe se este mandato está ativo ou não")]
        [Display(Name = "Status")]
        [Column("active")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Informe se este mandato validado ou não")]
        [Display(Name = "Validado")]
        [Column("validated")]
        public bool? Validated { get; set; }

        [Display(Name = "Data de validação")]
        [DataType(DataType.Date)]
        [Column("validated_date", TypeName = "date")]
        public DateTime? ValidatedDate { get; set; }

        [Required(ErrorMessage = "Selecione um poder (executivo, legistivo ou executivo) ")]
        [Display(Name = "Poder")]
        [Column("POWER_id", TypeName = "int(10) unsigned")]
        public uint PowerId { get; set; }

        [Display(Name = "Cidade")]
        [Column("CITY_id", TypeName = "int(10) unsigned")]
        public uint CityId { get; set; }

        [Display(Name = "Estado")]
        [Column("STATE_id", TypeName = "int(10) unsigned")]
        public uint StateId { get; set; }

        [Display(Name = "País")]
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
