namespace using_reflection_in_a_validation_sample.ValidatorDoGaspar
{
    public class ValidadorCaseiro(object? value)
    {
        private readonly object? _value = value;

        public ValidadorCaseiroResultado Resultado { get; set; }

        public void ValidarObjeto()
        { 
            if (_value != null) 
            {
                throw new ArgumentNullException();
            }

            //TODO
            throw new NotImplementedException();
        }
    }


    public class ValidadorCaseiroResultado
    { 
        public ICollection<ValidadorCaseiroErro> Erros { get; set; }
    }

    public class ValidadorCaseiroErro
    { 
        public string? Mensagem { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ObrigatorioAttribute : Attribute
    {
    
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TamanhoMaximoAttribute : Attribute
    {
        int ? _tamanhoMaximo;

        public TamanhoMaximoAttribute(int tamanho) 
        { 
            _tamanhoMaximo = tamanho;
        }

    }
}
