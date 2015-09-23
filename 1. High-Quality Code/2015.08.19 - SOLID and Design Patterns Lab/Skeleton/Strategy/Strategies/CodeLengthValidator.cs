namespace Strategy.Strategies
{
    using Interfaces;
    using SharpCompiler.Exceptions;

    public class CodeLengthValidator : ICodeValidationStrategy
    {
        public void Validate(string code)
        {
            if (code.Length < 20)
            {
                throw new CompilationException("Code length should be at least 20 characters.");
            }
        }
    }
}
