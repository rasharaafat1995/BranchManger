using BranchManagement.API.Helpers;
using BranchManagement.Core.Interfaces;
using BranchManagement.Core.Models;
using BranchManagement.Core.ViewModels;
using BranchManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BranchManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;
        private readonly IBranchService _BranchService;

        public BookingController(IBookingService BookingService, IBranchService BranchService)
        {
            _BookingService = BookingService;
            _BranchService = BranchService;
        }

        
        [HttpGet("branches")]
        public async Task<IActionResult> GetBranches()
        {
            var branches = await _BranchService.GetAllBranchesAsync();
            return Ok(new
            {
                Branches = branches
            });
        }

        [HttpPost]
        public async Task<IActionResult> BookBranch([FromBody] BookingViewModel booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _BookingService.AddBookingAsync(Mapper.Map<BookingViewModel, Booking>(booking));

            return Ok(new { message = "We will contact you soon after checking availability." });
        }


    }

}
