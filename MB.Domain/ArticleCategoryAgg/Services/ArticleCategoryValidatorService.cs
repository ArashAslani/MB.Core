using System;
using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public void CheckCategoryEntityDuplicated(string title)
        {
            if (_articleCategoryRepository.Exists(title))
            {
                throw new DuplicatedCategoryEntityException("This record is already exist");
            }
        }
    }
}