using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.StoreTable
{
    public class VyStoreTable : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TaxNumber { get; set; }
        public string TaxBranchName { get; set; }
        public Guid userId { get; set; }
        public TimeOnly Opentime { get; set; }
        public TimeOnly  Closedtime { get; set; }
        public bool IsOpenEndOfWeek { get; set; }
        public bool IsClosed { get; set; }
        public bool ExceptionalClosed { get; set; } = true;

    }
}
