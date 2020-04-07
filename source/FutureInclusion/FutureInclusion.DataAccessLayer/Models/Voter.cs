using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Voter
    {
        public Voter()
        {
            MandateVoter = new HashSet<MandateVoter>();
            VoterChoice = new HashSet<VoterChoice>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Primeiro nome obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe um sobrenome")]
        [Display(Name = "Sobrenome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 100 carateres")]
        [Column("last_name", TypeName = "varchar(255)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [Column("email", TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe uma senha")]
        [Display(Name = "Senha")]
        [StringLength(18, ErrorMessage = "A senha deve ter até {0} e no minimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe um documento")]
        [Display(Name = "Documento")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Insira um documento válido")]
        [Column("document", TypeName = "varchar(45)")]
        public string Document { get; set; }

        [Display(Name = "Estado")]
        [Column("enabled")]
        public bool? Enabled { get; set; }

        [InverseProperty("Voters")]
        public virtual ICollection<MandateVoter> MandateVoter { get; set; }
        [InverseProperty("Voters")]
        public virtual ICollection<VoterChoice> VoterChoice { get; set; }
    }
}
