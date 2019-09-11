using StoreLayerApp.DAL.EF;
using StoreLayerApp.DAL.Entities;
using StoreLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StoreLayerApp.DAL.Repositories
{
    public class CartLineRepository : IRepository<CartLine>
    {
        private StoreCarDB db;

        public CartLineRepository(StoreCarDB context)
        {
            this.db = context;
        }

        public IEnumerable<CartLine> GetAll()
        {
            return db.СartLines.Include(o=>o.Product);
        }

        public CartLine Get(int id)
        {
            return db.СartLines.Find(id);
        }

        public void Create(CartLine cartline)
        {
            db.СartLines.Add(cartline);
        }

        public void Attach(CartLine cartline)
        {
            db.СartLines.Attach(cartline);
        }

        public void Update(CartLine cartline)
        {
            db.Entry(cartline).State = EntityState.Modified;
        }
        public IEnumerable<CartLine> Find(Func<CartLine, Boolean> predicate)
        {
            return db.СartLines.Include(o=>o.Product).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            CartLine cartline = db.СartLines.Find(id);
            if (cartline != null)
                db.СartLines.Remove(cartline);
        }
    }
}
