//using Imi.Project.Api.Core.Entities;
//using Imi.Project.Api.Dtos.Accounts;
//using Imi.Project.Api.Dtos.Owners;
//using Imi.Project.Api.Dtos.Plants;
//using Imi.Project.Api.Repositories.Interface;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Imi.Project.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OwnersController : ControllerBase
//    {
//        protected readonly IOwnerRepository _ownerRepository;
//        protected readonly IPlantRepository _plantRepository;

//        public OwnersController(IOwnerRepository ownerRepository, IPlantRepository plantRepository)
//        {
//            _ownerRepository = ownerRepository;
//            _plantRepository = plantRepository;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var owners = await _ownerRepository.ListAllAsync();
//            var ownersDto = owners.Select(owner => new OwnerResponseDto
//            {
//                Id = owner.Id,
//                FirstName = owner.FirstName,
//                LastName = owner.LastName,
//                UserName = owner.Username,
//                Password = owner.Password,
//                CreationDate = owner.CreationDate,
//                EmailAdress = owner.EmailAdress
//            });

//            return Ok(ownersDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> Get(Guid id)
//        {
//            var owner = await _ownerRepository.GetByIdAsync(id);
//            if (owner == null)
//            {
//                return NotFound($"No category with an id of {id}");
//            }
//            var ownerDto = new OwnerResponseDto
//            {
//                Id = owner.Id,
//                FirstName = owner.FirstName,
//                LastName = owner.LastName,
//                UserName = owner.Username,
//                Password = owner.Password,
//                CreationDate = owner.CreationDate,
//                EmailAdress = owner.EmailAdress
//            };
//            return Ok(ownerDto);
//        }

//        //[HttpGet("{id}/plants")]
//        //public async Task<IActionResult> GetPlantsFromOwners(Guid id)
//        //{
//        //    var plants = await _plantRepository.GetByUsernameIdAsync(id);

//        //    var ownersDto = plants.Select(p => new PlantResponseDto
//        //    {
//        //        Id = p.Id, //dit vullen met meer info over de plant en minder info over owners
//        //        Name = p.Name,
//        //        Condition = p.Condition,
//        //        DateOfPurchase = p.DateOfPurchase,
//        //        Image = p.Image,
//        //        User = new AccountsResponseDto //dit zal ik nodig hebben voor schedules uit ERD
//        //        {
//        //            Id = new Guid(p.ApplicationUser.Id),
//        //            Username = p.ApplicationUser.UserName
//        //        }
//        //    });

//        //    return Ok(ownersDto);
//        //}

//        [HttpGet("{id}/plants")]
//        public async Task<IActionResult> GetPlantsFromOwners(Guid id)
//        {
//            var plants = await _plantRepository.GetByUsernameIdAsync(id); //plant = product

//            var plantsDto = plants.Select(p => new PlantResponseDto
//            {
//                Id = p.Id,
//                Name = p.Name,
//                User = new AccountsResponseDto
//                {
//                    Id = new Guid(p.ApplicationUser.Id),
//                    Username = p.ApplicationUser.UserName
//                }
//            });

//            return Ok(plantsDto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add(OwnerRequestDto ownerDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState.Values);
//            }

//            var ownerEntity = new Owner
//            {
//                FirstName = ownerDto.FirstName,
//                LastName = ownerDto.LastName,
//                EmailAdress = ownerDto.EmailAdress,
//                Username = ownerDto.UserName,
//                Password = ownerDto.Password,
//                CreationDate = DateTime.Now
//            };

//            await _ownerRepository.AddAsync(ownerEntity);

//            return Ok();
//        }

//        [HttpPut]//update username
//        public async Task<IActionResult> Update(OwnerRequestDto ownerDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState.Values);
//            }

//            var ownerEntity = await _ownerRepository.GetByIdAsync(ownerDto.Id);

//            if (ownerEntity == null)
//            {
//                return NotFound($"No owner with an id of {ownerDto.Id} found.");
//            }

//            ownerEntity.Username = ownerDto.UserName;


//            await _ownerRepository.UpdateAsync(ownerEntity);

//            return Ok();
//        }

//        [HttpDelete("{id}")] //hard delete
//        public async Task<IActionResult> Delete(Guid id)
//        {
//            var ownerEntity = await _ownerRepository.GetByIdAsync(id);

//            if (ownerEntity == null)
//            {
//                return NotFound($"No owner with an id of {id}");
//            }

//            await _ownerRepository.DeleteAsync(ownerEntity);

//            return Ok();
//        }
//    }
//}
