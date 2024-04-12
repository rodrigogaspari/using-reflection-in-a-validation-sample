using System.Reflection;

namespace ValidadorCaseiroApi.Validador.Base
{
    public abstract class AtributoValidadorBase : Attribute
    {
        public abstract ValidadorCaseiroErro? ValidarPropriedade(object value, PropertyInfo propertyInfo);
    }
}
