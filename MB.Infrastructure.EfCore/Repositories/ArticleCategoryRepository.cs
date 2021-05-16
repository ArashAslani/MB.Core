using System.Collections.Generic;
using System.Linq;
using Base_FrameWork;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore
{
    public class ArticleCategoryRepository :BaseRepository<int,ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MBContext _context;

        public ArticleCategoryRepository(MBContext context) : base(context)
        {
            _context = context;
        }
    }
}
