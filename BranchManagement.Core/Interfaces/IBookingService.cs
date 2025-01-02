using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchManagement.Core.Models;

namespace BranchManagement.Core.Interfaces
{
        public interface IBookingService
        {
            Task AddBookingAsync(Booking booking);
        }
    }