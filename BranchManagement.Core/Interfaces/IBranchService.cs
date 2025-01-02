using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchManagement.Core.Models;

namespace BranchManagement.Core.Interfaces
{
        public interface IBranchService
        {
            Task AddBranchAsync(Branch branch);
            Task<IEnumerable<Branch>> GetAllBranchesAsync();
            Task<IEnumerable<Branch>> GetAllBranchesAsync(BranchSearch branch);
            Task<int> GetAllBranchesCount();
            Task<Branch> GetBranchByIdAsync(int id);
            Task UpdateBranchAsync(Branch branch);
            Task DeleteBranchAsync(int id);
        }
    }