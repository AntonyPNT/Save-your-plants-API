using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Repositories
{
    public class PlantRepository : BaseRepository<Plant>, IPlantRepository
    {
        public PlantRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
        public override IQueryable<Plant> GetAll()
        {
            return _dbContext.Plants.Include(p => p.ApplicationUser);
        }

        public async override Task<IEnumerable<Plant>> ListAllAsync()
        {
            var plants = await GetAll().ToListAsync();
            return plants;
        }

        public async override Task<Plant> GetByIdAsync(Guid id)
        {
            var plants = await GetAll().SingleOrDefaultAsync(p => p.Id.Equals(id));
            return plants;
        }

        //overerving
        public async Task<IEnumerable<Plant>> GetByUsernameIdAsync(string id) //voorlopig nog ownerId, moet veranderen naar AppUserId in toekomst
        {
            var plants = await GetAll().Where(p => p.ApplicationUserId.Equals(id)).ToListAsync(); //het was p.ownerId en het werkte
            return plants;
        }

        public async Task<IEnumerable<Plant>> SearchAsync(string search)
        {
            var plants = await GetAll()
               .Where(p => p.Name.Contains(search.Trim().ToUpper()) || p.ApplicationUser.UserName.Contains(search.Trim().ToUpper()))
               .ToListAsync();

            return plants;
        }
    }
}
