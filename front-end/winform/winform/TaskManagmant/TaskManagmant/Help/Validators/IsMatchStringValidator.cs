using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagmant.Help.Validators
{
    public class IsMatchStringValidator : StringValidator
    {
        public Control ControlToCompare { get; set; }

        public string ControlToCompareName { get; set; }

        public IsMatchStringValidator(string controlName, bool isRequired, int minLength, int maxLength, string pattern,Control controlToCompare,string controlToCompareName) : base(controlName, isRequired, minLength, maxLength, pattern)
        {
            ControlToCompare = controlToCompare;
            ControlToCompareName = controlToCompareName;
        }

        public override string GetValidationMessage(string value)
        {
            string errorMessage;
            errorMessage=base.GetValidationMessage(value);
            if (errorMessage != null)
            {
                return errorMessage;
            }
            return GetIsMatchMessage(value);
        }

        public string GetIsMatchMessage(string value)
        {
            if (value.Equals(ControlToCompare.Text) == false)
            {
                IsValid = false;
                string errorMessage = $"{ControlName} is not match to {ControlToCompareName}";
                return errorMessage;
            }
            IsValid = true;
            return null;
        }
    }
}
