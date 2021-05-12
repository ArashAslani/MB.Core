using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MBContext _context;

        public CommentRepository(MBContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<CommentViewModel> GetAll()
        {
            return _context.Comments.Include(x => x.Article)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Massage,
                    Status = x.Status,
                    CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                    Article = x.Article.Title
                }).ToList();
        }

        public Comment Get(long id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);
        }
    }
}
