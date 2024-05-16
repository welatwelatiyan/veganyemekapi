namespace VY.Business.Layer.Auth.DTO.MenuProduct
{
    public abstract class MenuProductBaseDTO
    {
        public Guid MenuId { get; set; }
        public Guid ProductId { get; set; }
        public Guid MenuKategoriId { get; set; }
        public int SortingNumber { get; set; }
        public double ExternalPrice { get; set; }

    }
}
