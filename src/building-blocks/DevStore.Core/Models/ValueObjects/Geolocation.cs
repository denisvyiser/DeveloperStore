namespace DevStore.Core.Models.ValueObjects
{
    public class Geolocation : ValueObject
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
