using TheShop.Interfaces;

namespace TheShop.Models
{
    public abstract class Supplier : IArticleSupplier
    {
        public bool ArticleInInventory(int id)
        {
            if (GetArticle(id) != null)
                return true;

            return false;
        }

        public abstract Article GetArticle(int id);

        public Article SupplyArticle(IArticleReport articleReport)
        {
            if (ArticleInInventory(articleReport.Id))
            {
                Article article = GetArticle(articleReport.Id);

                if (article.ArticlePrice <= articleReport.MaxExpectedPrice)
                    return article;
            }

            return null;
        }
    }
}
