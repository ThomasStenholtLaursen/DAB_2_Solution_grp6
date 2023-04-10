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

        public async Task<Entities.Reservation> GetReservationById(string cpr)
        {
            var reservation = await _dbContext.Reservations.Include(x => x.Meals).FirstOrDefaultAsync(x => x.Cpr == cpr);

            if (reservation != null)
            {
                return reservation;
            }

            throw new ReservationNotFoundException();
        }

        public async Task<IReadOnlyList<Entities.Reservation>> GetTheDailyReservationsForCanteen(string canteenName)
        {
            var canteen = await _dbContext.Canteens.FirstOrDefaultAsync(x => x.Name == canteenName);

            var menu = await _dbContext.Menus.Where(x => canteen != null && x.CanteenId == canteen.CanteenId).FirstOrDefaultAsync(); //TODO: Missing DateTime Compare

            var reservations = await _dbContext.Reservations.Where(x => menu != null && x.MenuId == menu.MenuId).ToListAsync();

            return reservations;
        }
    }
}
