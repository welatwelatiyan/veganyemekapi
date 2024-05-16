using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Entity.Layer.Table.AddressTables;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IDistanceService
    {
        Task<IDataResult<List<VyUserStoreAdressTable>>>
            DistanceCalculate(VyUserAdressTable useradress,
            List<VyStoreAdressTable> storeadress);


        //Task<IDataResult<List<VyUserStoreAdressTable>>>
        //    DistanceCalculate(VyStoreAdressTable storeadress,
        //    List<VyUserAdressTable> useradress);
    }
}
