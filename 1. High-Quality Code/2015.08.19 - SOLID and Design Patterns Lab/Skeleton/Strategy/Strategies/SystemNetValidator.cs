namespace Strategy.Strategies
{
    using Interfaces;
    using SharpCompiler.Exceptions;

    public class SystemNetValidator : ICodeValidationStrategy
    {
        public void Validate(string code)
        {
            if (!code.Contains("using System.Net"))
            {
                throw new CompilationException("Code does not contain \"using System.Net\"");
            }
        }
    }
}
