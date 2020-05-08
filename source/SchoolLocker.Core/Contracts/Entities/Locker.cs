using System.Collections.Generic;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Core.Contracts.Entities
{
    public interface ILocker : IEntityObject
    {
        int Number { get; set; }

        ICollection<Booking> Bookings { get; set; }

    }
}
