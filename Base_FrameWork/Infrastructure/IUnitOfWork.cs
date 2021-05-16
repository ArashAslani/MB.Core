namespace Base_FrameWork.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollBack();
    }
}
