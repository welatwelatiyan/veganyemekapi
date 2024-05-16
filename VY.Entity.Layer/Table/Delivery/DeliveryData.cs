using VY.Entity.Layer.Table.Product;

namespace VY.Entity.Layer.Table.Delivery
{
    public class DeliveryData
    {
        public string  Name { get; set; }
        public VyProductTable productTable { get; set; }
        public int MyProperty { get; set; }
    }
}
