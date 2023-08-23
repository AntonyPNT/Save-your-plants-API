using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Dtos.PlantActions;
using Imi.Project.Api.Dtos.Plants;
using Imi.Project.Api.Dtos.Schedules;
using Imi.Project.Api.Repositories;
using Imi.Project.Api.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantActionsController : ControllerBase
    {
        protected readonly IPlantActionRepository _plantActionRepository;
        protected readonly IScheduleRepository _scheduleRepository;

        public PlantActionsController(IPlantActionRepository plantActionRepository, IScheduleRepository scheduleRepository)
        {
            _plantActionRepository = plantActionRepository;
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet]
        //[Authorize(Policy = "User")]
        public async Task<IActionResult> Get()
        {
            var plantactions = await _plantActionRepository.ListAllAsync();
            var plantActionsDto = plantactions.Select(plantAction => new PlantActionResponseDto
            {
                Id = plantAction.Id,
                Name = plantAction.Name
            });
            return Ok(plantActionsDto);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "User")]
        public async Task<IActionResult> Get(Guid id)
        {
            var plantAction = await _plantActionRepository.GetByIdAsync(id);
            if (plantAction == null)
            {
                return NotFound($"No plant action with an id of {id}");
            }
            var plantActionDto = new PlantActionResponseDto
            {
                Id = plantAction.Id,
                Name = plantAction.Name
            };
            return Ok(plantActionDto);
        }

        [HttpGet("{id}/schedules")]
        //[Authorize(Policy = "User")]
        public async Task<IActionResult> GetschedulesFromPlantActions(Guid id)
        {
            var schedules = await _scheduleRepository.GetByPlantActionIdAsync(id);

            var plantActionsDto = schedules.Select(s => new ScheduleResponseDto
            {
                Id = s.Id,
                Date = s.Date,
                //PlantId = s.PlantId,
                PlantAction = new PlantActionResponseDto
                {
                    Id = s.PlantAction.Id,
                    Name = s.PlantAction.Name
                }
            });
            return Ok(plantActionsDto);
        }

        [HttpPost]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> Add(PlantActionRequestDto plantActionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var plantActionEntity = new PlantAction
            {
                Id=plantActionDto.Id,
                Name=plantActionDto.Name
            };

            await _plantActionRepository.AddAsync(plantActionEntity);

            return Ok();
        }

        [HttpPut]
        //[Authorize(Policy = "Admin")]//update username
        public async Task<IActionResult> Update(PlantActionRequestDto plantActionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var plantActionEntity = await _plantActionRepository.GetByIdAsync(plantActionDto.Id);

            if (plantActionEntity == null)
            {
                return NotFound($"No plant action with an id of {plantActionDto.Id} found.");
            }

            plantActionEntity.Name = plantActionDto.Name;

            await _plantActionRepository.UpdateAsync(plantActionEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "User")]//hard delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var plantActionEntity = await _plantActionRepository.GetByIdAsync(id);

            if (plantActionEntity == null)
            {
                return NotFound($"No plant action with an id of {id} found.");
            }

            await _plantActionRepository.DeleteAsync(plantActionEntity);

            return Ok();
        }
    }
}
