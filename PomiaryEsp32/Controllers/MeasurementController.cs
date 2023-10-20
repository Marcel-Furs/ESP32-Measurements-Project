using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomiaryEsp32.Data.Models;
using PomiaryEsp32.Data.Repositories;
using PomiaryEsp32.Dto;
using PomiaryEsp32.Services;

namespace PomiaryEsp32.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MeasurementController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IBaseRepository<Measurement, int> measurementRepository;
        private readonly IMapper mapper;

        public MeasurementController(IUserService userService, IBaseRepository<Measurement, int> measurementRepository, IMapper mapper)
        {
            this.userService = userService;
            this.measurementRepository = measurementRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var measurement = await measurementRepository.GetAll();
            if(measurement.Count == 0)
            {
                return NoContent();
            }

            return Ok(measurement);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var measurement = await measurementRepository.Get(id);
            if(measurement == null)
            {
                return NotFound();
            }
            return Ok(measurement);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MeasurementDTO dto)
        {
            if(ModelState.IsValid)
            {
                var obj = mapper.Map<Measurement>(dto);
                obj.User = await userService.GetUserFromRequest(User);
                await measurementRepository.Create(obj);
                return Ok(obj);
            }

            return BadRequest("Invalid data");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MeasurementDTO dto)
        {
            var measurement = await measurementRepository.Get(id);
            if(measurement == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                mapper.Map(dto, measurement);
                await measurementRepository.Update(measurement);
                return Ok(measurement);
            }

            return BadRequest("Invalid data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var measurement = await measurementRepository.Get(id);
            if (measurement == null)
            {
                return NotFound();
            }

            await measurementRepository.Delete(id);
            return Ok(measurement);
        }

    }
}
