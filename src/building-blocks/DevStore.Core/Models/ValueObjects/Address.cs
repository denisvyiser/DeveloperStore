namespace DevStore.Core.Models.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string city, string street, string number, string zipCode)
        {
            City = city;
            Street = street;
            Number = number;
            ZipCode = zipCode;

        }

        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }
        public string ZipCode { get; protected set; }
        public Geolocation Geolocation { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return Number;
            yield return ZipCode;
            yield return Geolocation;
        }
    }
}
