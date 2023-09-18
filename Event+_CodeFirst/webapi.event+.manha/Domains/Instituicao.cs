using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName ="CHAR(14)")]
        [Required(ErrorMessage ="O CNPJ da empreja e obrigatorio")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage ="Endereco obrigatorio")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string? NomeFantasia { get; set; }
    }
}
