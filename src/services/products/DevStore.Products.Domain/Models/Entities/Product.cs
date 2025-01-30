using DevStore.Core.Helpers.Repository;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.ValueObjects;

namespace DevStore.Products.Domain.Models.Entities
{
    public class Product : Entity
    {
        public Product(Guid id,string title, double price, string description, string category, string image)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Category = category;
            Image = image;            
        }

        [PropertyValidation]
        public string Title { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Image { get; private set; }
        public Rating Rating { get; private set; }
 
    }
}
