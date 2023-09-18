using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(TiposUsuario))]
    public class TiposUsuario
    {
        [Key]
        public Guid IdtipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="O titulo do usuario e obrigatorio")]
        public string? Titulo { get; set; }
    }
}
