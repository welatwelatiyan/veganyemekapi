using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Business.Layer.Auth.DTO.Delivery
{
    public class DeliveryLineDTO
    {

        public Guid? menuid { get; set; }
        public string description { get; set; }
        public bool ismenu { get; set; }
        public List<MenuLineDTO>? menucontent { get; set; }
        public ProductLineDTO? productcontent { get; set; }

    }
}
