using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchManagement.Core.Models;

namespace BranchManagement.Core.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int BranchId { get; set; }

        //public Branch Branch { get; set; }
    }
}