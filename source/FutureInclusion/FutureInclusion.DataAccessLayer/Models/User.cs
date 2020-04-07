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
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [Column("email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe um sobrenome")]
        [Display(Name = "Sobrenome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("last_name", TypeName = "varchar(255)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Informe uma senha")]
        [Display(Name="Senha")]
        [StringLength(18, ErrorMessage = "A {0} deve ter no minimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe um nivel")]
        [Display(Name = "Nivel de acesso")]
        [Column("level", TypeName = "tinyint(1) unsigned")]
        public byte Level { get; set; }

        [Required(ErrorMessage = "Informe o estado deste Usuario (Habilitado/Não Habilitado")]
        [Display(Name = "Estado")]
        [Column("enabled")]
        public bool? Enabled { get; set; }

        [Display(Name = "Mandato")]
        [Column("MANDATE_id", TypeName = "int(10) unsigned")]
        public uint? MandateId { get; set; }

        [Display(Name = "Mandato")]
        [ForeignKey(nameof(MandateId))]
        [InverseProperty("User")]
        public virtual Mandate Mandate { get; set; }
    }
}
