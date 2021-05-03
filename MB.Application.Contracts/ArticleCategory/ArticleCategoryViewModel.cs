namespace MB.Application.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        //This object of model is for get list and change creationdate to string
        public int Id { get; set; }

        public string Title { get; set; }

        public string CreationDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
