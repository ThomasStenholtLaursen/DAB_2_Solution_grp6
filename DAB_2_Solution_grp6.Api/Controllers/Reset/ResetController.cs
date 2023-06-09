﻿using DAB_2_Solution_grp6.Api.Seed;
using DAB_2_Solution_grp6.DataAccess;
using DAB_2_Solution_grp6.DataAccess.Repositories.Global;
using Microsoft.AspNetCore.Mvc;

namespace DAB_2_Solution_grp6.Api.Controllers.Reset
{
    [ApiController]
    [Route("api")]
    public class ResetController : ControllerBase
    {
        private readonly IGlobalRepository _globalRepository;
        private readonly CanteenAppDbContext _dbContext;

        public ResetController(IGlobalRepository globalRepository, CanteenAppDbContext dbContext)
        {
            _globalRepository = globalRepository;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Seed Database (if no data exists)
        /// </summary>
        [HttpPost("Seed")]
        public async Task<ActionResult> SeedDatabase()
        {
            await DataSeed.Seed(_dbContext);

            return Ok();
        }

        /// <summary>
        /// Clear Database (REMOVE ALL DATA IN TABLES)
        /// </summary>
        [HttpDelete("Clear")]
        public async Task<ActionResult> ClearDatabase()
        {
            await _globalRepository.RemoveAll();

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
