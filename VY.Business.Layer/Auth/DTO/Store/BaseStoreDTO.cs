using VY.Core.Layer.Entity;

namespace VY.Business.Layer.Auth.DTO.Store
{
    public abstract class BaseStoreDTO:IDTO
    {
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public DateTime Opentime { get; set; } 
        public DateTime Closedtime { get; set; }
        public bool IsOpenEndOfWeek { get; set; }
        public bool ExceptionalClosed { get; set; } = true;
    }
}
