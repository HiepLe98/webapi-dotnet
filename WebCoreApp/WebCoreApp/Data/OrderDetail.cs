using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApp.Data
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
         
        public int Quantily { get; set; }
        public double Price { get; set; }
        public double PriceSale { get; set; }

        //reletionShip
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
