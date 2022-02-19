using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApp.Data
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime DeliveryDate { get; set; }
        public string Receiver { get; set; }
        public string Address  { get; set; }
        public string PhoneNo { get; set; }
        public OrderStatus Status { get; set; } 

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

    }

    public enum OrderStatus
    {
        New = 0, Payment=1,Complete=2,Cancel=3
    }
}
