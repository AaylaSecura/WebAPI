using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Web.Common.Validation
{
    public class NoFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not null)
            {
                return ((DateTime) value) <= DateTime.Now;
            }

            return true;
        }
    }
}
