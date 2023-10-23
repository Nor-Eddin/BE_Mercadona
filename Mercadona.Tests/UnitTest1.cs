using BE_Mercadona.DataBase;
using BE_Mercadona.Models;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Mercadona.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllProduct_ShouldReturnAList_WhenListExist()
        {
            //Arrange
            FakeProductDbContext listFakeProduct=new FakeProductDbContext();
            //Act
            var result = listFakeProduct.Get();
            //Assert
            result.Should().NotBeNull();


        }


    }
}