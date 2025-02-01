using DevStore.Api.Core.ResponseModels;
using DevStore.Core.Models.ValueObjects;

namespace DevStore.Products.Application.Views
{
    public class ProductView : ViewBase
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Rating Rating { get; set; }
    }
}
