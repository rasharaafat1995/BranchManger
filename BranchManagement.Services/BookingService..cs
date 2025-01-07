using BranchManagement.Core.Interfaces;
using BranchManagement.Core.Models;
using BranchManagement.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BranchManagement.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddBookingAsync(Booking Booking)
        {
            await _unitOfWork.BookingRepository.AddAsync(Booking);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
