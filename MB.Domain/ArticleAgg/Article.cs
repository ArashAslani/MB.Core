using System;
using System.Collections.Generic;
using Base_FrameWork;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article : DomainBase<long>
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public string Picture { get; private set; }
        public bool IsDeleted { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public int CategoryId { get; private set; }
        public ICollection<Comment> Comments { get; set; }

        public Article()
        {
            
        }

        public Article(string title, string picture, string shortDescription, string content, int categoryId)
        {
            Validate(title,categoryId);
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Picture = picture;
            IsDeleted = false;
            CategoryId = categoryId;
            Comments = new List<Comment>();
        }

        public void Edit(string title, string picture, string shortDescription, string content, int categoryId)
        {
            Validate(title,CategoryId);
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Picture = picture;
            CategoryId = categoryId;
        }

        private static void Validate(string title,int articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
            if (articleCategoryId == 0)
                throw new ArgumentOutOfRangeException();

        }

        public void Activate()
        {
            IsDeleted = false;
        }

        public void Deactivate()
        {
            IsDeleted = true;
        }
    }
}
