using System.ComponentModel.DataAnnotations;

namespace DevStore.Core.Helpers.Repository
{
    public class PropertyValidationAttribute : ValidationAttribute
    {
        public PropertyValidationAttribute()
        {

        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }
    }
}
