using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.Product
{
    public class VyProductTable : BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid KitchenId { get; set; }
        public string  Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
