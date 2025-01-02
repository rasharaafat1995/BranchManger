using BranchManagement.Core.Interfaces;
using BranchManagement.Infrastructure.Data;
using BranchManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BranchManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BranchDbContext _context;
        private IBranchRepository _branchRepository;
        private IBookingRepository _bookingRepository;

        public UnitOfWork(BranchDbContext context)
        {
            _context = context;
        }

        public IBranchRepository BranchRepository
        {
            get
            {
                return _branchRepository ??= new BranchRepository(_context);  
            }
        }
        public IBookingRepository BookingRepository
        {
            get
            {
                return _bookingRepository ??= new BookingRepository(_context);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
