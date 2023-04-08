using DAB_2_Solution_grp6.DataAccess.Exceptions;
using DAB_2_Solution_grp6.DataAccess.Repositories.Global;
using DAB_2_Solution_grp6.DataAccess.Repositories.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DAB_2_Solution_grp6.Api.Controllers.CanteenApp
{
    [ApiController]
    [Route("api")]
    public class CanteenAppController : ControllerBase
    {
        private readonly IGlobalRepository _globalRepository;
        private readonly IReservationRepository _reservationRepository;

        public CanteenAppController(IGlobalRepository globalRepository, IReservationRepository reservationRepository)
        {
            _globalRepository = globalRepository;
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Clear Database
        /// </summary>
        /// <response code="204">Database was cleared</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        public async Task<ActionResult> ClearDatabase()
        {
            await _globalRepository.RemoveAll();

            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Clear Database
        /// </summary>
        /// <response code="204">Database was cleared</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{cpr}")]
        public async Task<ActionResult> GetReservationById(string cpr)
        {
            try
            {
                var reservation = await _reservationRepository.GetReservationById(cpr);

                return Ok(reservation);
            }
            catch (ReservationNotFoundException)
            {
                return NotFound(cpr);
            }
        }
    }
}
