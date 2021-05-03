using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();

        void Add(ArticleCategory entity);

        ArticleCategory GetBy(int Id);

        void Save();

        bool Exists(string title);
    }
}
