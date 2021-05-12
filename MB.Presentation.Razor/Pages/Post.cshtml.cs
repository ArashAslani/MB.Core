using MB.Application.Contracts.Comment;
using MB.Infrastructure.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Pages
{
    public class PostModel : PageModel
    {
        public ArticleView Article { get; set; }
        private readonly IArticleView _article;
        private readonly ICommentApplication _commentApplication;

        public PostModel(IArticleView article, ICommentApplication commentApplication)
        {
            _article = article;
            _commentApplication = commentApplication;
        }


        public void OnGet(long id)
        {
            Article = _article.GetArticleView(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./Post",new {id = command.ArticleId});
        }
    }
}
