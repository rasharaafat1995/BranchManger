
namespace BranchManagement.Core.Interfaces
{
    public interface IUnitOfWork 
    {
        IBranchRepository BranchRepository { get; }
        IBookingRepository BookingRepository { get; }
        
        Task<int> SaveChangesAsync();
    }
}
