using System;
using System.Collections.Generic;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreationDate { get; private set; }

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
            CreationDate = DateTime.Now;
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
