namespace DAB_2_Solution_grp6.DataAccess.Repositories.Reservation
{
    public interface IReservationRepository
    {
        Task<List<Entities.Reservation>> GetReservationsById(string auId);
    }
}
