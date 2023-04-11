using DAB_2_Solution_grp6.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.DataAccess.Repositories.Reservation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CanteenAppDbContext _dbContext;

        public ReservationRepository(CanteenAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entities.Reservation> GetReservationById(string auId)
        {
            var reservation = await _dbContext.Reservations
                .Include(reservation => reservation.Meals)
                .FirstOrDefaultAsync(reservation => reservation.AuId == auId && reservation.Created.Date == DateTime.Today);

            return reservation ?? throw new ReservationNotFoundException();
        }
    }
}
