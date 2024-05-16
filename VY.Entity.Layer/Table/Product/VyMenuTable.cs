using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.Product
{
    public class VyMenuTable:BaseEntity
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        public double Price { get; set; }
    }
}
