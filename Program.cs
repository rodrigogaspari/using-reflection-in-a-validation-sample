﻿// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using ValidadorCaseiroApi;
using ValidadorCaseiroApi.Validador;

Console.WriteLine("Construindo um novo validador de objetos usando Reflection");
Console.WriteLine();


//Objeto à ser validado:
var novoLivro = new Livro()
{
    //Titulo = "Código Limpo",
    //Autor = "Robert C. Martin", 
    //ISBN = "978-85-7608-267-5", 
    Descricao = "Habilidades Práticas do Agile Software",
    Idioma = "pt-BR",
};


Console.WriteLine("Usando validação nativa do Compoment Model"); 
ValidationContext validationContext = new(novoLivro);
var validationResult = new List<ValidationResult>();

if (!Validator.TryValidateObject(novoLivro, validationContext, validationResult))
    validationResult
        .ToList()
        .ForEach(x =>
        Console.WriteLine($"  -> {x.ErrorMessage}")
    );




Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Usando o nosso validador caseirinho :D");
ValidadorCaseiro validadorCaseiro = new(novoLivro);
validadorCaseiro
    .ValidarObjeto()
    .Erros
    .ToList()
    .ForEach(x => 
        Console.WriteLine($"  -> {x.Mensagem}")
);



