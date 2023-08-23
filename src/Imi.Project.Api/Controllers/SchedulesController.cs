using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Dtos.Accounts;
using Imi.Project.Api.Dtos.PlantActions;
using Imi.Project.Api.Dtos.Plants;
using Imi.Project.Api.Dtos.Schedules;
using Imi.Project.Api.Repositories;
using Imi.Project.Api.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        protected readonly IPlantActionRepository _plantActionRepository;
        private readonly IUserService _userService;
        protected readonly IScheduleRepository _scheduleRepository;
        protected readonly IPlantRepository _plantRepository;

        public SchedulesController(IPlantActionRepository plantActionRepository, IPlantRepository plantRepository, 
            IScheduleRepository scheduleRepository, 
            IUserService userService)
        {
            _scheduleRepository = scheduleRepository;
            _userService = userService;
            _plantRepository = plantRepository;
            _plantActionRepository = plantActionRepository;
        }

        [HttpGet]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Get()
        {
            var schedules = await _scheduleRepository.ListAllAsync();
            var schedulesDto = schedules.Select(p => new ScheduleResponseDto
            {
                Id = p.Id,
                Date = p.Date,
                IsCompleted = p.IsCompleted,
                PlantAction = new PlantActionResponseDto
                {
                    Id = p.PlantAction.Id,
                    Name = p.PlantAction.Name
                },
                Plant = new PlantResponseDto
                {
                    Id = p.Plant.Id,
                    Name = p.Plant.Name,
                    Condition = p.Plant.Condition,
                    DateOfPurchase = p.Plant.DateOfPurchase,
                    Image = p.Plant.Image
                },
                User = new AccountsResponseDto
                {
                    Id = p.Plant.ApplicationUserId,
                    Username = p.Plant.ApplicationUser.UserName,
                }
            });

            return Ok(schedulesDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Get(Guid id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound($"No schedule with an id of {id} found.");
            }
            var scheduleDto = new ScheduleResponseDto
            {
                Id = schedule.Id,
                Date = schedule.Date,
                IsCompleted = schedule.IsCompleted,
                PlantAction = new PlantActionResponseDto
                {
                    Id = schedule.PlantAction.Id,
                    Name = schedule.PlantAction.Name
                },
                Plant = new PlantResponseDto
                {
                    Id = schedule.Plant.Id,
                    Name = schedule.Plant.Name,
                    Condition = schedule.Plant.Condition,
                    DateOfPurchase = schedule.Plant.DateOfPurchase,
                    Image= schedule.Plant.Image
                }
            };

            return Ok(scheduleDto);
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Add(ScheduleRequestDto scheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var plantAction = await _plantActionRepository.GetByIdAsync(scheduleDto.PlantActionId);

            if (plantAction == null)
            {
                return BadRequest($"Cannot add new schedule because plant action with id {scheduleDto.PlantActionId} does not exists");
            }

            var plant = await _plantRepository.GetByIdAsync(scheduleDto.PlantId);

            if (plant == null)
            {
                return BadRequest($"Cannot add new schedule because plant with id {scheduleDto.PlantId} does not exists");
            }

            var scheduleEntity = new Schedule
            {
                PlantActionId = scheduleDto.PlantActionId,
                PlantId = scheduleDto.PlantId,
                ApplicationUserId = scheduleDto.UserId,
                Date = scheduleDto.Date,
                IsCompleted = false
            };

            await _scheduleRepository.AddAsync(scheduleEntity);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Update(ScheduleRequestDto scheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var plantAction = await _plantActionRepository.GetByIdAsync(scheduleDto.PlantActionId);

            if (plantAction == null)
            {
                return BadRequest($"Cannot add new schedule because plant action with id {scheduleDto.PlantActionId} does not exists");
            }

            var user = await _userService.GetByIdAsync(scheduleDto.UserId);

            if (user == null)
            {
                return BadRequest($"Cannot add new schedule because user with id {scheduleDto.UserId} does not exists");
            }

            var plant = await _plantRepository.GetByIdAsync(scheduleDto.PlantId);

            if (plant == null)
            {
                return BadRequest($"Cannot add new schedule because plant with id {scheduleDto.PlantId} does not exists");
            }

            var scheduleEntity = await _scheduleRepository.GetByIdAsync(scheduleDto.Id);

            if (scheduleEntity == null)
            {
                return NotFound($"No schedule with an id of {scheduleDto.Id}");
            }

            scheduleEntity.PlantId = scheduleDto.PlantId;
            scheduleEntity.ApplicationUserId = scheduleDto.UserId;
            scheduleEntity.PlantActionId = scheduleDto.PlantActionId;
            scheduleEntity.Date = scheduleDto.Date;

            await _scheduleRepository.UpdateAsync(scheduleEntity);

            return Ok();
        }

        //[HttpPut]
        ////[Authorize(Policy = "User")]
        //public async Task<IActionResult> UpdateBoolean(Guid id)
        //{
        //    var scheduleEntity = await _scheduleRepository.GetByIdAsync(id);

        //    if (scheduleEntity == null)
        //    {
        //        return NotFound($"No schedule with an id of {id}");
        //    }

        //    scheduleEntity.IsCompleted = true;

        //    await _scheduleRepository.UpdateAsync(scheduleEntity);

        //    return Ok();
        //}

        [HttpDelete("{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var scheduleEntity = await _scheduleRepository.GetByIdAsync(id);

            if (scheduleEntity == null)
            {
                return NotFound($"No schedule with an id of {id}");
            }

            await _scheduleRepository.DeleteAsync(scheduleEntity);

            return Ok();
        }
    }
}
