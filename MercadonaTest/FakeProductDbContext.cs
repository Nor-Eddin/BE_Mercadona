using BE_Mercadona.DataBase;
using BE_Mercadona.DTOs;
using BE_Mercadona.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadonaTest
{
    public class FakeProductDbContext 
    {
        
        public async Task<IEnumerable<Product>> Get()
        {
            return (IEnumerable<Product>)Task.FromResult(new List<Product>());
        }
        

    }
}
