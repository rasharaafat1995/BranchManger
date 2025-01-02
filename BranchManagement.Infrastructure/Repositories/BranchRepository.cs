using BranchManagement.Core.Interfaces;
using BranchManagement.Core.Models;
using BranchManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BranchManagement.Infrastructure.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly BranchDbContext _context;
        private readonly DbSet<Branch> _dbSet;

        // Constructor to inject the DbContext
        public BranchRepository(BranchDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Branch>();
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<Branch>> GetAllAsync(BranchSearch branchSearch)
        {
            if (branchSearch != null && !string.IsNullOrEmpty(branchSearch.Title))
            {
                return await _dbSet.Where(p=>p.Title.Contains(branchSearch.Title)).Skip((branchSearch.PageNo-1)*branchSearch.PageSize).Take(branchSearch.PageSize).ToListAsync();
            }
            else if(branchSearch !=null)
            {
                return await _dbSet.Skip((branchSearch.PageNo-1) * branchSearch.PageSize).Take(branchSearch.PageSize).ToListAsync();

            }
            else
            {
                return await _dbSet.ToListAsync();
            }
        }
        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task AddAsync(Branch entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(Branch entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(Branch entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> GetAllBranchesCount()
        {
            return await _dbSet.CountAsync(); 
        }
    }
}
