using System;
using System.Windows.Forms;


namespace TaskManagmant.Help.Validators
{
    public class DateValidator : Validator<DateTime>
    {
        public DateTimePicker ControlToCompare { get; set; }

        public string ControlToCompareName { get; set; }

        public DateValidator(string controlName, bool isRequired, DateTimePicker controlToCompare, string controlToCompareName) : base(controlName, isRequired)
        {
            ControlToCompare = controlToCompare;
            ControlToCompareName = controlToCompareName;
        }

        public DateValidator(string controlName, bool isRequired) : base(controlName, isRequired)
        {
        }

        public override string GetValidationMessage(DateTime value)
        {
            string errorMessage;
            errorMessage = base.GetValidationMessage(value);
            if (errorMessage == null)
            {
                if (ControlToCompare == null)
                {
                    if (value.Date < DateTime.Today)
                    {
                        IsValid = false;
                        errorMessage = $"{ControlName} can\'t be less than today!";
                        return errorMessage;
                    }
                }
                else if (value.Date < ControlToCompare.Value.Date)
                {
                    IsValid = false;
                    errorMessage = $"{ControlName} can\'t be less than {ControlToCompareName}!";
                    return errorMessage;
                }
            }
            IsValid = true;
            return null;
        }
    }
}
