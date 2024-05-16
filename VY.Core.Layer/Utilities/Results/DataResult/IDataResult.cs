using VY.Core.Layer.Utilities.Results.Result;

namespace VY.Core.Layer.Utilities.Results.DataResult
{
    public interface IDataResult<T> : IResult
    {
        T data { get; }
    }
}
