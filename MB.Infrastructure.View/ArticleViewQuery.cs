using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.View
{
    public class ArticleViewQuery : IArticleView
    {
        private readonly MBContext _context;

        public ArticleViewQuery(MBContext context)
        {
            _context = context;
        }

        public List<ArticleView> GetArticleViews()
        {
            return _context.Articles.Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Image = x.Picture,
                    CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                    ArticleCategory = x.ArticleCategory.Title,
                    CommentsCount = x.Comments.Count(z=>z.Status == StatusType.Confirmed)
                }).ToList();
        }

        public ArticleView GetArticleView(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Picture,
                CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                Content = x.Content,
                ArticleCategory = x.ArticleCategory.Title,
                Comments = MapComments(x.Comments.Where(z=>z.Status==StatusType.Confirmed))

            }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentViewQuery> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentViewQuery
            {
                Name = comment.Name,
                CreationDate = comment.CreationDate.ToString(CultureInfo.CurrentCulture),
                Message = comment.Massage
            }).ToList();
        }
    }
}
