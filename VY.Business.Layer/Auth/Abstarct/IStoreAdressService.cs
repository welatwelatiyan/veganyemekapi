using VY.Business.Layer.Auth.DTO.Store;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;

namespace VY.Business.Layer.Auth.Abstarct
{
    public  interface IStoreAdressService
    {
        IResult set(StoreAdressDTO adress, Guid userid);
        IResult update(StoreAdressDTO adress, Guid userid);
        IDataResult<StoreAdressDTO> get( Guid userid);
    }
}
