using System.ComponentModel.DataAnnotations;
using ValidadorCaseiroApi.Validador.Implementacoes;

namespace ValidadorCaseiroApi
{
    public class Livro
    {
        [Required]    //Componente Model 
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
