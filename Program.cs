// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using using_reflection_in_a_validation_sample.ValidatorDoGaspar;

Console.WriteLine("Building a new validator object using Reflaction");
Console.WriteLine();


//Objeto à ser validado:
var novoBook = new LivroModel()
{
    //Titulo = "Código Limpo",
    //Autor = "Robert C. Martin", 
    Descricao = "Habilidades Práticas do Agile Software",
    ISBN =  "978-85-7608-267-5", 
    Idioma = "pt-BR",
};


Console.WriteLine("Usando validação nativa do Compoment Model"); 

ValidationContext vc = new(novoBook);
var validationResult = new List<ValidationResult>();

if(!Validator.TryValidateObject(novoBook, vc, validationResult))
    foreach (var item in validationResult)
        Console.WriteLine($"  -> { item.ErrorMessage}");


//Usando a nosso validador caseirinho :D
var meuValidadorCaseiro = new ValidadorCaseiro(novoBook);

meuValidadorCaseiro.ValidarObjeto();

foreach (var item in meuValidadorCaseiro.Resultado.Erros)
    Console.WriteLine($"  -> {item.Mensagem}" );




public class LivroModel
{
    [Required]    // Componente Model.  
    [Obrigatorio] // Validador "Caseiro"
    public string? Titulo { get; set; }

    [Required]
    [Obrigatorio] // Validador "Caseiro"
    public string? Autor { get; set; }

    [MaxLength(250)]
    [TamanhoMaximo(250)]
    public string? Descricao { get; set; }
    
    [Required]
    [Obrigatorio]
    [StringLength(13, MinimumLength = 13)]
    [TamanhoMaximo(13)]
    public string? ISBN { get; set; }

    [Required]
    [Obrigatorio]
    public string? Idioma { get;set; } 
}