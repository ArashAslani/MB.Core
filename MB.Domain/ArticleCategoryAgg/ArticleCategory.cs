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

<<<<<<< HEAD
        public ICollection<Article> Articles { get; set; }


=======
>>>>>>> 5a22cc78532842209f5737cad100d2fc5b9a1b67
        protected ArticleCategory()
        {

        }

        public ArticleCategory(string title , IArticleCategoryValidatorService validatorService)
        {
            Title = title;
            validatorService.CheckCategoryEntityDuplicated(title);
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }

        public void Rename(string title)
        {
            Title = title; 
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
