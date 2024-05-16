using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.AddressTables
{
    public class VyStoreAdressTable : AddressTableBase
    {
        public Guid UserId { get; set; }
        public Guid StoreId { get; set; }
        public int MaxOrderDistance { get; set; } = 5;

    }
}
