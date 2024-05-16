using System.ComponentModel.DataAnnotations.Schema;
using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.Delivery
{
    public class VyDeliveryTable:BaseEntity
    {
        public string Name { get; set; }
        public Guid StoreId { get; set; }
        public string Description { get; set; }
        public double totalAmount { get; set; }
        [Column(TypeName = "json")]
        public string Content { get; set; }
        [Column(TypeName = "json")]
        public string UserInfo { get; set; }
        public int status { get; set; }


    }
}
