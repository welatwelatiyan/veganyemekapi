using Microsoft.EntityFrameworkCore;
using System.Data;
using VY.Entity.Layer.Table.AddressTables;
using VY.Entity.Layer.Table.authTable;
using VY.Entity.Layer.Table.Delivery;
using VY.Entity.Layer.Table.Product;
using VY.Entity.Layer.Table.StoreTable;


namespace VY.DataAccess.Layer.DbContexts
{
    public class AuthContext : DbContext
    {
        DbSet<VyUserTable> vyUserTables {  get; set; }
        DbSet<VyStoreTable> vyStoreTables { get; set; }
        DbSet<VyStoreAdressTable> vyStoreAdressTables { get; set; }
        DbSet<VyUserAdressTable> vyUserAdressTables { get; set; }
        DbSet<VyUserStoreAdressTable> vyUserStoreAdressTables { get; set; }
        DbSet<VyProductTable> vyProductTables { get; set; }
        DbSet<VyMenuProductTable> vyMenuProductTables {  get; set; }        
        DbSet<VyMenuTable> vyMenuTables { get; set; }
        DbSet<VyKithchenTable> vyKithchenTables { get; set; }
        DbSet<VyMenuKategori> vyMenuKategoris { get; set; }
        DbSet<VyDeliveryTable> vyDeliveryTables { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var constr = "Host=localhost;Database=veganyemektest;Username=root;Password=welat.123";
        //    optionsBuilder.UseMySql(constr, ServerVersion.AutoDetect(constr));
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VyDeliveryTable>().
                Property(x => x.UserInfo).
                HasColumnType("json");
            builder.Entity<VyDeliveryTable>().
                Property(x => x.Content).
                HasColumnType("json");
        }
        public AuthContext(DbContextOptions options ):base(options) { }
        //public AuthContext()
        //{
        //        
        //}

    }
}
