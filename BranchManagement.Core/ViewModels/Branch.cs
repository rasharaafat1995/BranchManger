using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchManagement.Core.Helpers;

namespace BranchManagement.Core.ViewModels
{
    public class BranchviewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Opening hour is required.")]
        [CustomValidation(typeof(WorkingHoursValidation), nameof(WorkingHoursValidation.ValidateTimeInterval))]
        public TimeSpan OpeningHour { get; set; }

        [Required(ErrorMessage = "Closing hour is required.")]
        [CustomValidation(typeof(WorkingHoursValidation), nameof(WorkingHoursValidation.ValidateWorkingHours))]
        [CustomValidation(typeof(WorkingHoursValidation), nameof(WorkingHoursValidation.ValidateTimeInterval))]

        public TimeSpan ClosingHour { get; set; }

        [Required(ErrorMessage = "Manager name is required.")]
        [StringLength(250, ErrorMessage = "Manager name cannot exceed 250 characters.")]
        public string ManagerName { get; set; }


    }
}