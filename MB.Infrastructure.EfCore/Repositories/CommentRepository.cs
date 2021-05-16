using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Base_FrameWork;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class CommentRepository :BaseRepository<long,Comment>, ICommentRepository
    {
        private readonly MBContext _context;

        public CommentRepository(MBContext context) : base(context)
        {
            _context = context;
        }


        public List<CommentViewModel>   GetList()
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

    }
}
