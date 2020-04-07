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

        [Required(ErrorMessage = "Digite um nome para o estado.")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Selecione um pais")]
        [Display(Name = "Pais")]
        [Column(TypeName = "int(10) unsigned")]
        public uint CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [Display(Name = "Pais")]
        [InverseProperty("State")]
        public virtual Country Country { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<City> City { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<Mandate> Mandate { get; set; }
    }
}
