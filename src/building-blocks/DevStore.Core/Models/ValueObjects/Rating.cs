namespace DevStore.Core.Models.ValueObjects
{
    public class Rating : ValueObject
    {
        public Rating(string rate, string count)
        {
            Rate = rate;
            Count = count;
        }

        public string Rate { get; private set; }
        public string Count { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Rate;
            yield return Count;
        }
    }
}
