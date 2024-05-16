using System.Web;
using VY.Business.Layer.Auth.Abstarct;

namespace VY.Business.Layer.Auth.Concreate
{
    public  class HttpService : IHttpService
    {
        public async Task<string> GetAsync(string baseAdress, Dictionary<string, string> param)
        {
            using (HttpClient client = new HttpClient()) 
            {

                try
                {
                    Uri uri = new Uri(baseAdress);
                    var httpvaluecol = HttpUtility.ParseQueryString(uri.Query);
                    foreach (KeyValuePair<string, string> item in param)
                        httpvaluecol.Add(item.Key, item.Value);
                    var ff = new UriBuilder(baseAdress);
                    ff.Query = httpvaluecol.ToString();

                    HttpResponseMessage resMsg = await client.GetAsync(ff.Uri);
                    string sonuc = await resMsg.Content.ReadAsStringAsync();
                    return sonuc;
                }
                catch (Exception e)
                {

                    return null;
                }


            }
        }
    }
}
