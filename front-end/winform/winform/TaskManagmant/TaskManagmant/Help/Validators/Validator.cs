using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmant.Help.Validators
{
    public abstract class Validator<T>:IValidator
    {
        public string ControlName { get; set; }
        public bool IsRequired { get; set; }
        public bool IsTouched { get; set; }
        public bool IsValid { get; set; }

        public Validator(string controlName, bool isRequired)
        {
            ControlName = controlName;
            IsRequired = isRequired;
        }

        public virtual string GetValidationMessage(T value)
        {
            string errorMessage;
            if (IsRequired==true&& value==null||value.Equals(GetDefaultValue()))
            {
                IsValid = false;
                errorMessage = $"{ControlName} is required!";
                return errorMessage;
            }
            IsValid = true;
            return null;
        }

        protected virtual T GetDefaultValue()
        {
            return default(T);
        }

    }
}
