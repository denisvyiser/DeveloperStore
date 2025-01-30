
namespace DevStore.Core.Models.Pagination
{
    public class PaginationObject
    {
        public Page Page { get; set; }
        public List<Order> Order { get; set; }

        public int TotalItem { get; set; }

    }
}