using System;
using Domain.Persons;

namespace Domain.CompanyAssets
{
    public class Address : Entity
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
        public virtual Company Company { get; protected set; }

        public virtual void ChangeAddress(string street, string city)
        {
            Street = street;
            City = city;
        }
    }
}