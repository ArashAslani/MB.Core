using System.Collections.Generic;
using Base_FrameWork;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IBaseRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
    }
}
