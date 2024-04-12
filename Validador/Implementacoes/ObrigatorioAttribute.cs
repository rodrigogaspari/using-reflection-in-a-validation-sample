using System.Reflection;
using ValidadorCaseiroApi.Validador.Base;

namespace ValidadorCaseiroApi.Validador.Implementacoes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ObrigatorioAttribute : AtributoValidadorBase
    {
        public override ValidadorCaseiroErro? ValidarPropriedade(object value, PropertyInfo propertyInfo)
        {
            var valor = propertyInfo.GetValue(value);

            if (string.IsNullOrEmpty(valor?.ToString()))
                return new ValidadorCaseiroErro() { Mensagem = $"A propriedade {propertyInfo.Name} é obrigatória." };

            return null;
        }
    }
}
