﻿namespace TheShop.Models
{
    public class Supplier3 : Supplier
    {
        public override Article GetArticle(int id)
        {
            if (id != 1)
                return null;

            return new Article()
            {
                Id = 1,
                NameOfArticle = "Article from supplier3",
                ArticlePrice = 460
            };
        }
    }
}
