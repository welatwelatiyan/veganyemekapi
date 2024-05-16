using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.Product
{
    public class VyMenuProductTable:BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid MenuId { get; set; }
        public Guid ProductId { get; set; }
        public Guid MenuKategoriId { get; set; }
        public double ExternalPrice { get; set; }
        public int SortingNumber { get; set; }

    }
}
