using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using MB.Infrastructure.View;

namespace MB.Presentation.Razor.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleView> ArticleViews;
        private readonly IArticleView _articles;

        public IndexModel(IArticleView articles)
        {
            _articles = articles;
        }

        public void OnGet()
        {
            ArticleViews = _articles.GetArticleViews();
        }
    }
}
