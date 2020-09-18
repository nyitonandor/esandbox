using AutoMapper;
using EServer.Dtos;
using EServer.Models;
using EServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private const string ErrorCode500SomethingWentWrong = "500! Something went wrong";

        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IMapper _mapper;

        public MotorcycleController(IMotorcycleRepository motorcycleRepository, IMapper mapper)
        {
            _motorcycleRepository = motorcycleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MotorcycleDto>>> GetAsync()
        {
            try
            {
                var results = await _motorcycleRepository.GetAllAsync().ConfigureAwait(false);
                var motorcycles = _mapper.Map<List<MotorcycleDto>>(results);

                return Ok(motorcycles);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ErrorCode500SomethingWentWrong);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<MotorcycleDto>>> GetAsync(Guid id)
        {
            try
            {
                var result = await _motorcycleRepository.GetAsync(id).ConfigureAwait(false);
                var motorcycle = _mapper.Map<MotorcycleDto>(result);

                return Ok(motorcycle);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ErrorCode500SomethingWentWrong);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MotorcycleDto>> PostAsync(MotorcycleDto motorcycle)
        {
            try
            {
                var mapedObject = _mapper.Map<Motorcycle>(motorcycle);
                await _motorcycleRepository.AddAsync(mapedObject).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ErrorCode500SomethingWentWrong);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MotorcycleDto>> DeleteAsync(Guid id)
        {
            try
            {
                var motorcycle = await _motorcycleRepository.GetAsync(id).ConfigureAwait(false);
                if (motorcycle == null)
                {
                    return NotFound();
                }

                await _motorcycleRepository.DeleteAsync(motorcycle).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ErrorCode500SomethingWentWrong);
            }
        }
    }
}
