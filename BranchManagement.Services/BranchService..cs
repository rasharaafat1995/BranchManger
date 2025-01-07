using BranchManagement.Core.Interfaces;
using BranchManagement.Core.Models;
using BranchManagement.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BranchManagement.Services
{
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddBranchAsync(Branch branch)
        {
            await _unitOfWork.BranchRepository.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync(BranchSearch branchSearch)
        {
            return await _unitOfWork.BranchRepository.GetAllAsync(branchSearch);
        }

        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            var branch = await _unitOfWork.BranchRepository.GetByIdAsync(id);
            if (branch == null)
                throw new KeyNotFoundException("Branch not found.");
            return branch;
        }

        public async Task UpdateBranchAsync(Branch branch)
        {
            var existingBranch = await _unitOfWork.BranchRepository.GetByIdAsync(branch.Id);
            if (existingBranch == null)
                throw new KeyNotFoundException("Branch not found.");

            existingBranch.Title = branch.Title;
            existingBranch.OpeningHour = branch.OpeningHour;
            existingBranch.ClosingHour = branch.ClosingHour;
            existingBranch.ManagerName = branch.ManagerName;

            _unitOfWork.BranchRepository.Update(existingBranch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBranchAsync(int id)
        {
            var branch = await _unitOfWork.BranchRepository.GetByIdAsync(id);
            if (branch == null)
                throw new KeyNotFoundException("Branch not found.");

            _unitOfWork.BranchRepository.Delete(branch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            return await _unitOfWork.BranchRepository.GetAllAsync();
        }

        public async Task<int> GetAllBranchesCount()
        {
            return await _unitOfWork.BranchRepository.GetAllBranchesCount();
        }
    }
}
