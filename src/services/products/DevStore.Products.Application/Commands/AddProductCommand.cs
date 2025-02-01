using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Models.ValueObjects;
using DevStore.Products.Application.Validations;

namespace DevStore.Products.Application.Commands
{
    public class AddProductCommand : ProductCommand, IAddCommand
    {
        public AddProductCommand(string title, double price, string description, string category, string image, Rating rating)
        {
            Title = title;
            Price = price;
            Description = description;
            Category = category;
            Image = image;
            Rating = rating;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductValidation<ProductCommand>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
