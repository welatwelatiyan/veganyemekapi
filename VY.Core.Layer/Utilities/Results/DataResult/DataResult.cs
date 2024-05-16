using VY.Core.Layer.Entity;

namespace VY.Core.Layer.Utilities.Results.DataResult
{
    public class DataResult<T> : IDataResult<T> 
    {

        public DataResult(T data, bool isSuccess, string code, string message):this(data, isSuccess, code)
        {
            this.message = message; 
        }
        public DataResult(T data, bool isSuccess, string code):this(data, isSuccess)
        {
            this.code = code;
        }

        public DataResult(T data,bool isSuccess)
        {
            this.data = data;   
            this.isSuccess = isSuccess;
        }
        public T data { get;}

        public bool isSuccess {  get;}

        public string code { get; } = string.Empty;

        public string message { get; } = string.Empty;
    }
}
