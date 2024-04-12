using System.ComponentModel.DataAnnotations;
using using_reflection_in_a_validation_sample.ValidatorCaseiro;

namespace using_reflection_in_a_validation_sample
{
    public class Livro
    {
        [Required]  
        [Obrigatorio] // Validador "Caseiro"
        public string? Titulo { get; set; }

        [Required]
        [Obrigatorio] // Validador "Caseiro"
        public string? Autor { get; set; }

        [MaxLength(250)]
        [TamanhoMaximoTexto(250)] // Validador "Caseiro"
        public string? Descricao { get; set; }

        [Required]
        [Obrigatorio] // Validador "Caseiro"
        [StringLength(13, MinimumLength = 13)]
        [TamanhoTexto(13)] // Validador "Caseiro"
        public string? ISBN { get; set; }

        [Required]
        [Obrigatorio] // Validador "Caseiro"
        public string? Idioma { get; set; }
    }
}
