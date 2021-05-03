using System.Collections.Generic;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();

        void Create(CreateArticleCategory command);

        /*Rename item*/
        void Rename(RenameArticleCategory command);

        /*for show the item to rename in view*/
        RenameArticleCategory Get(int id);

        void Activate(int id);
        void Deactivate(int id);
    }
}
