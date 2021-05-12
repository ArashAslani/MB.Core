using System.Collections.Generic;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment entity);
        void Save();
        List<CommentViewModel> GetAll();
        Comment Get(long id);
    }
}
