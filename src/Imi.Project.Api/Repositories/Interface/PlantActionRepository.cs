using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data;

namespace Imi.Project.Api.Repositories.Interface
{
    public class PlantActionRepository : BaseRepository<PlantAction>, IPlantActionRepository
    {
        public PlantActionRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}
