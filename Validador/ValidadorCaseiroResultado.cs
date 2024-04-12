namespace ValidadorCaseiroApi.Validador
{
    public class ValidadorCaseiroResultado
    {
        public ValidadorCaseiroResultado() { }
        public ICollection<ValidadorCaseiroErro> Erros { get; set; } = new List<ValidadorCaseiroErro>();
    }
}
