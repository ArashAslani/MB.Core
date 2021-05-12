using System;
using System.Collections.Generic;

namespace MB.Infrastructure.View
{
    public interface IArticleView
    {
        List<ArticleView> GetArticleViews();
        ArticleView GetArticleView(long id);
    }
}
