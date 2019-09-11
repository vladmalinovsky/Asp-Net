using StoreLayerApp.DAL.EF;
using StoreLayerApp.DAL.Entities;
using StoreLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StoreLayerApp.DAL.Repositories
{
    public class CartRepository : IRepository<Cart>
    {
        private StoreCarDB db;

        public CartRepository(StoreCarDB context)
        {
            this.db = context;
        }

        public IEnumerable<Cart> GetAll()
        {
            return db.Carts.Include(o=>o.Lines);
        }

        public Cart Get(int id)
        {
            return db.Carts.Find(id);
        }

        public void Create(Cart cart)
        {
            db.Carts.Add(cart);
        }

        public void Attach(Cart cart)
        {
            db.Carts.Attach(cart);
        }

        public void Update(Cart cart)
        {
            db.Entry(cart).State = EntityState.Modified;
        }
        public IEnumerable<Cart> Find(Func<Cart, Boolean> predicate)
        {
            return db.Carts.Include(o=>o.Lines).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart != null)
                db.Carts.Remove(cart);
        }
    }
}
