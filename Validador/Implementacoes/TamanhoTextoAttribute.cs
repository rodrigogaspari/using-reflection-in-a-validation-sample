using System.Reflection;
using ValidadorCaseiroApi.Validador.Base;

namespace ValidadorCaseiroApi.Validador.Implementacoes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TamanhoTextoAttribute : AtributoValidadorBase
    {
        int? _tamanhoMinimo;

        public TamanhoTextoAttribute(int tamanho)
        {
            _tamanhoMinimo = tamanho;
        }

        public override ValidadorCaseiroErro? ValidarPropriedade(object value, PropertyInfo propertyInfo)
        {
            var valor = propertyInfo.GetValue(value);

            if (!string.IsNullOrEmpty(valor?.ToString()) && valor?.ToString()?.Length < _tamanhoMinimo)
                return new ValidadorCaseiroErro() { Mensagem = $"O tamanho ({valor?.ToString()?.Length}) do texto {propertyInfo.Name} é menor que o permitido: {_tamanhoMinimo}." };

            return null;
        }
    }

}
