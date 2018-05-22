using InventoryEntity;
using System.Data.Entity;

namespace InventoryContext
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext() : base("InventoryConnectionString")
        {
            Database.SetInitializer(new DBInitializer());

            if (Database.Exists())
            {
               Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryDbContext, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        public class DBInitializer : CreateDatabaseIfNotExists<InventoryDbContext>
        {
            public DBInitializer()
            {
            }
        }
        public DbSet<EInventoryItem> InventoryItem { get; set; }
        public DbSet<ELocation> Location { get; set; }
        public DbSet<EPartialDelivery> PartialDelivery { get; set; }
        public DbSet<EPartialDeliveryItem> PartialDeliveryItem { get; set; }
        public DbSet<EPurchasingOrder> PurchasingOrder { get; set; }
        public DbSet<ERequest> Request { get; set; }
        public DbSet<ERequestItem> RequestItem { get; set; }
        public DbSet<ERequisition> Requisition { get; set; }
        public DbSet<ERequisitionItem> RequisitionItem { get; set; }
        public DbSet<ESupplier> Supplier { get; set; }
        public DbSet<ESupplierInventoryItem> SupplierInventoryItem { get; set; }
        public DbSet<EUnitOfMeasurement> UnitOfMeasurement { get; set; }
    }
}
