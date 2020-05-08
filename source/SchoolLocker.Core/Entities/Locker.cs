using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolLocker.Core.Contracts.Entities;

namespace SchoolLocker.Core.Entities
{
    public class Locker : ILocker
    {
        public int Number { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Locker()
        {
            Bookings=new List<Booking>();
        }

        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}
