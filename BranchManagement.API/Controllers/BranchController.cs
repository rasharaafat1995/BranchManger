using BranchManagement.API.Helpers;
using BranchManagement.Core.Interfaces;
using BranchManagement.Core.Models;
using BranchManagement.Core.ViewModels;
using BranchManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BranchManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] BranchviewModel branch)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Branch NewBranch = Mapper.Map<BranchviewModel, Branch>(branch);
            await _branchService.AddBranchAsync(NewBranch);
            return CreatedAtAction(nameof(GetBranchById), new { id = NewBranch.Id }, NewBranch);
        }

        [HttpGet]
        [Route("GetAllBranches")]
        public async Task<IActionResult> GetAllBranches([FromQuery] BranchSearch branchSearch)
        {
            var branches = await _branchService.GetAllBranchesAsync(branchSearch);
            var totalItems = await _branchService.GetAllBranchesCount();
            return Ok(new
            {
                TotalItems = totalItems,
                Branches = branches
            });
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(new { Branches = branches });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            try
            {
                var branch = await _branchService.GetBranchByIdAsync(id);
                return Ok(branch);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] BranchviewModel branch)
        {
            if (id != branch.Id)
                return BadRequest("Branch ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                
                await _branchService.UpdateBranchAsync(Mapper.Map<BranchviewModel, Branch>(branch));
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {
                await _branchService.DeleteBranchAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
