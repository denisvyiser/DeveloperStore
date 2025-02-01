namespace DevStore.Core.Models.Pagination
{
    public class Order
    {
        public string Property { get; set; }
        public string Direction { get; set; }

        public Order(string property, string direction)
        {
            Property = property;
            Direction = direction;
        }

        //public Order(string property, string crescent)
        //    : this(property, Convert.ToBoolean(crescent)) { }
    }
}