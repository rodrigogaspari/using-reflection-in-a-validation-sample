using System.Reflection;
using ValidadorCaseiroApi.Validador.Base;

namespace ValidadorCaseiroApi.Validador.Implementacoes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TamanhoMaximoTextoAttribute : AtributoValidadorBase
    {
        int? _tamanhoMaximo;

        public TamanhoMaximoTextoAttribute(int tamanho)
        {
            _tamanhoMaximo = tamanho;
        }

        public override ValidadorCaseiroErro? ValidarPropriedade(object value, PropertyInfo propertyInfo)
        {
            var valor = propertyInfo.GetValue(value);

            if (!string.IsNullOrEmpty(valor?.ToString()) && 
                valor?.ToString()?.Length > _tamanhoMaximo)

                return new ValidadorCaseiroErro() 
                { 
                    Mensagem = $"O tamanho do texto {propertyInfo.Name} é maior que o permitido {_tamanhoMaximo}." 
                };

            return null;
        }
    }
}
