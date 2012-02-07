using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SampArch.Domain
{
    public class ValidationInfo
    {
        public bool IsValid { get; private set; }
        public List<ValidationResult> Errors { get; private set; }

        public ValidationInfo(object source)
        {
            var context = new ValidationContext(source, serviceProvider: null, items: null);
            Errors = new List<ValidationResult>();
            IsValid = Validator.TryValidateObject(source, context, Errors);
        }

        public static Tuple<bool, List<ValidationResult>> Validate<T>(T source)
        {
            var context = new ValidationContext(source, serviceProvider: null, items: null);
            var errors = new List<ValidationResult>();
            var validity = Validator.TryValidateObject(source, context, errors);
            return new Tuple<bool, List<ValidationResult>>(validity, errors);
        }
    }
}
