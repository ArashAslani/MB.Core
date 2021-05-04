using System;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public string Picture { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public int CategoryId { get; private set; }

        public Article()
        {
            
        }

        public Article(string title, string picture, string shortDescription, string content, int categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Picture = picture;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            CategoryId = categoryId;
        }
    }
}
