using System.Collections.Generic;

namespace MB.Infrastructure.View
{
    public class ArticleView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string CreationDate { get; set; }
        public string Content { get; set; }
        public string ArticleCategory { get; set; }
        public long CommentsCount { get; set; }
        public List<CommentViewQuery> Comments { get; set; }
    }
}
