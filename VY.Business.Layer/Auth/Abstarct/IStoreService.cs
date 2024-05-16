using VY.Business.Layer.Auth.DTO.Store;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IStoreService
    {
        IResult addStore(StoreDTO store, Guid userid);
        IResult updateStore(StoreUpdateDTO store, Guid userid);
        IDataResult<StoreDTO> getStore(Guid userid);
    }
}
