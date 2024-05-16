namespace VY.Core.Layer.Utilities.Results.Result
{
    public class Result : IResult
    {
        public Result(bool IsSuccess, string code,string message):this(IsSuccess, code)
        {
            this.message = message;
        }
        public Result(bool IsSuccess,string code):this(IsSuccess)
        {
            this.code = code;
        }
        public Result(bool isSuccess)
        {
            this.isSuccess = isSuccess;
        }
        public bool isSuccess {  get;  }

        public string code { get; } = string.Empty;

        public string message { get; } = string.Empty;
    }
}
