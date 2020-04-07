using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class City
    {
        public City()
        {
            Mandate = new HashSet<Mandate>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Digite um nome para a cidade.")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Selecione um estado")]
        [Display(Name = "Estado")]
        [Column("STATE_id", TypeName = "int(10) unsigned")]
        public uint StateId { get; set; }

        [ForeignKey(nameof(StateId))]
        [Display(Name = "Estado")]
        [InverseProperty("City")]
        public virtual State State { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Mandate> Mandate { get; set; }
    }
}
