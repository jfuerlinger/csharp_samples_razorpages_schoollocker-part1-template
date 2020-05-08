using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolLocker.Core.Contracts.Entities;
namespace SchoolLocker.Core.Entities
{
    public class Booking : IBooking
    {

        public int LockerId { get; set; }

        [ForeignKey(nameof(LockerId))]
        public Locker Locker { get; set; }
        public int PupilId { get; set; }

        [ForeignKey(nameof(PupilId))]
        public Pupil Pupil { get; set; }

        public DateTime From { get; set; }
        public DateTime? To { get; set; }

        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}
