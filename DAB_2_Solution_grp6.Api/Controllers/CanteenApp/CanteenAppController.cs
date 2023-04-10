using AutoMapper;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response;
using DAB_2_Solution_grp6.DataAccess.Exceptions;
using DAB_2_Solution_grp6.DataAccess.Repositories.Canteen;
using DAB_2_Solution_grp6.DataAccess.Repositories.Global;
using DAB_2_Solution_grp6.DataAccess.Repositories.Menu;
using DAB_2_Solution_grp6.DataAccess.Repositories.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DAB_2_Solution_grp6.Api.Controllers.CanteenApp
{
    [ApiController]
    [Route("api")]
    public class CanteenAppController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGlobalRepository _globalRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly ICanteenRepository _canteenRepository;
        private readonly IMenuRepository _menuRepository;

        public CanteenAppController(
            IMapper mapper, 
            IGlobalRepository globalRepository, 
            IReservationRepository reservationRepository, 
            ICanteenRepository canteenRepository, 
            IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _globalRepository = globalRepository;
            _reservationRepository = reservationRepository;
            _canteenRepository = canteenRepository;
            _menuRepository = menuRepository;
        }

        /// <summary>
        /// Gets the day's menu options for a canteen given as input
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("canteens/{canteenName}/menus/today")]
        public async Task<ActionResult> GetDailyMenuOptions(string canteenName)
        {
            try
            {
                var menu = (await _canteenRepository.GetCanteenByNameAsync(canteenName)).Menus!
                    .FirstOrDefault(x => x.Created.Date == DateTime.Today);

                var response = _mapper.Map<DailyMenuResponse>(menu);

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(canteenName);
            }
        }

        ///// <summary>
        ///// Get the reservation for a given customer
        ///// </summary>
        ///// <response code="200">The customer was found</response>
        ///// <response code="404">The customer could not be found</response>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet("customers/{cpr}")]
        //public async Task<ActionResult> GetReservationById(string cpr)
        //{
        //    try
        //    {
        //        var reservation = await _reservationRepository.GetReservationById(cpr);

        //        return Ok(reservation);
        //    }
        //    catch (ReservationNotFoundException)
        //    {
        //        return NotFound(cpr);
        //    }
        //}

        /// <summary>
        /// Number of reservations for each of the daily menu options for a canteen
        /// </summary>
        /// <response code="200">The customer was found</response>
        /// <response code="404">The customer could not be found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("canteens/{canteenName}/reservations/today")]
        public async Task<ActionResult> GetReservationsQuantity(string canteenName)
        {
            try
            {
                var canteen = await _canteenRepository.GetCanteenByNameAsync(canteenName);

                if (canteen.Menus == null) 
                    return NotFound($"Could not find any menus for '{canteenName}'");

                var menu = canteen.Menus.FirstOrDefault(x => x.Created.Date == DateTime.Today);
                    
                var response = new ReservationsQuantityResponse
                {
                    WarmDish = new WarmDish
                    {
                        Amount = menu!.Reservations!.Sum(r => r.WarmQuantity ?? 0),
                        Name = menu!.WarmDishName
                    },
                    StreetFood = new StreetFood
                    {
                        Amount = menu!.Reservations!.Sum(r => r.StreetQuantity ?? 0),
                        Name = menu!.StreetFoodName
                    }
                };

                return Ok(response);
            }
            catch (ReservationNotFoundException)
            {
                return NotFound(canteenName);
            }
        }

        /// <summary>
        /// Just-in-time meal options and the available (canceled) daily menu
        /// </summary>
        /// <response code="200">The customer was found</response>
        /// <response code="404">The customer could not be found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("canteens/{canteenName}/availableMeals")]
        public async Task<ActionResult> GetAvailableMealsForCanteen(string canteenName)
        {
            try
            {
                var canteen = await _canteenRepository.GetCanteenByNameAsync(canteenName);

                var canceledMeals = canteen.Menus!
                    .FirstOrDefault(x => x.Created.Date == DateTime.Today)?.Reservations!
                    .SelectMany(x => x.Meals!)
                    .Where(x => x.ReservationId == null)
                    .ToList();

                var jitMeals = canteen.JitMeals;

                var response = new AvailableMealsResponse
                {
                    CanceledMeals = canceledMeals!,
                    JitMeals = jitMeals!
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(canteenName);
            }
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
    }
}
