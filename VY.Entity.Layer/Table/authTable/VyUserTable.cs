using VY.Core.Layer.Entity;

namespace VY.Entity.Layer.Table.authTable
{
    public class VyUserTable : BaseEntity
    {
        public string emailAdress { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsSeller { get; set; } = false;
    }
}
