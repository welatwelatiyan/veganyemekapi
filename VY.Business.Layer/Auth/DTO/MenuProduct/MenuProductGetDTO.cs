namespace VY.Business.Layer.Auth.DTO.MenuProduct
{
    public class MenuProductGetDTO:MenuProductBaseDTO
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public Guid StoreId { get; set; }
    }
}
