using StoreLayerApp.DAL.Entities;
using System.Data.Entity;

namespace StoreLayerApp.DAL.EF
{
    public partial class StoreCarDB : DbContext
    {
        public StoreCarDB()
            : base("name=StoreCarDB")
        {
        }

        public StoreCarDB(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartLine> СartLines { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
