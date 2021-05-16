using System.Collections.Generic;
using Base_FrameWork;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository : IBaseRepository<long,Comment>
    {
        List<CommentViewModel> GetList(); 
    }
}
