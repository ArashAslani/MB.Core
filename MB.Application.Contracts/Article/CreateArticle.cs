namespace MB.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public int ArticleCategoryId { get; set; }
    }
}
