using Restaurant.DDD.Core.Errors;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Guards;
using Restaurant.DDD.SharedKernel.Monads;
using static Restaurant.DDD.Core.Errors.SharedKernelErrors.ValueObjects;

namespace Restaurant.DDD.SharedKernel.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        private Address(string street, string city, string state, string country, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public static Result<Address, DomainError> Create(string street, string city, string state, string country, string zipCode)
        {
            return Guard.Against.NullOrEmpty(street, SharedKernelErrors.ValueObjects.Address.InvalidStreetName).Bind(street =>
                   Guard.Against.NullOrEmpty(city, SharedKernelErrors.ValueObjects.Address.InvalidCityName)).Bind(city => 
                   Guard.Against.NullOrEmpty(state, SharedKernelErrors.ValueObjects.Address.InvalidStateName)).Bind(state => 
                   Guard.Against.NullOrEmpty(country, SharedKernelErrors.ValueObjects.Address.InvalidCountryName)).Bind(country => 
                   Guard.Against.NullOrEmpty(zipCode, SharedKernelErrors.ValueObjects.Address.InvalidZipCodeName)).Bind(zipCode => 
                   Result<Address, DomainError>.Success(new Address(street, city, state, country, zipCode)));
        }

        protected override int GetValueHashCode()
        {
            return HashCode.Combine(Street, City, State, Country, ZipCode);
        }

        protected override bool ValueEquals(Address other)
        {
            return Street.Equals(other.Street)
                && City.Equals(other.City)
                && State.Equals(other.State)
                && Country.Equals(other.Country)
                && ZipCode.Equals(other.ZipCode);
        }
    }
}
