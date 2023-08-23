using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Repositories.Interface
{
    public interface IPlantRepository : IBaseRepository<Plant>
    {
        Task<IEnumerable<Plant>> GetByUsernameIdAsync(string id);
        Task<IEnumerable<Plant>> SearchAsync(string search);
    }
}
