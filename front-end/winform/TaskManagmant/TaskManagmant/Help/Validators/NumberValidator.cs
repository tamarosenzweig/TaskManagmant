using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmant.Help.Validators
{
    public class NumberValidator:Validator<int?>
    {
        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public NumberValidator(string controlName, bool isRequired, int minValue, int maxValue):base(controlName,isRequired)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public override string GetValidationMessage(int? value)
        {
            string errorMessage;
            errorMessage = base.GetValidationMessage(value);
            if (errorMessage != null)
            {
                return errorMessage;
            }
            if (value < MinValue)
            {
                IsValid = false;
                errorMessage = $"{ControlName} value must be minimum {MinValue}.";
                return errorMessage;
            }
            if (value > MaxValue)
            {
                IsValid = false;
                errorMessage = $"{ControlName} can be maximume {MaxValue}.";
                return errorMessage;
            }
            IsValid = true;
            return null;
        }
    }
}
