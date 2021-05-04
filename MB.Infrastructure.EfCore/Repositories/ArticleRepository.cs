using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MBContext _context;

        public ArticleRepository(MBContext context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetAll()
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

        public void Add(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
