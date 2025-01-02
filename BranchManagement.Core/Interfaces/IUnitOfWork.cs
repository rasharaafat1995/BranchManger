
namespace BranchManagement.Core.Interfaces
{
    public interface IUnitOfWork 
    {
        IBranchRepository BranchRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
