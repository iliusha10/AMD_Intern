using System;

namespace Domain.Exceptions
{
    internal class InternValidationException : Exception
    {
        public string PersonName;
        //string message;

        public InternValidationException(string personNume, string message)
            : base(message)
        {
            PersonName = personNume;
            //Console.Write(personName);
            //Console.WriteLine("public InternValidationException(string personNume, string message)");
        }
    }
}