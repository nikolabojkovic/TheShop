using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Interfaces;
using TheShop.Models;

namespace TheShop
{
    class SupplierHandler : ISupplierHandler
    {
        public SupplierHandler(IArticleSupplier articleSupplier)
        {
            _supplier = articleSupplier;
            _next = EndSupplierHandler.Instance;
        }

        public Article Supplay(IArticleReport articleReport)
        {
            Article response = _supplier.SupplyArticle(articleReport);

            if (response == null)
            {
                return _next.Supplay(articleReport);
            }

            return response;
        }

        public void RegisterNext(ISupplierHandler next)
        {
            _next = next;
        }

        private readonly IArticleSupplier _supplier;
        private ISupplierHandler _next;
    }
}
