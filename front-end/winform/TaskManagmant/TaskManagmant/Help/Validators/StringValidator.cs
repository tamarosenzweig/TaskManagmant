using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskManagmant.Help.Validators
{
    public class StringValidator : Validator<string>
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public Regex Pattern { get; set; }

        public StringValidator(string controlName, bool isRequired, int minLength, int maxLength, string pattern) : base(controlName, isRequired)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            Pattern = new Regex(pattern);
        }

        public override string GetValidationMessage(string value)
        {
            string errorMessage;
            errorMessage = base.GetValidationMessage(value);
            if (errorMessage != null)
            {
                return errorMessage;
            }
            if (value.Length < MinLength)
            {
                IsValid = false;
                errorMessage = $"{ControlName} must contain minimum {MinLength} chars!";
                return errorMessage;
            }
            if (value.Length > MaxLength)
            {
                IsValid = false;
                errorMessage = $"{ControlName} can contain maximum {MaxLength} chars!";
                return errorMessage;
            }
            if (Pattern.IsMatch(value) == false)
            {
                IsValid = false;
                errorMessage = $"{ControlName} format is incorrect!";
                return errorMessage;
            }
            IsValid = true;
            return null;
        }

        protected override string GetDefaultValue()
        {
            return string.Empty;
        }

    }
}
