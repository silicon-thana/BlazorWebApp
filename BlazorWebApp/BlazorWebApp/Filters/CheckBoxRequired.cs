using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Filters
{
    public class CheckBoxRequired : ValidationAttribute
    {
        public override bool IsValid(object? value) => value is bool b && b;
    }
}
