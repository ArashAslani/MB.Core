namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void CheckArticleEntityDuplicated(string title);
    }
 }
