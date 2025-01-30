namespace DevStore.Core.Models.Pagination
{
    public class Page
    {
        public int Index { get; set; }
        public int Quantity { get; set; }

        public Page(int index, int quantity)
        {
            Index = index < 1 ? 1 : index;
            Quantity = quantity < 1 ? 1 : quantity > 1000 ? 1000 : quantity;
        }
    }
}