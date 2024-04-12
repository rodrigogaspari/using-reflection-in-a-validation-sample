using System.Reflection;

namespace using_reflection_in_a_validation_sample.ValidatorCaseiro
{
    public class ValidadorCaseiro(object? objeto)
    {
        private readonly object? _objeto = objeto;

        public ValidadorCaseiroResultado Resultado { get; set; } = new();

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
                        Resultado.Erros.Add(resultadoValidacao);
                }
            }

            return this.Resultado; 
        }
    }


    public class ValidadorCaseiroResultado
    {
        public ValidadorCaseiroResultado() { }
        public ICollection<ValidadorCaseiroErro> Erros { get; set; } = new List<ValidadorCaseiroErro>();
    }

    public class ValidadorCaseiroErro
    {
        public ValidadorCaseiroErro() { }
        public string? Mensagem { get; set; }
    }

    public abstract class AtributoValidadorBase : Attribute 
    {
        public abstract ValidadorCaseiroErro? ValidarPropriedade(object value, PropertyInfo propertyInfo);
    }


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

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TamanhoTextoAttribute : AtributoValidadorBase
    {
        int ? _tamanhoMinimo;

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

            if (!string.IsNullOrEmpty(valor?.ToString()) && valor?.ToString()?.Length > _tamanhoMaximo)
                return new ValidadorCaseiroErro() { Mensagem = $"O tamanho do texto {propertyInfo.Name} é maior que o permitido {_tamanhoMaximo}." };

            return null;
        }
    }
}
