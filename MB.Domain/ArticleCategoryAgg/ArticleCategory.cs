using System;
using System.Collections.Generic;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using Base_FrameWork;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : DomainBase<int>
    {
        public string Title { get; private set; }

        public bool IsDeleted { get; private set; }

        public ICollection<Article> Articles { get; set; }

        protected ArticleCategory()
        {

        }

        public ArticleCategory(string title , IArticleCategoryValidatorService validatorService)
        {
            Validate(title);
            Title = title;
            validatorService.CheckCategoryEntityDuplicated(title);
            IsDeleted = false;
            Articles = new List<Article>();
        }

        public void Rename(string title)
        {
            Validate(title);
            Title = title; 
        }

        private static void Validate(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        public void Deactivate()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
