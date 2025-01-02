using BranchManagement.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BranchManagement.Core.Interfaces
{
    public interface IBranchRepository : IRepository<Branch>
    {
       Task<IEnumerable<Branch>> GetAllAsync(BranchSearch branchSearch);
       Task<int> GetAllBranchesCount();
    }
}

