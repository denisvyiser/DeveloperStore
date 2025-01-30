using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Models.ValueObjects;

namespace DevStore.Products.Application.Commands
{
    public abstract class ProductCommand : Command
    {
        public string Title { get; protected set; }
        public double Price { get; protected set; }
        public string Description { get; protected set; }
        public string Category { get; protected set; }
        public string Image { get; protected set; }
        public Rating Rating { get; protected set; }
    }
}
