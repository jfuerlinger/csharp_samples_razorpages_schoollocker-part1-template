using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Persistence
{
    internal class LockerRepository : ILockerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LockerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}