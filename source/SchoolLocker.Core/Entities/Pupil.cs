using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolLocker.Core.Contracts.Entities;

namespace SchoolLocker.Core.Entities
{
    public class Pupil : IPupil
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Name => $"{LastName} {FirstName}";


        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}
