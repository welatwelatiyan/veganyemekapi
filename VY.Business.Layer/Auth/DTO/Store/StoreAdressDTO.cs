namespace VY.Business.Layer.Auth.DTO.Store
{
    public class StoreAdressDTO:BaseAdressDTO
    {
        public int MaxOrderDistance { get; set; }

        public double longitude { get; set; }
        /// <summary>
        /// enlem
        /// </summary>
        public double latitude { get; set; }
    }
}
