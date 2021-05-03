using System.Collections.Generic;
using System.Globalization;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _validatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var categories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var category in categories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id= category.Id,
                    Title = category.Title,
                    IsDeleted = category.IsDeleted,
                    CreationDate = category.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }

            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title,_validatorService);
            _articleCategoryRepository.Add(articleCategory);
        }


        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
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
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }

        public void Deactivate(int id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Deactivate();
            _articleCategoryRepository.Save();
        }
    }
}
   