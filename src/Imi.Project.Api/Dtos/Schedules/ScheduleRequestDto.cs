using Imi.Project.Api.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dtos.Schedules
{
    public class ScheduleRequestDto : BaseDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public Guid PlantId { get; set; }
        public string UserId { get; set; }
        public Guid PlantActionId { get; set; }
    }
}
