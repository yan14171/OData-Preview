using System.Collections.Generic;

namespace ODataOrders.Data
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryId { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
