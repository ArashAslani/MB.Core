using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckCategoryEntityDuplicated(string title)
        {
            if (_articleCategoryRepository.Exist(x=>x.Title==title))
            {
                throw new DuplicatedCategoryEntityException("This record is already exist");
            }
        }
    }
}