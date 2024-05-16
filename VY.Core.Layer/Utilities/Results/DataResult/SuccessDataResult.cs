using VY.Core.Layer.Entity;

namespace VY.Core.Layer.Utilities.Results.DataResult
{
    public class SuccessDataResult<T> : DataResult<T> 
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, string code) : base(data, true, code)
        {
        }

        public SuccessDataResult(T data, string code, string message) : base(data, true, code, message)
        {
        }
    }
}
