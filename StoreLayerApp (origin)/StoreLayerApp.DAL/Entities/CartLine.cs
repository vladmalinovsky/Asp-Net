using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreLayerApp.DAL.Entities
{
    public class CartLine
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int? Product_Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
