using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.AddressTables
{
    public abstract class AddressTableBase:BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// boylam
        /// </summary>
        public double longitude { get; set; }
        /// <summary>
        /// enlem
        /// </summary>
        public double latitude { get; set; }
        public string TelNumber { get; set; }

        public string Il {  get; set; }

    }
}
