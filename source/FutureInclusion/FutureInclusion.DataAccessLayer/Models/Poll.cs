using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureInclusion.DataAccessLayer.Models
{
    public partial class Poll
    {
        public Poll()
        {
            Choice = new HashSet<Choice>();
            Post = new HashSet<Post>();
        }

        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Informe o titulo da pergunta")]
        [Display(Name = "Titulo")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 255 carateres")]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe uma data e hora de inicio")]
        [Display(Name = "Data e hora de inicio")]
        [DataType(DataType.DateTime)]
        [Column("start", TypeName = "datetime")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Informe uma data e hora de termino")]
        [Display(Name = "Data e hora de termino")]
        [DataType(DataType.DateTime)]
        [Column("end", TypeName = "datetime")]
        public DateTime End { get; set; }

        [Required(ErrorMessage = "Informe o enunciado da pergunta")]
        [Display(Name = "Enunciado")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 1000 carateres")]
        [Column("description", TypeName = "longtext")]
        public string Description { get; set; }
        
        [Display(Name="Tags")]
        [Column("tag", TypeName = "varchar(255)")]
        public string Tag { get; set; }

        [Required(ErrorMessage = "Informe o mandato")]
        [Display(Name = "Mandato")]
        [Column("MANDATE_id", TypeName = "int(10) unsigned")]
        public uint MandateId { get; set; }

        [ForeignKey(nameof(MandateId))]
        [Display(Name = "Mandato")]
        [InverseProperty("Poll")]
        public virtual Mandate Mandate { get; set; }
        
        [InverseProperty("Poll")]
        public virtual ICollection<Choice> Choice { get; set; }
        [InverseProperty("Poll")]
        public virtual ICollection<Post> Post { get; set; }
    }
}
