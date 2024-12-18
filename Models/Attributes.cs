using System.ComponentModel.DataAnnotations;

namespace TestProject.Attributes
{
    public class FileExtensionValidationAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public FileExtensionValidationAttribute(string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string fileName)
            {
                string fileExtension = Path.GetExtension(fileName)?.ToLower();
                if (_allowedExtensions.Contains(fileExtension))
                {
                    return ValidationResult.Success!;
                }
                return new ValidationResult($"File phải có đuôi: {string.Join(", ", _allowedExtensions)}");
            }
            return new ValidationResult("Tên file không hợp lệ.");
        }
    }
}
