using BranchManagement.Core.Interfaces;
using BranchManagement.Core.Models;
using BranchManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BranchManagement.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BranchDbContext _context;
        private readonly DbSet<Booking> _dbSet;

        public BookingRepository(BranchDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Booking>();
        }

        
        public async Task AddAsync(Booking entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
