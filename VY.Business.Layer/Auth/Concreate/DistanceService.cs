using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Web;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.MapBox;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.Business.Layer.Auth.Concreate
{
    public class DistanceService : IDistanceService
    {
        private IHttpService httpService;
        private IConfiguration configuration;

        public DistanceService(IHttpService httpService,IConfiguration configuration)
        {
            this.httpService = httpService;
            this.configuration = configuration;
        }

        public async Task<IDataResult<List<VyUserStoreAdressTable>>> 
            DistanceCalculate(VyUserAdressTable useradress, List<VyStoreAdressTable> storeadress)
        {
            try
            {
                List<VyUserStoreAdressTable> userstorels = new List<VyUserStoreAdressTable>();
                //storeadress.ForEach(x => userstorels.Add(new VyUserStoreAdressTable()));

                List<Task> tasks = new List<Task>();


                storeadress.ForEach(x => tasks.Add(Task.Run(() =>
                {
                    VyUserStoreAdressTable vyUserStoreAdressTable;
                    CalculateDistance(useradress, x, out vyUserStoreAdressTable);
                    userstorels.Add(vyUserStoreAdressTable);
                })));

                await Task.WhenAll(tasks);

                return new SuccessDataResult<List<VyUserStoreAdressTable>>(userstorels);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<VyUserStoreAdressTable>>(new List<VyUserStoreAdressTable>());
            }
        }

        private  void
            CalculateDistance(VyUserAdressTable vyUserAdress,VyStoreAdressTable vyStoreAdress, out VyUserStoreAdressTable vy)
        {
            string basead = "https://api.mapbox.com";
            string userCord = vyUserAdress.longitude + "," + vyUserAdress.latitude + ";";
            string storeCord = vyStoreAdress.longitude + "," + vyStoreAdress.latitude;
            string url = "/directions/v5/mapbox/driving/" + HttpUtility.UrlEncode(userCord + storeCord);
            basead += url;
            
            string jsstr =  httpService.GetAsync(basead, new Dictionary<string, string>()
            {
                { "alternatives","false" },
                { "geometries","geojson" },
                { "overview","full" },
                { "steps","false" },
                { "access_token",configuration.GetSection("mapboxtoken").Get<string>()}
             }).GetAwaiter().GetResult();
            List<VyUserStoreAdressTable> dsd = new List<VyUserStoreAdressTable>();
            
            MapboxGetDTO mapboxGetDTO = string.IsNullOrEmpty(jsstr) ?
                new MapboxGetDTO() : JsonConvert.DeserializeObject<MapboxGetDTO>(jsstr);

            VyUserStoreAdressTable sd = new VyUserStoreAdressTable();
            vy= new VyUserStoreAdressTable
            {
                UserAdressId = vyUserAdress.Id,
                StoreId = vyStoreAdress.Id,
                Distance = string.IsNullOrEmpty(jsstr) ? 0 : mapboxGetDTO.routes[0].distance,
            };
        }
    }
}



