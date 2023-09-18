using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="A data do evento e obrigatoria")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="O nome do evento e obrigatorio")]
        public string? NomeEvento { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="A descricao do evento e obrigatoria")]
        public string? Descricao { get; set; }

        //ref. as tabelas tipos eventos e instituicao
        [Required]
        public Guid IdTipoEvento { get; set; }
        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set; }

        //////////////////////////////////////////////////
        [Required]
        public Guid IdInstituicao { get; set; }
        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
