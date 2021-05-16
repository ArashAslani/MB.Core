using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Base_FrameWork;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository :BaseRepository<long,Article>, IArticleRepository
    {
        private readonly MBContext _context;

        public ArticleRepository(MBContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory).OrderByDescending(x=>x.Id)
                .Select(x=> new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                    IsDeleted = x.IsDeleted,
                    ArticleCategory = x.ArticleCategory.Title
                }).ToList();
        }
    }
}
