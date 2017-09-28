using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Interfaces;

namespace TheShop
{
    class ArticleReport : IArticleReport
    {
        public ArticleReport(int id, int maxExpectedPrice)
        {
            Id = id;
            MaxExpectedPrice = maxExpectedPrice;
        }

        public int Id { get; }

        public int MaxExpectedPrice { get; }
    }
}
