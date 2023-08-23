using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Dtos.Accounts;
using Imi.Project.Api.Dtos.Plants;
using Imi.Project.Api.Repositories.Interface;
using Imi.Project.Api.Services.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IUserService _userService;
        protected readonly IPlantRepository _plantRepository;
        protected readonly IImageService _imageService;

        public PlantsController(
            IUserService userService,
            IPlantRepository plantRepository,
            IImageService imageService)
        {
            _userService = userService;
            _plantRepository = plantRepository;
            _imageService = imageService;
        }

        [HttpGet]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Get()
        {
            var plants = await _plantRepository.ListAllAsync();
            var plantsDto = plants.Select(p => new PlantResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Condition = p.Condition,
                DateOfPurchase = p.DateOfPurchase,
                Image = p.Image,
                User = new AccountsResponseDto
                {
                    Id = p.ApplicationUser.Id,
                    Username = p.ApplicationUser.UserName
                }
            });

            return Ok(plantsDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Get(Guid id)
        {
            var plant = await _plantRepository.GetByIdAsync(id);
            if (plant == null)
            {
                return NotFound($"No plant with an id of {id} found.");
            }
            var plantDto = new PlantResponseDto
            {
                Id = plant.Id,
                Name = plant.Name,
                Condition = plant.Condition,
                DateOfPurchase = plant.DateOfPurchase,
                Image = plant.Image,
                User = new AccountsResponseDto
                {
                    Id = plant.ApplicationUser.Id,
                    Username = plant.ApplicationUser.UserName
                }
            };

            return Ok(plantDto);
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Add(PlantRequestDto plantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            //var owner = await _ownerRepository.GetByIdAsync(plantDto.OwnerId);
            var user = await _userService.GetByIdAsync(plantDto.UserId);

            //if (owner == null)
            //{
            //    return BadRequest($"Cannot add new plant because owner with id {plantDto.OwnerId} does not exists");
            //}

            if (user == null)
            {
                return BadRequest($"Cannot add new plant because user with id {plantDto.UserId} does not exists");
            }

            var plantEntity = new Plant
            {
                ApplicationUserId = plantDto.UserId,
                Name = plantDto.Name,
                Condition = plantDto.Condition,
                DateOfPurchase = DateTime.Now
            };

            await _plantRepository.AddAsync(plantEntity);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Update(PlantRequestDto plantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            //var owner = await _ownerRepository.GetByIdAsync(plantDto.OwnerId);
            var user = await _userService.GetByIdAsync(plantDto.UserId.ToString());

            //if (owner == null)
            //{
            //    return BadRequest($"Cannot update plant because user with id {plantDto.OwnerId} does not exists");
            //}

            if (user == null)
            {
                return BadRequest($"Cannot update plant because user with id {plantDto.UserId} does not exists");
            }

            var plantEntity = await _plantRepository.GetByIdAsync(plantDto.Id);

            if (plantEntity == null)
            {
                return NotFound($"No plant with an id of {plantDto.Id}");
            }
            plantEntity.ApplicationUserId = plantDto.UserId.ToString();
            //plantEntity.OwnerId = plantDto.OwnerId;
            plantEntity.Name = plantDto.Name;
            plantEntity.Condition = plantDto.Condition;
            
            await _plantRepository.UpdateAsync(plantEntity);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var plantEntity = await _plantRepository.GetByIdAsync(id);

            if (plantEntity == null)
            {
                return NotFound($"No plant with an id of {id}");
            }

            await _plantRepository.DeleteAsync(plantEntity);

            return Ok();
        }

        [HttpPost("{id}/image")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> AddOrUpdateImage(Guid id, IFormFile image)
        {
            var plantEntity = await _plantRepository.GetByIdAsync(id);

            if (plantEntity == null)
            {
                return NotFound("plant doesn't exists!");
            }

            plantEntity.Image = await _imageService.AddOrUpdateImageAsync<Plant>(id, image);

            await _plantRepository.UpdateAsync(plantEntity);

            var plantDto = new PlantResponseDto
            {
                Id = plantEntity.Id,
                Name = plantEntity.Name,
                Condition = plantEntity.Condition,
                DateOfPurchase = plantEntity.DateOfPurchase,
                Image = GetFullImageUrl(plantEntity.Image)
            };

            return Ok(plantDto);
        }

        private static string GetFullImageUrl(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                return null;
            }

            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var scheme = httpContextAccessor.HttpContext.Request.Scheme; // example: https or http
            var url = httpContextAccessor.HttpContext.Request.Host.Value; // example: localhost:5001, howest.be, steam.com, localhost:44785, ...

            var fullImageUrl = $"{scheme}://{url}/{image.Replace("\\", "/")}";

            return fullImageUrl;
        }
    }
}
