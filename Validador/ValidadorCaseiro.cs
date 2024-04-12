using System.Reflection;
using ValidadorCaseiroApi.Validador.Base;

namespace ValidadorCaseiroApi.Validador
{
    public class ValidadorCaseiro(object? objeto)
    {
        private readonly object? _objeto = objeto;

        private ValidadorCaseiroResultado _resultado { get; set; } = new();

        public ValidadorCaseiroResultado ValidarObjeto()
        { 
            if (_objeto is null) 
                throw new ArgumentNullException();

            var propriedadesDaClasseParaValidar = 
                _objeto
                .GetType()
                .GetProperties();

            foreach (PropertyInfo? propriedade in propriedadesDaClasseParaValidar)
            {
                var validacoesDaPropriedade = propriedade.GetCustomAttributes(true)
                    .Where(x => typeof(AtributoValidadorBase)
                    .IsAssignableFrom(x.GetType()))
                    .Cast<AtributoValidadorBase>();

                ValidadorCaseiroErro? resultadoValidacao;

                foreach (AtributoValidadorBase validacao in validacoesDaPropriedade)
                {
                    resultadoValidacao = validacao.ValidarPropriedade(_objeto, propriedade);
                    if (resultadoValidacao is not null)
                        _resultado.Erros.Add(resultadoValidacao);
                }
            }

            return this._resultado; 
        }
    }
}
