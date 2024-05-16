namespace VY.Business.Layer.Auth.DTO.Store
{
    public class StoreDTO:BaseStoreDTO
    {
        public string TaxNumber { get; set; }
        public string TaxBranchName { get; set; }
        public bool IsActive { get; set; }
        public bool IsClosed { get; set; }
    }
}
