using TheShop.Models;

namespace TheShop.Interfaces
{
    public interface IArticleSupplier
    {
        Article SupplyArticle(IArticleReport articleReport);
    }
}
