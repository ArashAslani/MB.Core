using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        public List<ArticleViewModel> List()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.Picture, command.ShortDescription, command.Content,
                command.ArticleCategoryId);
            _articleRepository.Add(article);
        }
    }
}
