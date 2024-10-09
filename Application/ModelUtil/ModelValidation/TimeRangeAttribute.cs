using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelUtil.ModelValidation
{
    public class TimeRangeAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int time)
            {
                if (time <= 7 || time > 16)
                {
                    return new ValidationResult("AppointmentTime must be between 7 and 17.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
