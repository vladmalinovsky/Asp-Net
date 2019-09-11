using StoreLayerApp.DAL.EF;
using StoreLayerApp.DAL.Entities;
using StoreLayerApp.DAL.Interfaces;
using System;

namespace StoreLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StoreCarDB db;
        private ProductRepository productRepository;
        private CartRepository cartRepository;
        private CartLineRepository cartLineRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new StoreCarDB(connectionString);
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Cart> Carts
        {
            get
            {
                if (cartRepository == null)
                    cartRepository = new CartRepository(db);
                return cartRepository;
            }
        }

        public IRepository<CartLine> CartLines
        {
            get
            {
                if (cartLineRepository == null)
                    cartLineRepository = new CartLineRepository(db);
                return cartLineRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
