namespace VY.Core.Layer.Utilities.Results.Result
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string code) : base(false, code)
        {
        }

        public ErrorResult(string code, string message) : base(false, code, message)
        {
        }
    }
}
