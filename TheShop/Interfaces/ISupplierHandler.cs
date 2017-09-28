using TheShop.Models;

namespace TheShop.Interfaces
{
    interface ISupplierHandler
    {
        Article Supplay(IArticleReport articleReport);
        void RegisterNext(ISupplierHandler next);
    }
}
