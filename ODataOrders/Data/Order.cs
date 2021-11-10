using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataOrders.Data
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }

        public int Revenue { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
