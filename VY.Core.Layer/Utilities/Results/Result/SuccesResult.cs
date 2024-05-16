namespace VY.Core.Layer.Utilities.Results.Result
{
    public class SuccesResult : Result
    {
        public SuccesResult() : base(true)
        {
        }

        public SuccesResult(string code) : base(true, code)
        {
        }

        public SuccesResult(string code, string message) : base(true, code, message)
        {
        }
    }
}
