using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.AddressTables
{
    public class VyUserStoreAdressTable : BaseEntity
    {
        public Guid UserAdressId { get; set; }
        public Guid StoreId { get; set; }
        public double Distance {  get; set; }

    }
}
