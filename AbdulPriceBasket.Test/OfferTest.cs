using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbdulPriceBasket.Model;
using AbdulPriceBasket.Business;
using Moq;
using System.Collections.Generic;

namespace AbdulPriceBasket.Test
{
    [TestClass]
    public class OfferTest
    {
        private OfferService offers;
        private BasketService bask;

        #region "Test Startup"
        [TestInitialize]
        public void SetUp()
        {
            var mockprodrepo = new Mock<IProductRepository>();
            mockprodrepo.Setup(m => m.GetAllAvaliableProducts()).Returns(MockData.GetAllAvaliableProducts());
            bask = new BasketService(mockprodrepo.Object);

            var mockofferrepo = new Mock<IOfferRepository>();
            mockofferrepo.Setup(m => m.GetOffers()).Returns(MockData.GetOffers());
            offers = new OfferService(mockofferrepo.Object);
        }
        #endregion

        #region "Available offer check tests"
        [TestMethod]
        public void Should_GetAllOffers_List_Test()
        {
            var result = offers.GetAllAvailableOffers();
        }

        [TestMethod]
        public void Should_GetAllOffers_IsNotNull_Test()
        {
            var result = offers.GetAllAvailableOffers();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_GetAllOffers_Count_Test()
        {
            var result = offers.GetAllAvailableOffers();

            Assert.AreEqual(result.Count,2);
        }
        #endregion

        #region "Offer and discounts calculation tests"
        [TestMethod]
        public void Should_OfferCheckOn_NoOfferFound_FromBasket_Test()
        {
            //Arrange
            var item = new List<string>() { "Milk" };

            //Act
            var basketresult = bask.updateBasket(item);
            offers.applyOffer(basketresult, bask.SubTotal());

            //Assert
            Assert.IsFalse(offers.OfferFoundInBasket.Count > 0);
        }

        [TestMethod]
        public void Should_OfferCheckOn_Apples_ifitisinBasket_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples" };

            //Act
            var basketresult = bask.updateBasket(item);
            offers.applyOffer(basketresult, bask.SubTotal());

            //Assert
            Assert.IsTrue(offers.OfferFoundInBasket.Count>0);
        }

        [TestMethod]
        public void Should_OfferCheckOn_OneTinSoup_ifitisinBasket_Test()
        {
            //Arrange
            var item = new List<string>() { "Soup" };

            //Act
            var basketresult = bask.updateBasket(item);
            offers.applyOffer(basketresult, bask.SubTotal());

            //Assert
            Assert.IsFalse(offers.OfferFoundInBasket.Count > 0);
        }

        [TestMethod]
        public void Should_OfferCheckOn_TwoTinSoup_ifitisinBasket_Test()
        {
            //Arrange
            var item = new List<string>() { "Soup", "Soup" };

            //Act
            var basketresult = bask.updateBasket(item);
            var getoffer = offers.applyOffer(basketresult, bask.SubTotal());

            //Assert
            Assert.IsNotNull(offers.OfferFoundInBasket);
        }

        [TestMethod]
        public void Lets_CalculateOfferon_Apples_ifitisinBasket_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples" };

            //Act
            var basketresult = bask.updateBasket(item);
            var result = offers.applyOffer(basketresult,bask.SubTotal());

            //Assert
            Assert.IsTrue(offers.OfferFoundInBasket.Count > 0);
            Assert.AreEqual(result.Discount, 0.10m);
        }

        [TestMethod]
        public void Lets_CalculateOfferon_NoOfferFound_Test()
        {
            //Arrange
            var item = new List<string>() { "Milk" };

            //Act
            var basketresult = bask.updateBasket(item);
            var result = offers.applyOffer(basketresult, bask.SubTotal());

            //Assert
            Assert.IsFalse(offers.OfferFoundInBasket.Count > 0);
            Assert.AreEqual(result.Discount, 0);
        }

        [TestMethod]
        public void Lets_CalculateOfferon_SoupAndBreadDiscount_ifitisinBasket_Test()
        {
            //Arrange
            var item = new List<string>() { "Soup", "Soup", "Bread" };

            //Act
            var basketresult = bask.updateBasket(item);
            var result = offers.applyOffer(basketresult, bask.SubTotal());

            //Assert
            Assert.AreEqual(result.Discount, 0.425m);
        }

        [TestMethod]
        public void Lets_CalculateOfferon_ApplesAndSoupAndBreadDiscount_ifitisinBasket_Test()
        {
            //Arrange
            var item = new List<string>() { "Apples", "Soup", "Soup", "Bread" };

            //Act
            var basketresult = bask.updateBasket(item);
            var result = offers.applyOffer(basketresult, bask.SubTotal());

            //Assert
            Assert.AreEqual(result.Discount, 0.525m);
        }

        #endregion

        #region "Cleanup resources"
        [TestCleanup]
        public void CleanUp()
        {
            offers = null;
        }
        #endregion
    }
}
