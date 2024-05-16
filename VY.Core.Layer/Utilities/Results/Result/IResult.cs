namespace VY.Core.Layer.Utilities.Results.Result
{
    public interface IResult
    {
        bool isSuccess { get; }
        string code {  get; }
        string message { get; }
    }
}
