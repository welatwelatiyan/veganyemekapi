using VY.Core.Layer.Utilities.Results.Result;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IUserStoreAdressService
    {
        Task<IResult> setUserAdress(VyUserAdressTable adressTable);
        Task<IResult> setStoreAdress(VyStoreAdressTable adressTable);
    }
}
