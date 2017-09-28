using System;
using TheShop.Interfaces;
using TheShop.Models;

namespace TheShop
{
    class EndSupplierHandler : ISupplierHandler
    {
        private EndSupplierHandler() { }

        public static EndSupplierHandler Instance
        {
            get { return _instance; }
        }

        public Article Supplay(IArticleReport articleReport)
        {
            return null;
        }

        public void RegisterNext(ISupplierHandler next)
        {
            throw new InvalidOperationException("End of chain handler must be the end of the chain!");
        }

        private static readonly EndSupplierHandler _instance = new EndSupplierHandler();
    }
}
