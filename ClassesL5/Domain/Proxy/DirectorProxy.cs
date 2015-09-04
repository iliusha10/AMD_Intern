using System;
using Domain.Interfaces;
using Domain.Persons;

namespace Domain.Proxy
{
    public class DirectorProxy : IAppointment
    {
        private readonly IAppointment _director;
        private readonly Person _smbd;

        public DirectorProxy(Person smbd, Director director)
        {
            _smbd = smbd;
            _director = director;
        }

        public void NewAppontment(DateTime apointmenTime)
        {
            //Console.WriteLine(_smbd.HasAcces());
            if (!_smbd.HasAcces())
                //if (apointmenTime == DateTime.Today)
            {
                Console.WriteLine("Sorry cannot make appointment");
            }
            else
                _director.NewAppontment(apointmenTime);
        }
    }
}