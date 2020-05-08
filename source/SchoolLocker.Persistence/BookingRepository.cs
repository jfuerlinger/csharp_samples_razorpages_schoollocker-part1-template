using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddRangeAsync(Booking[] bookings)
        {
            await _dbContext.Bookings.AddRangeAsync(bookings);
        }

        // 2020-07-01  2020-07-20  ==> 0
        // 2020-07-01  2020-07-21  ==> 1
        // 2020-06-29  2020-07-20  ==> 1
        // 2020-07-20  2020-08-08  ==> 1
        // 2019-10-21  2020-09-03  ==> 3
        // 2020-06-29  2020-08-16  ==> 3

    }
}