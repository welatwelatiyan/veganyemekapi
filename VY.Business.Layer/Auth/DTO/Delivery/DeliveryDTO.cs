namespace VY.Business.Layer.Auth.DTO.Delivery
{
    public class DeliveryDTO
    {
        public Guid storeid { get; set; }
        public string description { get; set; }
        public List<DeliveryLineDTO> deliveryLine { get; set; }
    }
}
