using BE_Mercadona.DataBase;
using BE_Mercadona.DTOs;
using BE_Mercadona.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.Extensions;
using System.Drawing.Text;

namespace MercadonaTest
{
    public class UnitTest1
    {
        FakeProductDbContext listFakeProduct = new FakeProductDbContext();

        [Fact]
        public void Test1()
        {
            //arange


            //act
            var result=listFakeProduct.Get();
            
            //assert
            result.Should().NotBeNull();
            
        }
        

    }
}