using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.Errors;

public static class SharedKernelErrors
{
    public static class ValueObjects
    {
        public static class Address
        {
            public static readonly DomainError InvalidStreetName = new DomainError("Address.Create.InvalidStreetName", 422, "The street name cannot be empty.", "Address.Create: street parameter is null or empty");
            public static readonly DomainError InvalidCityName = new DomainError("Address.Create.InvalidCityName", 422, "The city name cannot be empty.", "Address.Create: city parameter is null or empty");
            public static readonly DomainError InvalidStateName = new DomainError("Address.Create.InvalidStateName", 422, "The state name cannot be empty.", "Address.Create: state parameter is null or empty");
            public static readonly DomainError InvalidCountryName = new DomainError("Address.Create.InvalidCountryName", 422, "The country name cannot be empty.", "Address.Create: country parameter is null or empty");
            public static readonly DomainError InvalidZipCodeName = new DomainError("Address.Create.InvalidZipCodeName", 422, "The zipCode name cannot be empty.", "Address.Create: zipCode parameter is null or empty");
        }
    }    
}