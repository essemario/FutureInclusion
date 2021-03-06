﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Country
    {
        public Country()
        {
            Mandate = new HashSet<Mandate>();
            State = new HashSet<State>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Digite um nome para o país.")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<Mandate> Mandate { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<State> State { get; set; }
    }
}
