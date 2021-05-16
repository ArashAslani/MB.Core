using System.Collections.Generic;
using Base_FrameWork.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleApplication(IArticleRepository articleRepository,IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public List<ArticleViewModel> List()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.Picture, command.ShortDescription, command.Content,
                command.ArticleCategoryId);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetBy(command.Id);
            article.Edit(command.Title,command.Picture,command.ShortDescription,command.Content,command.ArticleCategoryId);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetBy(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }

        public void Deativate(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetBy(id);
            article.Deactivate();
            _unitOfWork.CommitTran();
        }
    }
}
