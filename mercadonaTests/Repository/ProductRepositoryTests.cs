using AutoMapper;
using BE_Mercadona.Controllers;
using BE_Mercadona.DataBase;
using BE_Mercadona.DataBase.EntityConfiguration;
using BE_Mercadona.DTOs;
using BE_Mercadona.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercadonaTests.Repository
{
    public class ProductRepositoryTests
    {
        private async Task<ProductDbContext> GetDataBaseContext()
        {
            var options=new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName:Guid.NewGuid().ToString())
                .Options;
            var dataBaseContext=new ProductDbContext(options);
            dataBaseContext.Database.EnsureCreated();
            if(await dataBaseContext.Products.CountAsync() <= 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    dataBaseContext.Products.Add(
                        new Product()
                        {
                            IdProduct = 1,
                            ProductName = "pattate",
                            DescriptionProduct = "azert",
                            Price = 5,
                            Image = "http://google.fr",
                            CatId = 3
                        });
                    await dataBaseContext.SaveChangesAsync();

                }
            }
            return dataBaseContext;
        }
        
        [Fact]
        public async void Product_GetProduct_ReturnsProduct()
        {
            //Arange
            var productName = "pattate";
            var dbContext = await GetDataBaseContext();
            var product = dbContext.Products.SingleOrDefault();


            //act
            var result = product.ProductName;

            //Assert
            result.Should().NotBeNull();
            result.Should().Be(productName);
            result.Should().BeOfType<Product>();
        }
    }
}
