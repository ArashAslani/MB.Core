using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.IdentityModel.JsonWebTokens;

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

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.GetBy(command.Id);
            article.Edit(command.Title,command.Picture,command.ShortDescription,command.Content,command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public EditArticle GetBy(long Id)
        {
            var article = _articleRepository.GetBy(Id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Content = article.Content,
                Picture = article.Picture,
                ArticleCategoryId = article.CategoryId
            };
        }

        public void Activate(long id)
        {
            var article = _articleRepository.GetBy(id);
            article.Activate();
            _articleRepository.Save();
        }

        public void Deativate(long id)
        {
            var article = _articleRepository.GetBy(id);
            article.Deactivate();
            _articleRepository.Save();
        }
    }
}
