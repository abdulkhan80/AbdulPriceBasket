using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbdulPriceBasket.Model;
using AbdulPriceBasket.Business;
using Moq;

namespace AbdulPriceBasket.Test
{
    [TestClass]
    public class ProductTest
    {
        #region "Test Startup"
        private ProductService prod;

        [TestInitialize]
        public void SetUp()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllAvaliableProducts()).Returns(MockData.GetAllAvaliableProducts());
            prod = new ProductService(mock.Object);
        }
        #endregion

        [TestMethod]
        public void ShouldGetAvaliableItems_List_Test()
        {
            var result = prod.avaliableProducts();
        }

        [TestMethod]
        public void ShouldProductsList_NotNull_Test()
        {
            var result = prod.avaliableProducts();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldProductsList_CountWithFourItems_Test()
        {
            var result = prod.avaliableProducts();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 4);
        }

        #region "Cleanup resources"
        [TestCleanup]
        public void CleanUp()
        {
            prod = null;
        }
        #endregion
    }
}
