namespace DevStore.Core.Models.ValueObjects
{
    public class Geolocation : ValueObject
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
