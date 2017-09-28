using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Models;

namespace TheShop.Services
{
    //in memory implementation
    public class DatabaseDriver
    {
        private List<Article> _articles = new List<Article>();

        public Article GetById(int id)
        {
            if (_articles.Any(x => x.Id == id))
            {
                return _articles.Single(x => x.Id == id);
            }
            throw new Exception("Could not find article with ID: " + id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}
