    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ODataOrdersController : ControllerBase
    {
        private readonly ODataOrdersContext context;

        public ODataOrdersController(ODataOrdersContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await context.Orders.ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add (Order or)
        {
            context.Orders.Add(or);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { Id = or.Id }, or); 
        }


        private readonly List<string> demoCustomers = new List<string>
        {
            "Foo",
            "Bar",
            "Acme",
            "King of Tech",
            "Awesomeness"
        };

        private readonly List<string> demoDescriptions = new List<string>
        {
            "Good",
            "Bad",
            "Very good",
            "Very bad"
        };

        private readonly List<string> demoCountries = new List<string>
        {
            "AT",
            "DE",
            "CH"
        };

        [HttpPost]
        [Route("fill")]
        public async Task<IActionResult> Fill()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                var c = new Customer
                {
                    Name = demoCustomers[rand.Next(demoCustomers.Count)],
                    CountryId = demoCountries[rand.Next(demoCountries.Count)]
                };
                context.Customers.Add(c);

                for (var j = 0; j < 10; j++)
                {
                    var o = new Order
                    {
                        OrderDate = DateTime.Today,
                        Description = demoDescriptions[rand.Next(demoDescriptions.Count)],
                        Revenue = rand.Next(100, 5000),
                        Customer = c
                    };
                    context.Orders.Add(o);
                }
            }

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
