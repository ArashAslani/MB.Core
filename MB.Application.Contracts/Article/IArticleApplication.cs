using System.Collections.Generic;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> List();

        void Create(CreateArticle command);

        void Edit(EditArticle command);

        EditArticle GetBy(long Id);
    }
}
