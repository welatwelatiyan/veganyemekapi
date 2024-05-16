using VY.Core.Layer.Entity;

namespace VY.Business.Layer.Auth.DTO
{
    public abstract class BaseAdressDTO:IDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// boylam
        /// </summary>
        public string TelNumber { get; set; }
        public string Il { get; set;}
    }
}
