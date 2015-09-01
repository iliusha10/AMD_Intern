using System;

namespace Domain.Domain
{
    public class Address:Entity
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

        [Obsolete]
        protected Address()
        {
        }

        public virtual string Street { get; protected set; }
        public virtual string City { get; protected set; }
        public virtual Person Person { get; protected set; }
    }
}