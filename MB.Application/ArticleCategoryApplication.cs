using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Base_FrameWork.Infrastructure;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _validatorService;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService validatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _validatorService = validatorService;
            _unitOfWork = unitOfWork;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
                return articleCategories.Select(x=>new ArticleCategoryViewModel
                {
                    Id= x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
                }).OrderByDescending(x=>x.Id).ToList();
        }

        public void Create(CreateArticleCategory command ) 
        {
            _unitOfWork.BeginTran();
            var articleCategory = new ArticleCategory(command.Title,_validatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }


        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            articleCategory.Rename(command.Title);
            _unitOfWork.CommitTran();
        }

        public RenameArticleCategory Get(int id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };

        }

        public void Activate(int id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Activate();
            _unitOfWork.CommitTran();
        }

        public void Deactivate(int id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Deactivate();
            _unitOfWork.CommitTran();
        }
    }
}
   