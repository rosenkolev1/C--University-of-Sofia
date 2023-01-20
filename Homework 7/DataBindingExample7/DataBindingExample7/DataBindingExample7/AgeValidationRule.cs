using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBindingExample7
{
    public class AgeValidationRule : ValidationRule
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString())) return new ValidationResult(false, $"The age entered must be between {MinAge} and {MaxAge}");

            int enteredAge = int.Parse(value.ToString());

            if (enteredAge < MinAge || enteredAge > MaxAge)
            {
                return new ValidationResult(false, $"The age entered must be between {MinAge} and {MaxAge}");
            }

            return new ValidationResult(true, null);
        }
    }
}
