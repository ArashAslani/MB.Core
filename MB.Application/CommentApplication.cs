using System.Collections.Generic;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<CommentViewModel> List()
        {
           return _commentRepository.GetAll();
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.CreateAndSave(comment);
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Cancel();
            _commentRepository.Save();
        }
    }
}
