using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchManagement.Core.Models;

namespace BranchManagement.Core.Helpers
{
    public static class WorkingHoursValidation
    {
        // Validate that ClosingHour is greater than OpeningHour
        public static ValidationResult ValidateWorkingHours(object value, ValidationContext context)
        {
            var instance = context.ObjectInstance as Branch;
            if (instance == null) return ValidationResult.Success;

            if (instance.ClosingHour <= instance.OpeningHour)
            {
                return new ValidationResult("Closing hour must be later than opening hour.");
            }

            return ValidationResult.Success;
        }

        // Validate that OpeningHour and ClosingHour are in 30-minute intervals
        public static ValidationResult ValidateTimeInterval(object value, ValidationContext context)
        {
            if (value is TimeSpan time)
            {
                if (time.Minutes % 30 != 0)
                {
                    return new ValidationResult("Time must be in 30-minute intervals (e.g., 00:00, 00:30).");
                }
            }
            return ValidationResult.Success;
        }
    }
}
