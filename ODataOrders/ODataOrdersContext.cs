using Microsoft.EntityFrameworkCore;
using ODataOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataOrders
{
    public class ODataOrdersContext : DbContext
    {
        public ODataOrdersContext(DbContextOptions<ODataOrdersContext> options)
            : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
