using System.Collections.Generic;
using System.Linq;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MBContext _dbContext;

        public ArticleCategoryRepository(MBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ArticleCategory> GetAll()
        {
            return _dbContext.ArticleCategories.OrderByDescending(x => x.Id).ToList();
        }

        public void Add(ArticleCategory entity)
        {
            _dbContext.ArticleCategories.Add(entity);
            Save();
        }
            
        public ArticleCategory GetBy(int id)
        {
           return _dbContext.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public bool Exists(string title)
        {
            return _dbContext.ArticleCategories.Any(x => x.Title == title);
        }
    }
}
