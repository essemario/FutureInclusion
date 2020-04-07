using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Post
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Informe o texto do POST")]
        [Display(Name = "Texto")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 1000 carateres")]
        [Column("text", TypeName = "longtext")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Informe uma data e hora de postagem")]
        [Display(Name = "Data e hora de postagem")]
        [DataType(DataType.DateTime)]
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Display(Name = "Pergunta")]
        [Column("POLL_id", TypeName = "int(10) unsigned")]
        public uint PollId { get; set; }

        [Display(Name = "Mandato")]
        [Column("MANDATE_id", TypeName = "int(10) unsigned")]
        public uint MandateId { get; set; }

        [ForeignKey(nameof(MandateId))]
        [InverseProperty("Post")]
        public virtual Mandate Mandate { get; set; }
        [ForeignKey(nameof(PollId))]
        [InverseProperty("Post")]
        public virtual Poll Poll { get; set; }
    }
}
