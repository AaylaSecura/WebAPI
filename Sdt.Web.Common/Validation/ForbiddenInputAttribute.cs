using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Web.Common.Validation
{
    public class ForbiddenInputAttribute : ValidationAttribute
    {
        private readonly IEnumerable<string> _blackList;

        public ForbiddenInputAttribute(string blackList) : base($"{blackList} ist nicht erlaubt!")
        {
            _blackList = blackList.Split(',').Select(c => c.Trim().ToLower());
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string tempName)
            {
                if (_blackList.Any(c => c == tempName.ToLower())) //Fehlerfall
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.MemberName ?? validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }
}
