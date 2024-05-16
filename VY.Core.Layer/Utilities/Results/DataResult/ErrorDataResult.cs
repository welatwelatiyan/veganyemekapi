using VY.Core.Layer.Entity;

namespace VY.Core.Layer.Utilities.Results.DataResult
{
    public class ErrorDataResult<T> : DataResult<T> 
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data, string code) : base(data, false, code)
        {
        }

        public ErrorDataResult(T data, string code, string message) : base(data, false, code, message)
        {
        }
    }
}
