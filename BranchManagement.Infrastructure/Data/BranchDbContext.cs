
using System.Collections.Generic;
using BranchManagement.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BranchManagement.Infrastructure.Data
{
    public class BranchDbContext : IdentityDbContext
    {
        public BranchDbContext(DbContextOptions<BranchDbContext> options) : base(options) { }
        public DbSet<Branch> Branches { get; set; }
    }
}