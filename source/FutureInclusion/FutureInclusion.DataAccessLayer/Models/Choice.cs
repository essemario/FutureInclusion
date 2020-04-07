using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Choice
    {
        public Choice()
        {
            VoterChoice = new HashSet<VoterChoice>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        
        [Required(ErrorMessage = "Digite um texto para a alternativa.")]
        [Display(Name = "Texto")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 255 carateres")]
        [Column("text", TypeName = "text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Selecione uma pergunta")]
        [Display(Name = "Pergunta")]
        [Column("POLL_id", TypeName = "int(10) unsigned")]
        public uint PollId { get; set; }

        [Display(Name = "Pergunta")]
        [ForeignKey(nameof(PollId))]
        [InverseProperty("Choice")]
        public virtual Poll Poll { get; set; }
        [InverseProperty("Choices")]
        public virtual ICollection<VoterChoice> VoterChoice { get; set; }
    }
}
