﻿using AutoMapper;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query1;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query2;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query3;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query4;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query5;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query6;
using DAB_2_Solution_grp6.DataAccess.Entities;
using DAB_2_Solution_grp6.DataAccess.Exceptions;
using DAB_2_Solution_grp6.DataAccess.Repositories.Canteen;
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
        private readonly IReservationRepository _reservationRepository;
        private readonly ICanteenRepository _canteenRepository;
        private readonly IMenuRepository _menuRepository;

        public CanteenAppController(
            IMapper mapper,
            IReservationRepository reservationRepository,
            ICanteenRepository canteenRepository,
            IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _canteenRepository = canteenRepository;
            _menuRepository = menuRepository;
        }

        /// <summary>
        /// Query (1) Gets the day's menu options for a canteen given as input
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("query1/{canteenName}")]
        public async Task<ActionResult> GetDailyMenuOptions(string canteenName)
        {
            try
            {
                var menu = (await _canteenRepository.GetCanteenWithMenusByNameAsync(canteenName)).Menus!
                    .FirstOrDefault(menu => menu.Created.Date == DateTime.Today);

                var response = _mapper.Map<DailyMenuResponse>(menu);

                return Ok(response);
            }
            catch (CanteenNotFoundException)
            {
                return NotFound(canteenName);
            }
        }

        /// <summary>
        /// Query (2) Get the reservation for a given customer
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("query2/{auId}")]
        public async Task<ActionResult> GetReservationById(string auId)
        {
            try
            {
                var reservation = await _reservationRepository.GetReservationById(auId);

                var canteenId = await _menuRepository.GetCanteenIdForMenuAsync(reservation.MenuId);

                var canteen = await _canteenRepository.GetCanteenByIdAsync(canteenId);

                var mealReservations = reservation.Meals?.Select(meal => new MealReservationDescription
                {
                    MealId = meal.MealId,
                    MealName = meal.MealName
                }).ToList() ?? new List<MealReservationDescription>();

                var response = new ReservationForUserResponse
                {
                    CanteenName = canteen.Name,
                    MealReservations = mealReservations
                };

                return Ok(response);
            }
            catch (Exception ex) when (ex is ReservationNotFoundException or MenuNotFoundException)
            {
                return NotFound(auId);
            }
        }

        /// <summary>
        /// Query (3) Number of reservations for each of the daily menu options for a canteen
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("query3/{canteenName}")]
        public async Task<ActionResult> GetReservationsQuantity(string canteenName)
        {
            try
            {
                var canteen = await _canteenRepository.GetCanteenWithMenusAndReservationsByNameAsync(canteenName);

                if (canteen.Menus == null)
                    return NotFound($"Could not find any menus for '{canteenName}'");

                var menu = canteen.Menus.FirstOrDefault();

                var response = new ReservationsQuantityResponse
                {
                    WarmDish = new WarmDish
                    {
                        Amount = menu!.Reservations!.Sum(reservation => reservation.WarmQuantity ?? 0),
                        Name = menu!.WarmDishName
                    },
                    StreetFood = new StreetFood
                    {
                        Amount = menu!.Reservations!.Sum(reservation => reservation.StreetQuantity ?? 0),
                        Name = menu!.StreetFoodName
                    }
                };

                return Ok(response);
            }
            catch (CanteenNotFoundException)
            {
                return NotFound(canteenName);
            }
        }

        /// <summary>
        /// Query (4) Just-in-time meal options and the available (canceled) daily menu
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("query4/{canteenName}")]
        public async Task<ActionResult> GetAvailableMealsForCanteen(string canteenName)
        {
            try
            {
                var canteen = await _canteenRepository.GetCanteenWithMealsAndJitMealsByNameAsync(canteenName);

                var canceledMeals = canteen.Meals!.Where(meal => meal.ReservationId == null).ToList();

                var jitMeals = canteen.JitMeals;

                var response = new AvailableMealsResponse
                {
                    CanceledMeals = _mapper.Map<List<Meal>, List<SimpleMeal>>(canceledMeals),
                    JitMeals = _mapper.Map<List<JitMeal>, List<SimpleJitMeal>>(jitMeals!)
                };

                return Ok(response);
            }
            catch (CanteenNotFoundException)
            {
                return BadRequest(canteenName);
            }
        }

        /// <summary>
        /// Query (5) available (canceled) daily menu in the nearby canteens
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("query5/{canteenName}")]
        public async Task<ActionResult> GetAvailableMealsInNearbyCanteen(string canteenName)
        {
            try
            {
                var nearbyCanteens = await _canteenRepository.GetNearbyCanteenMealsByNameAsync(canteenName);

                var nearbyCanceledMeals = nearbyCanteens.SelectMany(canteen => canteen.Meals!).Where(meal => meal.ReservationId == null).ToList();

                var response = new AvailableNearbyMealsResponse
                {
                    NearbyMeals = nearbyCanceledMeals.Select(meal => 
                        new NearbyMeal
                        {
                            CanteenName = nearbyCanteens.FirstOrDefault(canteen => canteen.CanteenId == meal.CanteenId)?.Name!, 
                            MealName = meal.MealName
                        }).ToList()
                };

                return Ok(response);
            }
            catch (CanteenNotFoundException)
            {
                return BadRequest(canteenName);
            }
        }

        /// <summary>
        /// Query (6) average ratings from all the canteens from top to bottom
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("query6")]
        public async Task<ActionResult> GetAverageRatingForCanteens()
        {
            try
            {
                var canteens = await _canteenRepository.GetAllCanteensWithRatings();

                var canteenRatingResponse = new CanteenRatingResponse
                {
                    CanteenRatings = canteens.Select(canteen => new CanteenRating
                    {
                        Name = canteen.Name,
                        AvgRating = canteen.Ratings?.Any() == true ? Math.Round(canteen.Ratings.Average(rating => rating.Stars), 1) : 0
                    })
                        .OrderByDescending(canteenRating => canteenRating.AvgRating)
                        .ToList()
                };

                return Ok(canteenRatingResponse);
            }
            catch (CanteenNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
