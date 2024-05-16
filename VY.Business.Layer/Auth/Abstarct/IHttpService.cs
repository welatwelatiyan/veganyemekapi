namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IHttpService
    {
        Task<string> GetAsync(string baseAdress, Dictionary<string,string> param);
    }
}
