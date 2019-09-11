namespace StoreCar
{
    using System.Data.Entity;
    using StoreCar.Models;

    public partial class StoreCarDB : DbContext
    {
        public StoreCarDB()
            : base("name=StoreCarDB")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
