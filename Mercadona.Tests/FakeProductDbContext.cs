using BE_Mercadona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadona.Tests
{
    public class FakeProductDbContext
    {
        public async Task<IEnumerable<Product>> Get()
        {
            var products = new List<Product>();
            return (IEnumerable<Product>)Task.FromResult(products);
        }
    }
}
