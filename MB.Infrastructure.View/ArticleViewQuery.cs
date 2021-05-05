using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        public List<ArticleView> getArticleViews()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x=> new ArticleView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Picture,
                CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                ArticleCategory = x.ArticleCategory.Title
            }).ToList();
        }
    }
}
