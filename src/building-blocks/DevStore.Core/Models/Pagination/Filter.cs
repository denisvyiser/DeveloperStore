namespace DevStore.Core.Models.Pagination
{
    public class Filter
    {
        public Filter(string property, Operator _operator, string value)
        {
            Property = property;
            Operator = _operator;
            Value = value;
        }

        public string Property { get; set; }
        public Operator Operator { get; set; }
        public string Value { get; set; }
    }
}
