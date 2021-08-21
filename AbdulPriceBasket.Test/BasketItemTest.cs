using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AbdulPriceBasket.Model;
using AbdulPriceBasket.Business;
using Moq;


namespace AbdulPriceBasket.Test
{
    [TestClass]
    public class BasketItemTest
    {
        #region "Test Startup"
        private BasketService bask;

        [TestInitialize]
        public void SetUp()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllAvaliableProducts()).Returns(MockData.GetAllAvaliableProducts());
            bask = new BasketService(mock.Object);
        }
        #endregion

        #region "Update Basket and subtotal calculation tests"
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Product Not found.")]
        public void ShouldCheck_ifproductNotExsitsin_Repo_Test()
        {
            //Arrange
            var item = new List<string>() { "Oranges" };

            var result = bask.updateBasket(item);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Product Not found.")]
        public void ShouldCheck_ifsomeproductNotExsitsin_Repo_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Oranges" };

            var result = bask.updateBasket(item);
        }

        [TestMethod]
        public void ShouldAbleToUpdateItemsin_Basket_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Milk" };

            var result = bask.updateBasket(item);
        }

        [TestMethod]
        public void ShouldCheckIf_Basket_IsNotNull_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Milk", "Bread", "Soup" };

            //Act
            var result = bask.updateBasket(item);

            //Asset
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Set_Basket_with_Check_Items_Count_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Milk", "Bread" };

            //Act
            var result = bask.updateBasket(item);

            //Asset
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void Check_Am_I_GettingTheCorrectPriceOf_Products_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Soup","Bread","Milk" };

            //Act
            var result = bask.updateBasket(item);

            //Asset
            Assert.IsNotNull(result);
            Assert.AreEqual(result[0].ItemPrice, 1.00m);
            Assert.AreEqual(result[1].ItemPrice, 0.65m);
            Assert.AreEqual(result[2].ItemPrice, 0.85m);
            Assert.AreEqual(result[3].ItemPrice, 1.30m);
        }

        [TestMethod]
        public void Check_Am_I_GettingTheCorrectQtyOf_Products_Test()
        {
            //Arrange
            var item = new List<string>() { "Soup", "Soup", "Apples", "Milk" };
 
            //Act
            var result = bask.updateBasket(item);

            //Asset
            Assert.IsNotNull(result);
            Assert.AreEqual(result[0].ItemQty, 2);
            Assert.AreEqual(result[1].ItemQty, 1);
            Assert.AreEqual(result[2].ItemQty, 1);
        }

        [TestMethod]
        public void Get_Basket_SubTotal_CheckwithOneItem_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples" };

            //Act
            var basketresult = bask.updateBasket(item);

            //Assert
            Assert.AreEqual(1.00m, bask.SubTotal().SubTotal);
        }

        [TestMethod]
        public void Get_Basket_SubTotal_CheckwithTwoSameItem_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Apples" };

            //Act
            var basketresult = bask.updateBasket(item);

            //Assert
            Assert.AreEqual(2.00m, bask.SubTotal().SubTotal);
        }

        [TestMethod]
        public void Get_Basket_SubTotal_CheckwithTwoDifferentItem_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Milk" };

            //Act
            var basketresult = bask.updateBasket(item);

            //Assert
            Assert.AreEqual(2.30m, bask.SubTotal().SubTotal);
        }

        [TestMethod]
        public void Get_Basket_SubTotal_CheckwithThreeSameandOtherItem_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Milk", "Apples" };

            //Act
            var basketresult = bask.updateBasket(item);

            //Assert
            Assert.AreEqual(3.30m, bask.SubTotal().SubTotal);
        }
        #endregion

        #region "Cleanup resources"
        [TestCleanup]
        public void CleanUp()
        {
            bask = null;
        }
        #endregion

    }//end class...
}//end ns...
