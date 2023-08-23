using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Dtos.Accounts;
using Imi.Project.Api.Dtos.PlantActions;
using Imi.Project.Api.Dtos.Plants;

namespace Imi.Project.Api.Dtos.Schedules
{
    public class ScheduleResponseDto : BaseDto
    {
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public PlantResponseDto Plant { get; set; }
        public PlantActionResponseDto PlantAction { get; set; }
        public AccountsResponseDto User { get; set; }
    }
}
