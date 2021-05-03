namespace MB.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckCategoryEntityDuplicated(string title);
    }
}
