using System;

namespace Domain.Domain
{
    internal class Address
    {
        public Address(string street, string city)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("street is required.");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("city is required.");

            Street = street;
            City = city;
        }

        public string Street { get; set; }
        public string City { get; set; }
    }
}