using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Repositories.Interface
{
    public interface IScheduleRepository : IBaseRepository<Schedule>
    {
        Task<IEnumerable<Schedule>> GetByPlantActionIdAsync(Guid id);
        Task<IEnumerable<Schedule>> GetByPlantIdAsync(Guid id);
        Task<IEnumerable<Schedule>> GetByUsernameIdAsync(string id);
    }
}
