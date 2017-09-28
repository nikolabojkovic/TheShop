using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TheShop;
using TheShop.Models;

namespace UnitTestTheShop
{
    [TestClass]
    public class ShopServiceTest
    {
        [TestMethod]
        public void TestOrderArticle_ShouldReturnOrderdArticle()
        {
            var shopService = new ShopService();
            var expected = new Article()
            {
                Id = 1,
                NameOfArticle = "Article from supplier3",
                ArticlePrice = 460
            };

            var article = shopService.OrderArticle(1, 520);
            Assert.AreEqual(expected.Id, article.Id);
            Assert.AreEqual(expected.NameOfArticle, article.NameOfArticle);
            Assert.AreEqual(expected.ArticlePrice, article.ArticlePrice);

            expected = new Article()
            {
                Id = 1,
                NameOfArticle = "Article from supplier1",
                ArticlePrice = 458
            };

            article = shopService.OrderArticle(1, 458);
            Assert.AreEqual(expected.Id, article.Id);
            Assert.AreEqual(expected.NameOfArticle, article.NameOfArticle);
            Assert.AreEqual(expected.ArticlePrice, article.ArticlePrice);

        }

        [TestMethod]
        public void TestSellArticle_ShouldMarkArticleAsSolled()
        {
            var shopService = new ShopService();
            var article = new Article()
            {
                Id = 1,
                NameOfArticle = "Article from supplier1",
                ArticlePrice = 458
            };

            shopService.SellArticle(1, article, 10);
            Assert.IsTrue(article.IsSold);
            Assert.AreEqual(article.SoldDate.ToShortDateString(), DateTime.Now.ToShortDateString());
            Assert.AreEqual(article.BuyerUserId, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Could not find article with ID: ")]
        public void TestOrderAndSellArticle_ShouldSaveArticleInMemory()
        {
            var shopService = new ShopService();
            var expected = new Article()
            {
                Id = 1,
                NameOfArticle = "Article from supplier1",
                ArticlePrice = 458
            };

            shopService.OrderAndSellArticle(1, 458, 10);
            var article = shopService.GetById(1);
            Assert.AreEqual(expected.Id, article.Id);
            Assert.AreEqual(expected.NameOfArticle, article.NameOfArticle);
            Assert.AreEqual(expected.ArticlePrice, article.ArticlePrice);

            // should trow exception
            article = shopService.GetById(12);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Could not order article")]
        public void TestOrderAndSellArticle_ShouldFailToOrderArticle()
        {
            var shopService = new ShopService();
            shopService.OrderAndSellArticle(1, 20, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
        "Could not save article with id")]
        public void TestSellArticle_ShouldFailToSellArticle()
        {
            var shopService = new ShopService();
            Article article = null;
            shopService.SellArticle(1, article, 10);
        }
    }
}
