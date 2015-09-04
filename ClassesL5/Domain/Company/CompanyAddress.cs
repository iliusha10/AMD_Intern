using System;

namespace Domain.Domain
{
    internal class CompanyAddress // singleton pattern
    {
        public string Street { get; private set; }
        public string City { get; private set; }

        private static readonly CompanyAddress address = new CompanyAddress();
        // Explicit static constructor to tell C# compiler to initialize field only on first of class.
        static CompanyAddress()
        {
        }

        private CompanyAddress()
        {
            Street = "Giran";
            City = "Aden";
        }

        public static CompanyAddress Address
        {
            get { return address; }
        }

        public void SetStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("street is required.");
            Street = street;
        }

        public void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("city is required.");
            City = city;
        }
    }
}