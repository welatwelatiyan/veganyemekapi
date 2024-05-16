namespace VY.Business.Layer.Auth.DTO
{
    public class UserAdressGetDTO : BaseAdressDTO
    {
        public Guid AddressUUID { get; set; }

        public double longitude { get; set; }
        /// <summary>
        /// enlem
        /// </summary>
        public double latitude { get; set; }
    }
}
