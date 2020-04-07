using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Sphere
    {
        public Sphere()
        {
            Power = new HashSet<Power>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Digite um nome para esta esfera.")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [InverseProperty("Sphere")]
        public virtual ICollection<Power> Power { get; set; }
    }
}
