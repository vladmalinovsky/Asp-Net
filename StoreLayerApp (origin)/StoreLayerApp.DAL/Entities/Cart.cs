using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLayerApp.DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public List<CartLine> lineCollection = new List<CartLine>();

        public string UserName { get; set; }

        public double TotalPrice { get; set; }
               
        public ICollection<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
