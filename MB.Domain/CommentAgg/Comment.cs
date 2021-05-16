using MB.Domain.ArticleAgg;
using Base_FrameWork;

namespace MB.Domain.CommentAgg
{
    public class Comment : DomainBase<long>
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Massage { get; private set; }

        public int Status { get; private set; }

        public long ArticleId { get; private set; }

        public Article Article { get; private set; }

        public Comment()
        {
            
        }

        public Comment(string name, string email, string massage, long articleId)
        {
            Name = name;
            Email = email;
            Massage = massage;
            ArticleId = articleId;
            Status = StatusType.New;
        }

        public void Confirm()
        {
            Status = StatusType.Confirmed;
        }

        public void Cancel()
        {
            Status = StatusType.Canceled;
        }
    }

}
