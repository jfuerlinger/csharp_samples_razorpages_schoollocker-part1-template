using System;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Core.Contracts.Entities
{
    public interface IBooking : IEntityObject
    {

        int LockerId { get; set; }
        Locker Locker { get; set; }
        int PupilId { get; set; }
        Pupil Pupil { get; set; }
        DateTime From { get; set; }
        DateTime? To { get; set; }

    }
}
