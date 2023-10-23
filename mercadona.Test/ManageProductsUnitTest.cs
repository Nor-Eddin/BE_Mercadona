using BE_Mercadona.Controllers;
using BE_Mercadona.Models;

namespace mercadona.Tests
{
    public class ManageProductsUnitTest1
    {
        [Fact]
        public void GetAllProduct()
        {
            Product product = new();
            var getResult = product.Get();
            Assert.NotNull(getResult);
        }
    }
}