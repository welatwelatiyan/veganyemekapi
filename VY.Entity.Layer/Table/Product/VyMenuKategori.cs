using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.Product
{
    public class VyMenuKategori:BaseEntity
    {
        public Guid StoreId { get; set; } 
        public string Name { get; set; }
        public bool IsRequireChoice { get; set; }
    }
}
 