using System;
using TheShop.Interfaces;
using TheShop.Models;
using TheShop.Services;

namespace TheShop
{
	public class ShopService
	{
		private DatabaseDriver DatabaseDriver;
		private Logger logger;

        private SupplierHandler Supplier1;
        private SupplierHandler Supplier2;
        private SupplierHandler Supplier3;

        public ShopService()
		{
			DatabaseDriver = new DatabaseDriver();
			logger = new Logger();


			Supplier1 = new SupplierHandler(new Supplier1());
			Supplier2 = new SupplierHandler(new Supplier2());
			Supplier3 = new SupplierHandler(new Supplier3());

            Supplier3.RegisterNext(Supplier2);
            Supplier2.RegisterNext(Supplier1);
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
            Article article = OrderArticle(id, maxExpectedPrice);
            SellArticle(id, article, buyerId);
		}

		public Article GetById(int id)
		{
			return DatabaseDriver.GetById(id);
		}

        public Article OrderArticle(int id, int maxExpectedPrice)
        {
            IArticleReport articleRerpot = new ArticleReport(id, maxExpectedPrice);

            Article article = Supplier3.Supplay(articleRerpot);

            #region commented uncleare code
            //         Article article = null;
            //Article tempArticle = null;
            //var articleExists = Supplier1.ArticleInInventory(id);
            //if (articleExists)
            //{
            //	tempArticle = Supplier1.GetArticle(id);

            // "When ordering an article, Shop needs to find the article 
            // amongst the given suppliers where they have it in stock and 
            // where the price is not more expensive than the maximum price 
            // a client is ready to pay for."
            // Why do we do this condition here? I don't understand this part, need more details!
            //	if (maxExpectedPrice < tempArticle.ArticlePrice)
            //	{
            //		articleExists = Supplier2.ArticleInInventory(id);
            //		if (articleExists)
            //		{
            //			tempArticle = Supplier2.GetArticle(id);
            //			if (maxExpectedPrice < tempArticle.ArticlePrice)
            //			{
            //				articleExists = Supplier3.ArticleInInventory(id);
            //				if (articleExists)
            //				{
            //					tempArticle = Supplier3.GetArticle(id);
            //					if (maxExpectedPrice < tempArticle.ArticlePrice)
            //					{
            //						article = tempArticle;
            //					}
            //				}
            //			}
            //		}
            //	}
            //}

            //article = tempArticle;

            #endregion commented unclear code

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            return article;
        }

        public void SellArticle(int id, Article article, int buyerId)
        {
            logger.Debug("Trying to sell article with id=" + id);

            try
            {
                article.IsSold = true;
                article.SoldDate = DateTime.Now;
                article.BuyerUserId = buyerId;
                DatabaseDriver.Save(article);
                logger.Info("Article with id=" + article.Id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
        }
    }
}
