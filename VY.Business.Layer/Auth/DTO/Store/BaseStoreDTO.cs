using VY.Core.Layer.Entity;

namespace VY.Business.Layer.Auth.DTO.Store
{
    public abstract class BaseStoreDTO:IDTO
    {
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
    }
}
