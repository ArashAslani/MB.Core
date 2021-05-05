using System.Collections.Generic;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetAll();

        void Add(Article entity);

        Article GetBy(long id);

        void Save();
    }
}
