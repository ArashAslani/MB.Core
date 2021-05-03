using System.Collections.Generic;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List();
        }

        public RedirectToPageResult OnPostDeactivate(int Id)
        {
            _articleCategoryApplication.Deactivate(Id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostActivate(int Id)
        { 
            _articleCategoryApplication.Activate(Id);
            return RedirectToPage("./List");
        }
    }
}
