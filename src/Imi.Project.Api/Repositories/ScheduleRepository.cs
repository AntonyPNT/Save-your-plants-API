using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
        public override IQueryable<Schedule> GetAll()
        {
            return _dbContext.Schedules.Include(s => s.PlantAction).Include(s => s.Plant).Include(s => s.Plant.ApplicationUser);
        }

        public async override Task<IEnumerable<Schedule>> ListAllAsync()
        {
            var schedules = await GetAll().ToListAsync();
            return schedules;
        }

        public async override Task<Schedule> GetByIdAsync(Guid id)
        {
            var schedules = await GetAll().SingleOrDefaultAsync(p => p.Id.Equals(id));
            return schedules;
        }

        //overerving
        public async Task<IEnumerable<Schedule>> GetByPlantActionIdAsync(Guid id)
        {
            var schedule = await GetAll().Where(s => s.PlantActionId.Equals(id)).ToListAsync();
            return schedule;
        }

        public async Task<IEnumerable<Schedule>> GetByPlantIdAsync(Guid id)
        {
            var schedule = await GetAll().Where(s => s.PlantId.Equals(id)).ToListAsync();
            return schedule;
        }

        public async Task<IEnumerable<Schedule>> GetByUsernameIdAsync(string id) 
        {
            var schedules = await GetAll().Where(p => p.ApplicationUserId.Equals(id)).ToListAsync(); 
            return schedules;
        }
    }
}
